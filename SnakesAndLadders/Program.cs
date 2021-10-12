using System;

namespace SnakesLadders
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Snakes & Ladders");

            //Configure Board
            Console.WriteLine("Board Size");
            Console.WriteLine("How many cells?");
            int cells = Int32.Parse(Console.ReadLine());

            //Number of players
            Console.WriteLine("Players");
            Console.WriteLine("How many players?");
            int players = Int32.Parse(Console.ReadLine());

            Game game = new Game(cells, players);

        }

       
    }
}
