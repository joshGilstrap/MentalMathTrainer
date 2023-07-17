# Mental Math Trainer - A C# console game aimed at sharpening mental math skills
The user is timed on each question that's made up of basic arithmetic (+, -, *, /). There are 25 questions, each made up of two random operands and a random operation.
  - Each operand has equal possibility to be any number in the range of a difficulty-defined maximum (-/+)
  - Operand 2 is never 0
  - Operation is randomlly chosen from an array of chars

Difficulty algorithm: difficulty is checked every fifth question and will increase the operand size by some amount if the users' average total perfomance is less than 5 seconds a question. Maxes out at 100.

<img width="653" alt="Screenshot 2023-07-17 153156" src="https://github.com/joshGilstrap/MentalMathTrainer/assets/5957735/58e77e45-1ac7-43b9-a9c1-b61835f70099">

Program.cs - The main driver of the program, look here for formatting and driving code

Problem.cs - Problem class, creates everything about a generated question, also controls 

The motivation behind this program is to aid math education and will continue to grow in that direction. A big roadblock in a lot of complex math classes is the added time necessary to perform arithmetic on paper or with a calculator. Learning mental math tricks and practicing is the way to get past the block which will allow for a more enjoyable learning process for 
