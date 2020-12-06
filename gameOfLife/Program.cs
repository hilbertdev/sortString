using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = createBoard(0, 0);
            int [,] popBoard = populateBoard(board);
            int[,] vs = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            int liveNeighborsCount = countNeighbors(vs, 2, 2);
            Console.WriteLine(liveNeighborsCount);
            Console.ReadLine();
        }
        public static int[,] createBoard(int length, int width)
        {
            if (length == 0 || width == 0)
            {
                int[,] defaultBoard = new int[5, 5];
                return defaultBoard;
            }
            else
            {
                int[,] board = new int[length, width];
                return board;
            }

        }

        public static int[,] populateBoard(int[,] board)
        {
            Random states = new Random();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int ix = 0; ix < board.GetLength(1); ix++)
                {
                    board[i, ix] = states.Next(0, 2);
                }
            }
            return board;
        }
        public static int countNeighbors(int[,] grid, int col, int row)
        {
            int total = 0;
            for (int i = col - 1; i < 2; i++)
            {
                for (int ix = row - 1; row < 2; ix++)
                {
                    total += grid[i, ix];
                }
            }
            total -= grid[col, row];
            return total;
        }
    }
}
