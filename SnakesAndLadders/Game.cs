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
            for (int i = 0; i < cells; i++)
            {
                Cell c = new Cell();
                c.CellNumber = i + 1;
                board[i] = c;
            }

            CreateSnakes(board);
            CreateLadders(board);
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

        private void CreateSnakes(Cell[] board)
        {
            Console.Write("How many snakes?");
            int snakes = int.Parse(Console.ReadLine());

            for (int i = 0; i < snakes; i++)
            {
                Console.WriteLine("Snake head cell?");
                int snakeHead = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Snake tail cell?");
                int snakeTail = Int32.Parse(Console.ReadLine());

                SnakeCell snake = new SnakeCell();
                snake.CellNumber = snakeHead;
                snake.BackToCell = snakeTail;

                board[snakeHead] = snake;
            }
        }


        private void CreateLadders(Cell[] board)
        {
            Console.Write("How many ladders?");
            int ladders = int.Parse(Console.ReadLine());

            for (int i = 0; i < ladders; i++)
            {
                Console.WriteLine("Ladder bottom cell?");
                int ladderBottom = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Ladder top cell?");
                int ladderTop = Int32.Parse(Console.ReadLine());

                LadderCell ladder = new LadderCell();
                ladder.CellNumber = ladderBottom;
                ladder.GoToCell = ladderTop;
                board[ladderBottom] = ladder;

            }
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

            if (newCellPosition < board.Length)
            {
                //Check if snake or ladder, move accordingly
                if (isSnakeCell(newCellPosition))
                {
                    newCellPosition = (board[newCellPosition] as SnakeCell).BackToCell;
                    Console.WriteLine("Landed on a snake.........");
                }
                if (isLadderCell(newCellPosition))
                {
                    newCellPosition = (board[newCellPosition] as LadderCell).GoToCell;
                    Console.WriteLine("Landed on a ladder.........");
                }
            }
            player.CurrentPosition = newCellPosition;

            if (newCellPosition > winningPosition)
            {
                winningPosition = newCellPosition;
            }
        }

        private bool isSnakeCell(int cellPosition)
        {
            return (board[cellPosition].GetType() == typeof(SnakeCell));
        }

        private bool isLadderCell(int cellPosition)
        {
            return (board[cellPosition].GetType() == typeof(LadderCell));
        }
    }
}
