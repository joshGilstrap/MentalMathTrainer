using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGenerator
{
    public class Problem
    {
        static int currentDifficulty;
        static char[] operations = { '+', '-', '*', '/', '%' };

        Random random = new Random();
        int operandLeft;
        int operandRight;
        char operation;
        int answer;
        string problem;

        public Problem()
        {
            MakeProblem();
        }

        public string GetProblem()
        {
            return problem;
        }
        
        public int GetAnswer()
        {
            return answer;
        }
        
        private void MakeProblem()
        {
            // Find the highest number possible
            int topEnd = GetTopEnd();

            // Assign left operand
            operandLeft = MakeOperand(topEnd);
            
            // Randomly add "difficulty"
            if(random.Next() % 5 == 0)
            {
                topEnd += 10;
            }
            
            // Choose an operation at random
            ChooseOperation();
            
            // Prevent division by 0
            operandRight = MakeOperand(topEnd);
            if (operandRight == 0)
            {
                operandRight += random.Next(1, 10);
            }
            
            // Solve problem and save answer
            SolveProblem();
            
            // Build printable problem
            BuildString();
        }

        // Intended to simulate difficulty.
        // Theory: Bigger number = harder problem
        private int GetTopEnd()
        {
            int topEnd = 0;
            switch (currentDifficulty)
            {
                case 0:
                    topEnd = 10;
                    break;
                case 1:
                    topEnd = 20;
                    break;
                case 2:
                    topEnd = 30;
                    break;
                case 3:
                    topEnd = 50;
                    break;
                case 4:
                    topEnd = 100;
                    break;

            }
            return topEnd;
        }
        
        // Randomlly choose an operand
        private int MakeOperand(int topEnd)
        {
            return random.Next(-topEnd, topEnd);
        }

        // Radnomlly choose an operation
        private void ChooseOperation()
        {
            operation =  operations[random.Next(operations.Length)];
        }

        // Build printable problem
        private void BuildString()
        {
            problem = operandLeft + " " + operation + " " + operandRight + " = ";
        }

        // Save answer to problem
        private void SolveProblem()
        {
            switch (operation)
            {
                case '+':
                    answer = operandLeft + operandRight;
                    break;
                case '-':
                    answer = operandLeft - operandRight;
                    break;
                case '*':
                    answer = operandLeft * operandRight;
                    break;
                case '/':
                    answer = operandLeft / operandRight;
                    break;
                case '%':
                    answer = operandLeft % operandRight;
                    break;

            }
        }
    }
}
