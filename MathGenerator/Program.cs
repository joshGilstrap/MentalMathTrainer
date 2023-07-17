﻿using System.Diagnostics;

namespace MathGenerator
{
    internal class Program
    {
        static int NUM_QUESTIONS = 5;
        static void Main(string[] args)
        {
            Problem problem = new Problem();
            Stopwatch sw = new Stopwatch();
            float[] times = new float[NUM_QUESTIONS];
            string[] allProblems = new string[NUM_QUESTIONS];
            string[] userAnswers = new string[NUM_QUESTIONS];

            int userInput = 0;
            int currentAnswer;
            int correctCounter = 0;

            //WIP
            /*Console.SetWindowSize(Console.LargestWindowWidth / 3, Console.LargestWindowHeight / 3);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.MoveBufferArea(Console.WindowLeft,\ Console.WindowTop, Console.WindowWidth, Console.WindowHeight, 0, 0);
            Console.SetWindowPosition(0, 0);*/

            PrintIntro();
            Console.ReadKey();
            // Game loop
            for(int count = 0; count < NUM_QUESTIONS; count++)
            {
                // Display problem
                Prompt(problem);
                sw.Restart();
                // Validate input, reference userInput
                while(!GetUserAnswer(ref userInput))
                {
                    sw.Stop();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.WindowHeight / 2);
                    Console.Write("Invalid input!");
                    Thread.Sleep(1000);
                    Prompt(problem);
                    sw.Start();
                }
                sw.Stop();
                times[count] = (float)(sw.ElapsedMilliseconds / 1000.0f);

                currentAnswer = problem.GetAnswer();
                if(userInput == currentAnswer)
                {
                    correctCounter++;
                }
                allProblems[count] = problem.GetProblem() + problem.GetAnswer().ToString();
                userAnswers[count] = userInput.ToString();

                if((count + 1) % 5 == 0 && FindAverageTime(times) < 5.0f)
                {
                    problem.IncreaseDifficulty();
                }
                problem = new Problem();
            }

            WriteEndMessage(correctCounter, times, allProblems, userAnswers);
        }

        // Print permanent message centered at the top of the window
        static void PrintIntro()
        {
            string[,] introBlock = {
                {"----------------------------"},
                {"Welcome to the Math Trainer!"},
                {"----------------------------"},
                {"Exercise your mental math skills."},
                {"You're timed on each question."},
                {"----------------------------"},
                {"Current number of questions: " + NUM_QUESTIONS}
            };
            for(int count = 0; count < introBlock.GetLength(0); count++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - (introBlock[count,0].Length / 2), Console.WindowTop + count + 10);
                Console.Write(introBlock[count,0]);
            }
        }

        // Validate user input, simultaneously save input upon success
        static bool GetUserAnswer(ref int userAnswer)
        {
            bool validInput = false;
            if (Int32.TryParse(Console.ReadLine(), out userAnswer))
            {
                validInput = true;
            }
            return validInput;
        }

        // Clear screen and reprint everything with current problem
        static void Prompt(Problem problem)
        {
            Console.Clear();
            PrintIntro();
            Console.SetCursorPosition(Console.WindowWidth / 2 - (problem.GetProblem().Length / 2), Console.WindowHeight / 2);
            Console.Write(problem.GetProblem());
        }

        // Write out how many correct answers were recorded
        static void WriteEndMessage(int counter, float[] times, string[] problems, string[] answers)
        {
            string[,] endBlock = new string[NUM_QUESTIONS + 2, 1];
            endBlock[0, 0] = "You got " + counter + " out of " + NUM_QUESTIONS;

            int longestStringIndex = 0;
            for(int count = 0; count < NUM_QUESTIONS; count++)
            {
                endBlock[count + 1,0] = "Question " + (count + 1) + ": " + problems[count] + " | "
                    + "Your answer: " + answers[count] + " | Seconds to answer entry: " + times[count];
                if (endBlock[count + 1, 0].Length > endBlock[longestStringIndex, 0].Length)
                {
                    longestStringIndex = count + 1;
                }
            }

            float average = FindAverageTime(times);
            endBlock[endBlock.GetLength(0) - 1, 0] = "Average time per question in seconds: " + Math.Round(average,3);

            Console.Clear();
            for(int count = 0; count < endBlock.GetLength(0); count++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - (endBlock[longestStringIndex, 0].Length / 2),
                    Console.WindowHeight / 2 - (endBlock.GetLength(0) / 2) + count);
                Console.WriteLine(endBlock[count, 0]);
            }
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.ReadKey();

        }
        static float FindAverageTime(float[] times)
        {
            float average = 0.0f;
            for (int count = 0; count < times.Length; count++)
            {
                average += times[count];
            }
            average /= times.Length;
            return average;
        }
    }
}