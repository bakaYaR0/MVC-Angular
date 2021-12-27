using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace TheBomberManGame
{
    /// <summary>
    /// Big thanks to https://github.com/soo-toance for the original solution!
    /// </summary>
    public class TheBomberManGame
    {
        public static List<string> bomberMan(int n, List<string> grid)
        {
            if (n % 2 == 0)
                return plantBombAll(grid);

            else
            {
                if (n == 1)
                {
                    return grid;
                }
                else if (n % 4 == 3)
                {
                    detonateBomb(grid);
                }
                else if (n % 4 == 1)
                {
                    detonateBomb(grid);
                    detonateBomb(grid);
                }
            }
            return grid;
        }

        public static List<string> plantBombAll(List<string> grid)
        {
            for (int row = 0; row < grid.Count; row++)
            {
                grid[row] = grid[row].Replace('.', 'O');
            }
            return grid;
        }

        public static void detonateBomb(List<string> grid)
        {
            plantBomb(grid);
            explodeBomb(grid);
            cleanBomb(grid);
        }

        private static void plantBomb(List<string> grid)
        {
            for (int row = 0; row < grid.Count; row++)
            {
                grid[row] = grid[row].Replace('.', 'x');
            }
        }

        public static void cleanBomb(List<string> grid)
        {
            for (int row = 0; row < grid.Count; row++)
            {
                grid[row] = grid[row].Replace('x', 'O');
            }
        }

        private static void explodeBomb(List<string> grid)
        {
            for (int row = 0; row < grid.Count; row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    if (grid[row][col] == 'O')
                    {
                        grid[row] = ReplaceAt(grid[row], col, '.');

                        if (row - 1 >= 0 && grid[row - 1][col] == 'x')
                            grid[row - 1] = ReplaceAt(grid[row - 1], col, '.');

                        if (row + 1 <= grid.Count - 1 && grid[row + 1][col] == 'x')
                            grid[row + 1] = ReplaceAt(grid[row + 1], col, '.');

                        if (col - 1 >= 0 && grid[row][col - 1] == 'x')
                            grid[row] = ReplaceAt(grid[row], col - 1, '.');

                        if (col + 1 <= grid[row].Length - 1 && grid[row][col + 1] == 'x')
                            grid[row] = ReplaceAt(grid[row], col + 1, '.');
                    }
                }
            }
        }

        private static string ReplaceAt(string input, int index, char newChar)
        {
            char[] builder = input.ToCharArray();
            builder[index] = newChar;
            return new string(builder);
        }
    }
}
