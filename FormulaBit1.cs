using System;

namespace FormulaBit1
{
    class Program
    {
        static int gridSize = 8;
        static int[,] grid = new int[gridSize, gridSize];
        static int trackLength = 0;
        static int turnsCount = 0;
        static char previousDirection = 'D';
        static bool finished = false;

        static void Main()
        {
            for (int i = 0; i < gridSize; i++)
            {
                int number = int.Parse(Console.ReadLine());
                for (int j = 0; j < gridSize; j++)
                {
                    int mask = 1 << j;
                    int numberAndMask = number & mask;
                    int bit = numberAndMask >> j;
                    grid[i, gridSize - j - 1] = (bit == 1) ? 1 : 0;
                }
            }

            buildTrack(0, 7, 'D');

            if (finished == false)
            {
                Console.WriteLine("No {0}", trackLength);
            }
        }

        static void checkForTrackExit(int row, int column)
        {
            if (row == 7 && column == 0)
            {
                finished = true;
                Console.WriteLine("{0} {1}", trackLength, turnsCount);
            }
        }

        static void buildTrack(int row, int column, char currentDirection)
        {
            if (row < 0 || column < 0 || row >= grid.GetLength(0) || column >= grid.GetLength(1))
            {
                return;
            }

            if (grid[row, column] == 1)
            {
                return;
            }

            switch(currentDirection)
            {
                case 'D':
                    for (int i = row; i < gridSize; i++)
                    {
                        if (grid[i, column] == 0)
                        {
                            trackLength += 1;
                            checkForTrackExit(i, column);
                            if (i == (gridSize - 1))
                            {
                                turnsCount++;
                                previousDirection = 'D';
                                buildTrack(i, column - 1, 'L');
                            }
                            continue;
                        }
                        else
                        {
                            turnsCount++;
                            previousDirection = 'D';
                            buildTrack(i - 1, column - 1, 'L');
                            break;
                        }
                    }
                    break;
                case 'L':
                    for (int i = column; i >= 0; i--)
                    {
                        if (grid[row, i] == 0)
                        {
                            trackLength += 1;
                            checkForTrackExit(row, i);
                            if (i == 0)
                            {
                                if (previousDirection == 'D')
                                {
                                    turnsCount++;
                                    previousDirection = 'L';
                                    buildTrack(row - 1, i, 'U');
                                }
                                else
                                {
                                    turnsCount++;
                                    previousDirection = 'L';
                                    buildTrack(row + 1, i, 'D');
                                }
                            }
                            continue;
                        }
                        else
                        {
                            if (previousDirection == 'U')
                            {
                                turnsCount++;
                                previousDirection = 'L';
                                buildTrack(row + 1, i + 1, 'D');
                                break;
                            }
                            else
                            {
                                turnsCount++;
                                previousDirection = 'L';
                                buildTrack(row - 1, i + 1, 'U');
                                break;
                            }
                        }
                        
                    }
                    break;
                case 'U':
                    for (int i = row; i >= 0; i--)
                    {
                        if (grid[i, column] == 0)
                        {
                            trackLength += 1;
                            checkForTrackExit(i, column);
                            if (i == 0)
                            {
                                turnsCount++;
                                previousDirection = 'U';
                                buildTrack(i, column - 1, 'L');
                            }
                            continue;
                        }
                        else
                        {
                            turnsCount++;
                            previousDirection = 'U';
                            buildTrack(i + 1, column - 1, 'L');
                            break;
                        }
                    }
                    break;
            }
        }
    }
}
