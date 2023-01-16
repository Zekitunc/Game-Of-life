using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OOP_porject2_Game_Of_Life
{
    class Game
    {
        public Generation CurrentGeneration { get; set; }

        const string Path = @"C:\Users\Cansu\Desktop\OOP porject2 Game Of Life\OOP porject2 Game Of Life\saver.txt";
        public void Start()
        {
            // Read input from the user and initialize the game
            Console.WriteLine("Enter the number of rows: ");
            int rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of columns: ");
            int cols = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of living cells or density (%percentage): ");
            string input = Console.ReadLine();
            if (input[0]=='%')
            {
                
                double density = Convert.ToDouble(input.Substring(1,input.Length-1));
                CurrentGeneration = new Generation(rows, cols, density);
            }
            else
            {
                int numLivingCells = int.Parse(input);
                CurrentGeneration = new Generation(rows, cols, numLivingCells);
            }

            while (true)
            {
                // Display the current generation
                Console.WriteLine(CurrentGeneration);

                // Read input from the user
                Console.WriteLine("Enter the number of steps to simulate: ");
                Console.WriteLine("if you want to stop please write 0");
                int numSteps = int.Parse(Console.ReadLine());

                if (numSteps == 0)
                    break;

                // Generate the next generation
                Generation nextGeneration = CurrentGeneration.GenerateNextGeneration(numSteps);

                // Check if the game has reached a stable state
                if (nextGeneration == CurrentGeneration)
                {
                    Console.WriteLine("The game has reached a stable state.");
                    break;
                }
                CurrentGeneration = nextGeneration;
            }
        }

        public void Save()
        {
            using (StreamWriter sw = new StreamWriter(Path))
            {
                sw.Write(CurrentGeneration.ToString());
            }
        }

        public void Load()
        {
            using (StreamReader sr = new StreamReader(Path))
            {
                string boardString = sr.ReadToEnd();
                int rows = boardString.Count(c => c == '\n');
                int cols = boardString.IndexOf('\n') - 1;
                CurrentGeneration = new Generation(rows, cols, boardString);
            }

            while (true)
            {
                // Display the current generation
                Console.WriteLine(CurrentGeneration);

                // Read input from the user
                Console.WriteLine("Enter the number of steps to simulate: ");
                Console.WriteLine("if you want to stop please write 0");
                int numSteps = int.Parse(Console.ReadLine());

                if (numSteps == 0)
                    break;

                // Generate the next generation
                Generation nextGeneration = CurrentGeneration.GenerateNextGeneration(numSteps);

                // Check if the game has reached a stable state
                if (nextGeneration == CurrentGeneration)
                {
                    Console.WriteLine("The game has reached a stable state.");
                    break;
                }
                CurrentGeneration = nextGeneration;
            }
        }
    }
}
