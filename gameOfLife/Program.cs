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
            Console.WriteLine("Please enter number of rows");
            int row = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Please enter number of cols");
            int col = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Please enter number of generations");
            int generations = Convert.ToInt32(Console.ReadLine());
            int[,] board = createBoard(row, col);
            int [,] popBoard = populateBoard(board);
            Console.WriteLine("First Generation");
            Print2DGen(popBoard);
            for(int i = 2; i < generations + 1; i++){
                string gen = string.Format("This is generation number {0}", i);
                Console.WriteLine(gen);
                int[,] newBoard = createNextGen(popBoard);
                Print2DGen(newBoard);
                popBoard = newBoard;
            }
            Console.ReadLine();
            
        }
        public static void Print2DGen<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
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
        public static int countNeighbors(int[,] grid, int row, int col)
        {
            //checking edge cases
            //top left 
            if (col == 0 && row == 0)
            {
                int totalN = grid[row,col + 1] + grid[row + 1,col ] + grid[row + 1,col + 1 ];
                return totalN;
            }
            //bottom left 
            else if (col == 0 && row == grid.GetLength(1) - 1)
            {
                int totalN = grid[row,col + 1] + grid[row - 1,col] + grid[row - 1,col + 1];
                return totalN;
            }
            //top right 
            else if (col == grid.GetLength(0) - 1 && row == 0)
            {
                int totalN = grid[row,col - 1] + grid[row + 1, col - 1] + grid[row + 1,col];
                return totalN;
            }
            //bottom right 
            else if (col == grid.GetLength(0) - 1 && row == grid.GetLength(1) - 1)
            {
                int totalN = grid[row,col - 1] + grid[row - 1,col - 1] + grid[row - 1,col ];
                return totalN;
            }
            //end of check
            else
            {
                if (col - 1 < 0)
                {
                    int totalN = 0;
                    int startPos = row - 1;
                    int endPos = row +1;
                    for (int i = col; i < 2; i++)
                    {
                        for (int ix = startPos; ix < endPos; ix++)
                        {
                            totalN += grid[ix, i];
                        }
                    }
                    totalN -= grid[row, col];
                    return totalN;
                }
                else if (row - 1 < 0)
                {
                    int totalN = 0;
                    int startPos = col - 1;
                    int endPos = col + 1;
                    for (int i = startPos; i < endPos; i++)
                    {
                        for (int ix = row; ix < 2; ix++)
                        {
                            totalN += grid[ix, i];
                        }
                    }
                    totalN -= grid[row, col];
                    return totalN;
                }
                else
                {
                    int total = 0;
                    int startPos = col - 1;
                    int endPos = col + 1;
                    for (int i = startPos; i < endPos; i++)
                    {
                        for (int ix = row - 1; ix < row + 1; ix++)
                        {
                            total += grid[ix, i];
                        }
                    }
                    total -= grid[row, col];
                    return total;
                }

            }

        }
        public static int[,] createNextGen(int[,] board)
        {
            int[,] copy = new int [board.GetLength(0),board.GetLength(1)];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int ix = 0; ix < board.GetLength(1); ix++)
                {
                    copy[i, ix] = changeState(countNeighbors(board, i, ix));

                }
            }
            ;
            return copy;

        }

        public static int changeState(int neighbors)
        {
            if (neighbors == 2 || neighbors == 3)
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
