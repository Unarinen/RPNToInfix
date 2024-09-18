using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter Reverse Polish Notation string:");
        string rpnInput = Console.ReadLine();

        try
        {
            string infixOutput = ConvertRPNToInfix(rpnInput);
            Console.WriteLine("Infix Notation: " + infixOutput);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string ConvertRPNToInfix(string rpn)
    {
        Stack<string> stack = new Stack<string>();
        string[] tokens = rpn.Split(' ');

        foreach (var token in tokens)
        {
            if (IsOperator(token))
            {
                string operand2 = stack.Pop();
                string operand1 = stack.Pop();
                string expression = $"({operand1} {token} {operand2})";
                stack.Push(expression);
            }
            else
            {
                stack.Push(token);
            }
        }

        if (stack.Count != 1)
        {
            throw new InvalidOperationException("Invalid expression.");
        }

        return stack.Pop();
    }

    static bool IsOperator(string token)
    {
        return token == "+" || token == "-" || token == "*" || token == "/";
    }
}
