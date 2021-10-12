using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesLadders
{
    public class Game
    {
        public Cell[] board;
        public Player[] players;
        public int winningPosition;

        //Create game - new board & players
        public Game(int boardSize, int numberPlayers)
        {
            board = CreateBoard(boardSize);
            players = CreatePlayers(numberPlayers);
            
        }

        private Cell[] CreateBoard(int cells)
        {
            Cell[] board = new Cell[cells];
            for (int i = 0; i <cells; i++)
            {
                Cell c = new Cell();
                c.CellNumber = i + 1;
                board[i] = c;
            }

            return board;
        }
        
        private Player[] CreatePlayers(int numberPlayers)
        {
            Player[] players = new Player[numberPlayers];
            for (int i = 0; i < numberPlayers; i++)
            {
                Player p = new Player();
                p.PlayerNumber = i + 1;
                players[i] = p;
            }

            return players;
        }

        public void Play()
        {
            while (winningPosition < board.Length)
            {
                foreach (var player in players)
                {
                    //Roll dice
                    int roll = RollDice();

                    //Move Player & calculate position
                    MovePlayer(roll, player);

                    if (player.CurrentPosition < board.Length)
                    {
                        Console.WriteLine("Player: " + player.PlayerNumber + ", New position: " + player.CurrentPosition);
                    }
                    else
                    {
                        Console.WriteLine("Player: " + player.PlayerNumber + " IS THE WINNER");
                        break;
                    }
                }
            }

        }

        private int RollDice()
        {
            Random rnd = new Random();
            return rnd.Next(1, 6);
        }

        private void MovePlayer(int dice, Player player)
        {
            int newCellPosition = player.CurrentPosition + dice;
            player.CurrentPosition = newCellPosition;
            if (newCellPosition > winningPosition)
            {
                winningPosition = newCellPosition;
            }
        }
    }
}
