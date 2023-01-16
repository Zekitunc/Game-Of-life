using System;

namespace OOP_porject2_Game_Of_Life
{
    class Project 
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            while (true)
            {
                Console.WriteLine("Enter a command (start, save, load, or exit): ");
                string command = Console.ReadLine().ToLower();
                if (command == "start")
                {
                    game.Start();
                }
                else if (command == "save")
                {
                    Console.WriteLine("Enter a file name: ");
                    string fileName = Console.ReadLine();
                    game.Save();
                }
                else if (command == "load")
                {
                    Console.WriteLine("Enter a file name: ");
                    string fileName = Console.ReadLine();
                    game.Load();
                }
                else if (command == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }
            }
        }
    }
}