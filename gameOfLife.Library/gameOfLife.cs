using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife.Library
{
    public class gameOfLife
    {
        public static int[,] createBoard(int length, int width)
        {
            Random states = new Random();
            int[,] board;

            if (length == 0 || width == 0)
            {
                  board = new int[5, 5];
            }
            else
            {
               board = new int[length, width];
            }

         
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int ix = 0; ix < board.GetLength(1); ix++)
                {
                    board[i, ix] = states.Next(0, 2);
                }
            }
            return board;

        }

        public static bool checkPopulatation(int[,] board)
        {
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for(int ix = 0; ix < board.GetLength(1); ix++)
                {
                    if(board[i, ix] == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public static int countNeighbors(int[,] grid, int col, int row)
        {
            int total = 0;
            for(int i = col -1; i < 2; i++)
            {
                for(int ix = row - 1; row < 2; i++)
                {
                    total += grid[i, ix];
                }
            }
            total -= grid[col, row];
            return total;
        }
        
    }
}
