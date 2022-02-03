using cflatlang.Exceptions;
using cflatlang.Language;
using cflatlang.Lexing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cflatlang.Parsing;

internal class FunctionParser
{
    private IEnumerable<LexingToken> EvaluateSingleFunction(string functionName, ref ParsingContext scope)
    {
        const string callInnerStart = "(";
        Trace.Assert(string.Equals(callInnerStart, Separators.InnerContextStart.ToString(), StringComparison.Ordinal));
        Trace.Assert(string.Equals(callInnerStart, Separators.CallStart.ToString(), StringComparison.Ordinal));

        const string callInnerEnd = ")";
        Trace.Assert(string.Equals(callInnerEnd, Separators.InnerContextEnd.ToString(), StringComparison.Ordinal));
        Trace.Assert(string.Equals(callInnerEnd, Separators.CallEnd.ToString(), StringComparison.Ordinal));

        // Modified version of Shunting Yard algorithm
        Queue<LexingToken> outputQueue = new();
        Stack<LexingToken> operatorStack = new();

        foreach (LexingToken token in scope.Functions[functionName])
        {
            switch (token.Type)
            {
                case LexingType.Literal:
                    outputQueue.Enqueue(token);
                    break;
                case LexingType.Identifier:
                    operatorStack.Push(token);
                    break;
                case LexingType.Operator:
                    LexingToken operatorToken1 = token;
                    while (operatorStack.TryPeek(out LexingToken? lt))
                    {
                        if (lt.Type == LexingType.Separator && lt.Value == callInnerStart)
                            break;
                        Trace.Assert(lt.Type == LexingType.Operator);

                        LexingToken operatorToken2 = lt;

                        CflatOperator[] operators1 = LanguageData.Operators.Where(o => o.Name == operatorToken1.Value).ToArray();
                        Trace.Assert(operators1.Length == 1);

                        CflatOperator[] operators2 = LanguageData.Operators.Where(o => o.Name == operatorToken2.Value).ToArray();
                        Trace.Assert(operators2.Length == 1);

                        CflatOperator op1 = operators1[0];
                        CflatOperator op2 = operators2[0];

                        if (op1.Precedence < op2.Precedence)
                            break;
                        if (op1.Precedence == op2.Precedence && op1.Associativity != OperatorAssociativity.Left)
                            break;

                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                    break;
                case LexingType.Separator when token.Value == callInnerStart || token.Value == callInnerEnd:
                    if (token.Value == callInnerStart)
                    {
                        operatorStack.Push(token);
                    }
                    else
                    {
                        Debug.Assert(token.Value == callInnerEnd);

                        while (operatorStack.Peek().Type != LexingType.Separator || operatorStack.Peek().Value != callInnerStart)
                        {
                            outputQueue.Enqueue(operatorStack.Pop());
                            if (operatorStack.Count < 1)
                                throw new CflatException("Mismatched parentheses");
                        }

                        LexingToken leftParenthesis = operatorStack.Pop();
                        if (leftParenthesis.Type != LexingType.Separator || leftParenthesis.Value != callInnerStart)
                            throw new CflatException($"Expected left parenthesis, but received '{leftParenthesis.Value}'");
                        // Parenthesis are discarded

                        if (operatorStack.TryPeek(out LexingToken? lt) && lt.Type == LexingType.Identifier)
                            outputQueue.Enqueue(operatorStack.Pop());
                    }
                    break;
            }
        }

        while (operatorStack.TryPop(out LexingToken? lt))
        {
            if (lt.Type == LexingType.Separator && (lt.Value == callInnerStart || lt.Value == callInnerEnd))
                throw new CflatException("Mismatched parentheses");

            outputQueue.Enqueue(lt);
        }

        return outputQueue;
    }

    internal void Evaluate(ref ParsingContext context)
    {
        foreach (string functionName in context.Scope.Functions)
        {
            _ = EvaluateSingleFunction(functionName, ref context);
            throw new NotImplementedException();
        }
    }
}
