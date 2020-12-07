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
            //checking edge cases
             //top left 
             if(col == 0 && row == 0)
            {
                int totalN = grid[col + 1, row] + grid[col, row + 1] + grid[col + 1, row + 1];
                return totalN;
            }
            //bottom left 
           else if(col == 0 && row == grid.GetLength(1) - 1)
            {
                int totalN = grid[col + 1, row] + grid[col, row - 1] + grid[col + 1, row - 1];
                return totalN;
            }
            //top right 
           else  if(col == grid.GetLength(0) - 1 && row == 0)
            {
                int totalN = grid[col - 1, row] + grid[col - 1, row + 1] + grid[col, row + 1];
                return totalN;
            }
            //bottom right 
           else if(col == grid.GetLength(0) - 1 && row == grid.GetLength(1) - 1)
            {
                int totalN = grid[col - 1, row] + grid[col - 1, row - 1] + grid[col, row - 1];
                return totalN;
            }
            //end of check
            else
            {
                if (col - 1 < 0)
                {
                    int totalN = 0;
                    for (int i = col; i < 2; i++)
                    {
                        for (int ix = row - 1; ix < 3; ix++)
                        {
                            totalN += grid[i, ix];
                        }
                    }
                    totalN -= grid[col, row];
                    return totalN;
                }
                else if (row - 1 < 0)
                {
                    int totalN = 0;
                    for (int i = col; i < 3; i++)
                    {
                        for (int ix = row; ix < 2; ix++)
                        {
                            totalN += grid[i, ix];
                        }
                    }
                    totalN -= grid[col, row];
                    return totalN;
                }
                else
                {
                    int total = 0;
                    for (int i = col - 1; i < 3; i++)
                    {
                        for (int ix = row - 1; ix < 3; ix++)
                        {
                            total += grid[i, ix];
                        }
                    }
                    total -= grid[col, row];
                    return total;
                }
             
            }

        }

        public static int[,] createNextGen(int[,] board)
        {
            int[,] copy = board;
            for (int i = 0; i < board.GetLength(0) - 1; i++)
            {
                for (int ix = 0; ix < board.GetLength(1) - 1; ix++)
                {
                    copy[i, ix] = changeState(countNeighbors(board, i, ix));

                }
            }
            return copy;

        }

        public static int changeState(int neighbors)
        {
        if(neighbors ==2 || neighbors == 3)
            {
                return 1;
            }
        else
            {
                return 0;
            }
        }
    }
}
