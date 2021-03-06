﻿using GlmSharp;
using Remotion.Linq.Clauses.Expressions;
using SharpVk.Spirv;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SharpVk.Shanq
{
    internal class ShanqExpressionVisitor
    {
        private Dictionary<ExpressionType, Func<Expression, ResultId>> expressionVisitors = new Dictionary<ExpressionType, Func<Expression, ResultId>>();
        private Dictionary<SpirvStatement, ResultId> expressionResults = new Dictionary<SpirvStatement, ResultId>();
        private readonly SpirvFile file;
        private Dictionary<FieldInfo, ResultId> inputMappings = new Dictionary<FieldInfo, ResultId>();
        private Dictionary<FieldInfo, Tuple<ResultId, int>> bindingMappings = new Dictionary<FieldInfo, Tuple<ResultId, int>>();

        public ShanqExpressionVisitor(SpirvFile file)
        {
            var visitMethods = this.GetType()
                                    .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                                    .Where(method => method.GetCustomAttribute<NodeTypeAttribute>() != null);

            foreach (var method in visitMethods)
            {
                var attribute = method.GetCustomAttribute<NodeTypeAttribute>();

                this.expressionVisitors.Add(attribute.NodeType, x => (ResultId)method.Invoke(this, new object[] { x }));
            }

            this.file = file;
        }

        public void AddInputMapping(FieldInfo field, ResultId resultId)
        {
            this.inputMappings.Add(field, resultId);
        }

        public void AddBinding(FieldInfo field, Tuple<ResultId, int> binding)
        {
            this.bindingMappings.Add(field, binding);
        }

        public ResultId Visit(Expression expression)
        {
            Func<Expression, ResultId> visit;

            if (!this.expressionVisitors.TryGetValue(expression.NodeType, out visit))
            {
                throw new NotImplementedException();
            }
            else
            {
                return visit(expression);
            }
        }

        [NodeType(ExpressionType.Negate)]
        private ResultId VisitNegate(UnaryExpression expression)
        {
            if (GetElementType(expression.Type) != typeof(float))
            {
                throw new NotSupportedException();
            }

            return VisitUnary(expression, Op.OpFNegate);
        }

        [NodeType(ExpressionType.Add)]
        private ResultId VisitAdd(BinaryExpression expression)
        {
            Op additionOp = SelectByType(expression.Type, Op.OpFAdd, Op.OpIAdd);

            return VisitBinary(expression, additionOp);
        }

        [NodeType(ExpressionType.Subtract)]
        private ResultId VisitSubtract(BinaryExpression expression)
        {
            Op subtractionOp = SelectByType(expression.Type, Op.OpFSub, Op.OpISub);

            return VisitBinary(expression, subtractionOp);
        }

        [NodeType(ExpressionType.Multiply)]
        private ResultId VisitMultiply(BinaryExpression expression)
        {
            Op multiplicationOp;

            if (IsVectorType(expression.Left.Type) && !IsVectorType(expression.Right.Type))
            {
                if (!IsFloatingPoint(GetVectorElementType(expression.Left.Type))
                        || !IsFloatingPoint(GetElementType(expression.Right.Type)))
                {
                    throw new NotSupportedException();
                }

                if (IsMatrixType(expression.Right.Type))
                {
                    multiplicationOp = Op.OpVectorTimesMatrix;
                }
                else
                {
                    multiplicationOp = Op.OpVectorTimesScalar;
                }
            }
            else if (IsMatrixType(expression.Left.Type))
            {
                if (!IsFloatingPoint(GetElementType(expression.Right.Type)))
                {
                    throw new NotSupportedException();
                }

                if (IsVectorType(expression.Right.Type))
                {
                    multiplicationOp = Op.OpMatrixTimesVector;
                }
                else if (IsMatrixType(expression.Right.Type))
                {
                    multiplicationOp = Op.OpMatrixTimesMatrix;
                }
                else
                {
                    multiplicationOp = Op.OpMatrixTimesScalar;
                }
            }
            else
            {
                multiplicationOp = SelectByType(expression.Type, Op.OpFMul, Op.OpIMul);
            }

            return VisitBinary(expression, multiplicationOp);
        }

        [NodeType(ExpressionType.Modulo)]
        private ResultId VisitModulo(BinaryExpression expression)
        {
            Op moduloOp = SelectByType(expression.Type, Op.OpFMod, Op.OpSMod, Op.OpUMod);

            return VisitBinary(expression, moduloOp);
        }

        [NodeType(ExpressionType.Divide)]
        private ResultId VisitDivide(BinaryExpression expression)
        {
            Op divisionOp = SelectByType(expression.Type, Op.OpFDiv, Op.OpSDiv, Op.OpUDiv);

            return VisitBinary(expression, divisionOp);
        }

        private ResultId VisitUnary(UnaryExpression expression, Op unaryOp)
        {
            ResultId resultTypeId = this.Visit(Expression.Constant(expression.Type));

            ResultId operand = this.Visit(expression.Operand);
            ResultId result = this.file.GetNextResultId();

            this.file.AddFunctionStatement(result, unaryOp, resultTypeId, operand);

            return result;
        }

        private ResultId VisitBinary(BinaryExpression expression, Op binaryOp)
        {
            ResultId resultTypeId = this.Visit(Expression.Constant(expression.Type));

            ResultId left = this.Visit(expression.Left);
            ResultId right = this.Visit(expression.Right);
            ResultId result = this.file.GetNextResultId();

            this.file.AddFunctionStatement(result, binaryOp, resultTypeId, left, right);

            return result;
        }

        [NodeType(ExpressionType.MemberAccess)]
        private ResultId VisitMemberAccess(MemberExpression expression)
        {
            if (expression.Expression is QuerySourceReferenceExpression)
            {
                var fieldInfo = (FieldInfo)expression.Member;

                return this.GetInputId(fieldInfo);
            }
            else
            {
                var targetType = expression.Expression.Type;

                if (IsVectorType(targetType))
                {
                    string name;
                    Type type;
                    GetMemberData(expression, out name, out type);

                    int fieldIndex;

                    switch (name)
                    {
                        case "x":
                        case "r":
                            fieldIndex = 0;
                            break;
                        case "y":
                        case "g":
                            fieldIndex = 1;
                            break;
                        case "z":
                        case "b":
                            fieldIndex = 2;
                            break;
                        case "w":
                        case "a":
                            fieldIndex = 3;
                            break;
                        default:
                            throw new Exception($"Unsupported field: {name}");
                    }

                    ResultId targetId = this.Visit(expression.Expression);

                    ResultId typeId = this.Visit(Expression.Constant(type));

                    ResultId accessId = this.file.GetNextResultId();

                    this.file.AddFunctionStatement(accessId, Op.OpCompositeExtract, typeId, targetId, fieldIndex);

                    return accessId;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        private static void GetMemberData(MemberExpression expression, out string name, out Type type)
        {
            name = expression.Member.Name;

            switch (expression.Member.MemberType)
            {
                case MemberTypes.Field:
                    type = ((FieldInfo)expression.Member).FieldType;
                    break;
                case MemberTypes.Property:
                    type = ((PropertyInfo)expression.Member).PropertyType;
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        private ResultId GetInputId(FieldInfo fieldInfo)
        {
            ResultId typeId = this.Visit(Expression.Constant(fieldInfo.FieldType));

            if (this.inputMappings.ContainsKey(fieldInfo))
            {
                ResultId fieldId = this.inputMappings[fieldInfo];

                ResultId resultId = this.file.GetNextResultId();

                this.file.AddFunctionStatement(resultId, Op.OpLoad, typeId, fieldId);

                return resultId;
            }
            else
            {
                ResultId pointerTypeId = this.Visit(Expression.Constant(typeof(UniformPointer<>).MakeGenericType(fieldInfo.FieldType)));

                var binding = this.bindingMappings[fieldInfo];

                ResultId accessId = this.file.GetNextResultId();

                this.file.AddFunctionStatement(accessId, Op.OpAccessChain, pointerTypeId, binding.Item1, this.Visit(Expression.Constant(binding.Item2)));

                ResultId resultId = this.file.GetNextResultId();

                this.file.AddFunctionStatement(resultId, Op.OpLoad, typeId, accessId);

                return resultId;
            }
        }

        [NodeType(ExpressionType.New)]
        private ResultId VisitNew(NewExpression expression)
        {
            SpirvStatement statement;

            if (IsVectorType(expression.Type))
            {
                var operands = new[] { this.Visit(Expression.Constant(expression.Type)) }
                                    .Concat(this.ExpandNewArguments(expression.Arguments));

                statement = new SpirvStatement(Op.OpCompositeConstruct, operands.Cast<object>().ToArray());
            }
            else
            {
                throw new NotImplementedException();
            }

            ResultId resultId = this.file.GetNextResultId();

            this.file.AddFunctionStatement(resultId, statement);

            return resultId;
        }

        private IEnumerable<ResultId> ExpandNewArguments(IEnumerable<Expression> arguments)
        {
            foreach (var argument in arguments)
            {
                ResultId argumentId = this.Visit(argument);

                if (IsVectorType(argument.Type))
                {
                    ResultId typeId = this.Visit(Expression.Constant(GetVectorElementType(argument.Type)));

                    for (int index = 0; index < GetVectorLength(argument.Type); index++)
                    {
                        ResultId fieldId = this.file.GetNextResultId();

                        this.file.AddFunctionStatement(fieldId, Op.OpCompositeExtract, typeId, argumentId, index);

                        yield return fieldId;
                    }
                }
                else
                {
                    yield return argumentId;
                }
            }
        }

        [NodeType(ExpressionType.Constant)]
        private ResultId VisitConstant(ConstantExpression expression)
        {
            SpirvStatement statement;

            if (IsVectorType(expression.Type))
            {
                var operands = new object[] { expression.Type }
                                    .Concat(((IEnumerable)expression.Value).OfType<object>())
                                    .Select(x => (object)this.Visit(Expression.Constant(x)));

                statement = new SpirvStatement(Op.OpConstantComposite, operands.ToArray());
            }
            else if (typeof(Type).IsAssignableFrom(expression.Type))
            {
                Type value = (Type)expression.Value;

                if (IsMatrixType(value))
                {
                    Type rowType = GetMatrixRowType(value);
                    int[] dimensions = GetMatrixDimensions(value);
                    
                    ResultId rowTypeId = this.Visit(Expression.Constant(rowType));

                    statement = new SpirvStatement(Op.OpTypeMatrix, rowTypeId, dimensions[0]);
                }
                else if (IsVectorType(value))
                {
                    Type elementType = GetVectorElementType(value);
                    int length = GetVectorLength(value);

                    ResultId elementTypeId = this.Visit(Expression.Constant(elementType));

                    statement = new SpirvStatement(Op.OpTypeVector, elementTypeId, length);
                }
                else if (typeof(Delegate).IsAssignableFrom(value))
                {
                    var returnType = value.GetMethod("Invoke").ReturnType;

                    ResultId returnTypeId = this.Visit(Expression.Constant(returnType));

                    if (value.GetMethod("Invoke").GetParameters().Length > 0)
                    {
                        throw new NotImplementedException();
                    }

                    statement = new SpirvStatement(Op.OpTypeFunction, returnTypeId);
                }
                else if (value.BaseType.IsGenericType && value.BaseType.GetGenericTypeDefinition() == typeof(Pointer<>))
                {
                    StorageClass storage = (StorageClass)value.GetProperty("Storage").GetValue(null);
                    ResultId typeId = this.Visit(Expression.Constant(value.GetGenericArguments()[0]));

                    statement = new SpirvStatement(Op.OpTypePointer, storage, typeId);
                }
                else if (IsTupleType(value))
                {
                    var fieldTypes = value.GetGenericArguments();

                    var fieldTypeIds = fieldTypes.Select(x => (object)this.Visit(Expression.Constant(x))).ToArray();

                    statement = new SpirvStatement(Op.OpTypeStruct, fieldTypeIds);
                }
                else if (value == typeof(float))
                {
                    statement = new SpirvStatement(Op.OpTypeFloat, 32);
                }
                else if (value == typeof(int))
                {
                    statement = new SpirvStatement(Op.OpTypeInt, 32, 1);
                }
                else if (value == typeof(void))
                {
                    statement = new SpirvStatement(Op.OpTypeVoid);
                }
                else if (value.IsValueType)
                {
                    var fieldTypeIds = value.GetFields().Select(x => (object)this.Visit(Expression.Constant(x.FieldType))).ToArray();

                    statement = new SpirvStatement(Op.OpTypeStruct, fieldTypeIds);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else
            {
                ResultId typeOperand = this.Visit(Expression.Constant(expression.Type));
                statement = new SpirvStatement(Op.OpConstant, typeOperand, expression.Value);
            }

            ResultId resultId;

            if (!this.expressionResults.TryGetValue(statement, out resultId))
            {
                resultId = this.file.GetNextResultId();

                this.expressionResults.Add(statement, resultId);

                this.file.AddGlobalStatement(resultId, statement);
            }

            return resultId;
        }

        private static Op SelectByType(Type type, Op floatingPointOp, Op integerOp)
        {
            return SelectByType(type, floatingPointOp, integerOp, integerOp);
        }

        private static Op SelectByType(Type type, Op floatingPointOp, Op signedIntegerOp, Op unsignedIntegerOp)
        {
            type = GetElementType(type);

            if (IsFloatingPoint(type))
            {
                return floatingPointOp;
            }
            else if (IsSignedInteger(type))
            {
                return signedIntegerOp;
            }
            else if (IsUnsignedInteger(type))
            {
                return unsignedIntegerOp;
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        private static bool IsFloatingPoint(Type type)
        {
            return type == typeof(float) || type == typeof(double);
        }

        private static bool IsInteger(Type type)
        {
            return IsSignedInteger(type) || IsUnsignedInteger(type);
        }

        private static bool IsSignedInteger(Type type)
        {
            return type == typeof(sbyte)
                    || type == typeof(short)
                    || type == typeof(int)
                    || type == typeof(long);
        }

        private static bool IsUnsignedInteger(Type type)
        {
            return type == typeof(byte)
                    || type == typeof(ushort)
                    || type == typeof(uint)
                    || type == typeof(ulong);
        }

        private bool IsTupleType(Type value)
        {
            Type tupleInterface = typeof(Tuple).Assembly.GetType("System.ITuple");

            return value.GetInterfaces().Contains(tupleInterface);
        }

        private static Type GetElementType(Type type)
        {
            if (type.IsPrimitive)
            {
                return type;
            }
            else if (IsVectorType(type))
            {
                return GetVectorElementType(type);
            }
            else if (IsMatrixType(type))
            {
                return typeof(float);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        private static Type GetMatrixRowType(Type value)
        {
            return value.GetProperty("Row0").PropertyType;
        }

        private static Type GetVectorElementType(Type value)
        {
            return value.GetField("x").FieldType;
        }

        private static int GetVectorLength(Type value)
        {
            return ((IEnumerable)value.GetProperty("Zero")
                                .GetValue(null))
                                .OfType<object>()
                                .Count();
        }

        private static int[] GetMatrixDimensions(Type value)
        {
            var identity = value.GetProperty("Identity")
                                .GetValue(null);

            var values = (float[,])value.GetProperty("Values")
                                        .GetValue(identity);

            return new[]
            {
                values.GetLength(0),
                values.GetLength(1)
            };
        }

        private static bool IsVectorType(Type type)
        {
            return type.Assembly == typeof(vec3).Assembly
                && type.Name.Contains("vec");
        }

        public static bool IsMatrixType(Type type)
        {
            return type.Assembly == typeof(mat4).Assembly
                && type.Name.Contains("mat");
        }

        private class NodeTypeAttribute
            : Attribute
        {
            public NodeTypeAttribute(ExpressionType nodeType)
            {
                this.NodeType = nodeType;
            }

            public ExpressionType NodeType
            {
                get;
                private set;
            }
        }
    }
}
