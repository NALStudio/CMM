using CMM.Lang;
using CMM.Models.Lang;
using CMM.Models.Lang.Features;
using CMM.Models.Parsing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Core;

public class ShuntingYard
{
    public IEnumerable<AbstractNode> Evaluate(IEnumerable<AbstractNode> infixTokens)
    {
        Queue<AbstractNode> outputQueue = new();
        Stack<AbstractNode> operatorStack = new();

        foreach (AbstractNode token in infixTokens)
        {
            switch (token.Type)
            {
                case AbstractType.Number:
                    outputQueue.Enqueue(token);
                    break;
                case AbstractType.Keyword:
                    throw new ArgumentException("CMM expressions should not contain keywords!");
                case AbstractType.Operation:
                    CMM_Operation o1 = (CMM_Operation)(token.Feature ?? throw new ArgumentException("Null feature in token."));
                    while (operatorStack.TryPeek(out AbstractNode? mt))
                    {
                        if (mt.Feature is CMM_ControlChar p && p.Name == ControlChars.CallStart.ToString())
                            break;
                        if (mt.Feature is not CMM_Operation o2)
                            throw new Exception("Found a non-operator inside operatorStack");
                        if (o2.Precedence < o1.Precedence)
                            break;
                        if (o2.Precedence == o1.Precedence && o1.Associativity != OperatorAssociativity.Left)
                            break;

                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                    break;
                case AbstractType.ControlChar:
                    CMM_ControlChar parenthesis = (CMM_ControlChar)(token.Feature ?? throw new ArgumentException("Null feature in token."));
                    if (parenthesis.Name == ControlChars.CallStart.ToString())
                    {
                        operatorStack.Push(token);
                    }
                    else if (parenthesis.Name == ControlChars.CallEnd.ToString())
                    {
                        while (operatorStack.Peek().Feature is not CMM_ControlChar p || p.Name != ControlChars.CallStart.ToString())
                        {
                            outputQueue.Enqueue(operatorStack.Pop());
                            if (operatorStack.Count < 1)
                                throw new ArgumentException("Mismatched parentheses");
                        }

                        AbstractNode leftParenthesis = operatorStack.Pop();
                        if (leftParenthesis.Feature is not CMM_ControlChar _p || _p.Name != ControlChars.CallStart.ToString())
                            throw new ArgumentException($"Expected left parenthesis, but received {Enum.GetName(leftParenthesis.Type)}");
                        // Parenthesis are discarded

                        if (operatorStack.TryPeek(out AbstractNode? mt) && mt.Type == AbstractType.Name) // Originally: mt.Type == TokenType.Function   Does this change break the logic?
                            outputQueue.Enqueue(operatorStack.Pop());
                    }
                    else
                    {
                        throw new ArgumentException($"Unexpected control char: '{parenthesis.Name}'");
                    }
                    break;
            }
        }

        while (operatorStack.TryPop(out AbstractNode? mt))
        {
            if (mt.Feature is CMM_ControlChar p && (p.Name == ControlChars.CallStart.ToString() || p.Name == ControlChars.CallEnd.ToString()))
                throw new ArgumentException("Mismatched parentheses");

            outputQueue.Enqueue(mt);
        }

        return outputQueue;
    }
}
