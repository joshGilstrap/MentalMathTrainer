namespace MathGenerator
{
    internal class Program
    {
        static int NUM_QUESTIONS = 5;
        static void Main(string[] args)
        {
            Problem problem = new Problem();
            PrintIntro();
            int userInput = 0;
            int currentAnswer;
            int correctCounter = 0;

            // Game loop
            for(int count = 0; count < NUM_QUESTIONS; count++)
            {
                // Display problem
                Prompt(problem);
                // Vallidate input, reference userInput
                while(!GetUserAnswer(ref userInput))
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.WindowHeight / 2);
                    Console.Write("Invalid input!");
                    Thread.Sleep(1000);
                    Prompt(problem);
                }

                currentAnswer = problem.GetAnswer();
                if(userInput == currentAnswer)
                {
                    correctCounter++;
                }

                problem = new Problem();
            }

            WriteEndMessage(correctCounter);
        }

        // Print permanent message centered at the top of the window
        static void PrintIntro()
        {
            string[,] introBlock = {
                {"----------------------------"},
                {"Welcome to the Math Trainer!"},
                {"----------------------------"},
                {"Exercise your mental math skills."}
            };
            for(int count = 0; count < introBlock.GetLength(0); count++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - (introBlock[count,0].Length / 2), Console.WindowTop + count);
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
            Console.SetCursorPosition(Console.WindowWidth / 2 - (problem.GetProblem().Length / 2), Console.WindowTop + 5);
            Console.Write(problem.GetProblem());
        }

        // Write out how many correct answers were recorded
        static void WriteEndMessage(int counter)
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2);
            Console.WriteLine("You got " + counter + " out of " + NUM_QUESTIONS);
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.ReadKey();
        }
    }
}