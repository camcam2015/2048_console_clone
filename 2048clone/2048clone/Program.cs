using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*  todo: create boolean to check if any #s were moved
 *  if so, add random #
 * 
 * 
 * 
 * 
 */

namespace _2048clone
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            bool run = true;
            bool loss = false;
            ConsoleKeyInfo keypress;

            //creating board
            int[,] grid = new int[4, 4];

            //allocating to array
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    grid[i, j] = 0;
                }
            }
            DrawGrid(grid);

            Console.WriteLine("Press Enter to start:");
            Console.ReadLine();

            AssignStartValue(grid);
            DrawGrid(grid);

            /*
             * 
             * 
             * MAIN GAME LOOP
             * 
             * 
             */

            do
            {
                keypress = Console.ReadKey();
                bool moved = false;
                switch (keypress.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.Write("UP");

                        for (int i = 1; i <= 3; i++)
                            for (int j = 0; j <= 3; j++)
                            {
                                int emptyInt = 0;
                                int iUpdated = 0;

                                // This if statement is neccesary to only check if the positions of NON-ZERO values need to be updated
                                if (grid[i, j] != 0)
                                {
                                    // check for zeros above current cell
                                    if (grid[i - 1, j] == 0)
                                    {
                                        moved = true;

                                        //determine how many more zeros are above it and move to furthest location
                                        for (int a = i; a > 0; a--)
                                        {
                                            if (grid[a - 1, j] == 0)
                                            {
                                                emptyInt++;
                                            }
                                        }

                                        int temp = grid[i, j];
                                        grid[i - emptyInt, j] = temp;
                                        grid[i, j] = 0;
                                    }

                                    // check for non zeros above updated (or not updated) position, update value if needed
                                    iUpdated = i - emptyInt;
                                    if (iUpdated != 0)
                                    {
                                        if (grid[iUpdated - 1, j] == grid[iUpdated, j])
                                        {
                                            moved = true;

                                            grid[iUpdated - 1, j] = grid[iUpdated, j] * 2;
                                            grid[iUpdated, j] = 0;
                                        }
                                    }
                                }

                                
                            }

                        DrawGrid(grid);
                        break;

                    case ConsoleKey.DownArrow:
                        Console.Write("DOWN");

                        for (int i = 2; i >= 0; i--)
                            for (int j = 0; j <= 3; j++)
                            {
                                int emptyInt = 0;
                                int iUpdated = 0;

                                // This if statement is neccesary to only check if the positions of NON-ZERO values need to be updated
                                if (grid[i, j] != 0)
                                {
                                    // check for zeros below
                                    if (grid[i + 1, j] == 0)
                                    {
                                        moved = true;

                                        //determine how many more zeros are below it and move to furthest location
                                        for (int a = i; a < 3; a++)
                                        {
                                            if (grid[a + 1, j] == 0)
                                            {
                                                emptyInt++;
                                            }
                                        }

                                        int temp = grid[i, j];
                                        grid[i + emptyInt, j] = temp;
                                        grid[i, j] = 0;
                                    }

                                    // check for non zeros below updated position, update if needed
                                    iUpdated = i + emptyInt;
                                    if (iUpdated != 3)
                                    {
                                        if (grid[iUpdated + 1, j] == grid[iUpdated, j])
                                        {
                                            moved = true;

                                            grid[iUpdated + 1, j] = grid[iUpdated, j] * 2;
                                            grid[iUpdated, j] = 0;
                                        }
                                    }
                                }
                            }
                        
                        DrawGrid(grid);
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.Write("LEFT");

                        for (int i = 0; i <= 3; i++)
                            for (int j = 1; j <= 3; j++)
                            {
                                int emptyInt = 0;
                                int jUpdated = 0;

                                // This if statement is neccesary to only check if the positions of NON-ZERO values need to be updated
                                if (grid[i, j] != 0)
                                {
                                    // check for zeros left
                                    if (grid[i, j - 1] == 0)
                                    {
                                        moved = true;

                                        //determine how many more zeros are to the left of it and move to furthest location
                                        for (int a = j; a > 0; a--)
                                        {
                                            if (grid[i, a - 1] == 0)
                                            {
                                                emptyInt++;
                                            }
                                        }

                                        int temp = grid[i, j];
                                        grid[i, j - emptyInt] = temp;
                                        grid[i, j] = 0;
                                    }

                                    // check for non zeros to the left of updated position, update if needed
                                    jUpdated = j - emptyInt;
                                    if (jUpdated != 0)
                                    {
                                        if (grid[i, jUpdated - 1] == grid[i, jUpdated])
                                        {
                                            moved = true;

                                            grid[i, jUpdated - 1] = grid[i, jUpdated] * 2;
                                            grid[i, jUpdated] = 0;
                                        }
                                    }
                                }
                            }

                        DrawGrid(grid);
                        break;
                    case ConsoleKey.RightArrow:
                        Console.Write("RIGHT");

                        for (int i = 0; i <= 3; i++)
                            for (int j = 2; j >= 0; j--)
                            {
                                int emptyInt = 0;
                                int jUpdated = 0;

                                // This if statement is neccesary to only check if the positions of NON-ZERO values need to be updated
                                if (grid[i, j] != 0)
                                {
                                    // check for zeros right
                                    if (grid[i, j + 1] == 0)
                                    {
                                        moved = true;

                                        //determine how many more zeros are to the right of it and move to furthest location
                                        for (int a = j; a < 3; a++)
                                        {
                                            if (grid[i, a + 1] == 0)
                                            {
                                                emptyInt++;
                                            }
                                        }

                                        int temp = grid[i, j];
                                        grid[i, j + emptyInt] = temp;
                                        grid[i, j] = 0;
                                    }

                                    // check for non zeros to the right of updated position, update if needed
                                    jUpdated = j + emptyInt;
                                    if (jUpdated != 3)
                                    {
                                        if (grid[i, jUpdated + 1] == grid[i, jUpdated])
                                        {
                                            moved = true;

                                            grid[i, jUpdated + 1] = grid[i, jUpdated] * 2;
                                            grid[i, jUpdated] = 0;
                                        }
                                    }
                                }
                            }

                        DrawGrid(grid);
                        break;
                    case ConsoleKey.D:
                        /*Used for test cases*/
                        Console.WriteLine("Debugging Mode Activated");
                        while (keypress.Key != ConsoleKey.Escape)
                        {
                            Console.WriteLine("Enter index coords and value of cell:");
                            string debug = Console.ReadLine();

                            if (debug == "")
                            {
                                Console.WriteLine("Debugging Mode Disabled");
                                break;
                            }
                            else
                            {
                                int[] valsInt = new int[3];
                                char delimiter = ',';
                                String[] vals = debug.Split(delimiter);

                                if (vals.Length == 3)
                                {
                                    for (int i = 0; i <= 2; i++)
                                    {
                                        valsInt[i] = Convert.ToInt32(vals[i]);
                                    }
                                    grid[valsInt[0], valsInt[1]] = valsInt[2];

                                    DrawGrid(grid);
                                    Console.WriteLine("Added.");
                                }
                                else { Console.WriteLine("Invalid input."); }
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.WriteLine("Press ESC again to close the window.");
                        Console.WriteLine("Press Enter to resume.");
                        Console.WriteLine("Press R to restart game.");
                        ConsoleKeyInfo pauseKeypress = Console.ReadKey();
                        switch (pauseKeypress.Key)
                        {
                            case ConsoleKey.Escape:
                                Environment.Exit(0);
                                break;
                            case ConsoleKey.Enter:
                                DrawGrid(grid);
                                break;
                            case ConsoleKey.R:
                                ClearGrid(grid);
                                AssignStartValue(grid);
                                DrawGrid(grid);
                                break;
                        }
                        break;
                    

                    default:
                        Console.Write("unspec");
                        break;
                }

                if (moved)
                {
                    PlaceRandomValue(grid);
                    DrawGrid(grid);
                }
                    
                moved = false;

            } while (run);

            Console.ReadLine();
        }

        public static void DrawGrid(int[,] values)
        {
            Console.Clear();

            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    Console.Write("[ {0} ]", values[i, j]);
                }
                Console.WriteLine();
            }

            return;
        }

        public static void AssignStartValue(int[,] grid)
        {
            Random rand = new Random();
            int[] startPosition = new int[4];

            //check if two starting positions are the same
            while (startPosition[0] == startPosition[2] || startPosition[1] == startPosition[3])
            {
                for (int i = 0; i <= 3; i++)
                {
                    startPosition[i] = rand.Next(0, 4);
                }
            }

            grid[startPosition[0], startPosition[1]] = 2;
            grid[startPosition[1], startPosition[3]] = 2;
        }

        public static void PlaceRandomValue(int[,] grid) //needs to be fixed
        {
            Random rand = new Random();
            int[] randPos = new int[2];
            int i = 0;
            int j = 0;

            //determining if new cell is a 2 or 4
            double randVal = rand.NextDouble();
            int randValInt;

            if (randVal < 0.5)
            {
                randValInt = 2;
            }
            else { randValInt = 4; }


            //find random cell, assign 2 or 4 ONLY IF that cell is a zero
            i = rand.Next(0, 3);
            j = rand.Next(0, 3);
            
            do
            {
                i = rand.Next(0, 3);
                j = rand.Next(0, 3);
            } while (grid[i, j] != 0);

            grid[i, j] = randValInt;
        }

        public static void ClearGrid(int[,] grid)
        {
            for (int i = 0; i <= 3; i++)
                for (int j = 0; j <= 3; j++)
                {
                    grid[i, j] = 0;
                }
        }
    }
}
