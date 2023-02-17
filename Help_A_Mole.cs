using System;
using System.Collections.Generic;
using System.Linq;

namespace HelpAMole
{
    class Help_A_Mole
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int rowNumber = 0;
            int colNumber = 0;

            int specialEndRow = 0;
            int specialStartRow = 0;
            int specialEndCol = 0;
            int specialStartCol = 0;
            int countOfS = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string inputOfMatrix = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputOfMatrix[col];
                    if (inputOfMatrix[col] == 'M')
                    {
                        rowNumber = row;
                        colNumber = col;
                        matrix[rowNumber, colNumber] = '-';
                    }
                    else if (inputOfMatrix[col] == 'S' && countOfS == 0)
                    {
                        specialStartRow = row;
                        specialStartCol = col;
                        countOfS++;
                    }
                    else if (inputOfMatrix[col] == 'S' && countOfS == 1)
                    {
                        specialEndRow = row;
                        specialEndCol = col;
                    }
                }
            }

            int earningPoints = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "up")
                {
                    rowNumber--;
                    if (rowNumber < 0)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        rowNumber++;
                    }
                    else
                    {
                        if (char.IsDigit(matrix[rowNumber, colNumber]))
                        {
                            earningPoints += int.Parse(matrix[rowNumber, colNumber].ToString());
                            matrix[rowNumber, colNumber] = '-';
                        }
                        else
                        {
                            if (matrix[rowNumber, colNumber] == '-')
                            {
                                continue;
                            }
                            if (rowNumber == specialStartRow && colNumber == specialStartCol)
                            {
                                matrix[rowNumber, colNumber] = '-';
                                rowNumber = specialEndRow;
                                colNumber = specialEndCol;
                                earningPoints -= 3;
                                matrix[rowNumber, colNumber] = '-';
                            }
                            else if (rowNumber == specialEndRow && colNumber == specialEndCol)
                            {
                                matrix[rowNumber, colNumber] = '-';
                                rowNumber = specialStartRow;
                                colNumber = specialStartCol;
                                earningPoints -= 3;
                                matrix[rowNumber, colNumber] = '-';
                            }
                        }
                        
                    }
                }
                else if (command == "down")
                {
                    rowNumber++;
                    if (rowNumber >= n)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        rowNumber--;
                    }
                    else
                    {
                        if (char.IsDigit(matrix[rowNumber, colNumber]))
                        {
                            earningPoints += int.Parse(matrix[rowNumber, colNumber].ToString());
                            matrix[rowNumber, colNumber] = '-';
                        }
                        else
                        {
                            if (matrix[rowNumber, colNumber] == '-')
                            {
                                continue;
                            }

                            if (rowNumber == specialStartRow && colNumber == specialStartCol)
                            {
                                matrix[rowNumber, colNumber] = '-';
                                rowNumber = specialEndRow;
                                colNumber = specialEndCol;
                                earningPoints -= 3;
                                matrix[rowNumber, colNumber] = '-';
                            }
                            else if (rowNumber == specialEndRow && colNumber == specialEndCol)
                            {
                                matrix[rowNumber, colNumber] = '-';
                                rowNumber = specialStartRow;
                                colNumber = specialStartCol;
                                earningPoints -= 3;
                                matrix[rowNumber, colNumber] = '-';
                            }
                        }

                    }
                }
                else if (command == "left")
                {
                    colNumber--;
                    if (colNumber < 0)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        colNumber++;
                    }
                    else
                    {
                        if (char.IsDigit(matrix[rowNumber, colNumber]))
                        {
                            earningPoints += int.Parse(matrix[rowNumber, colNumber].ToString());
                            matrix[rowNumber, colNumber] = '-';
                        }
                        else
                        {
                            if (matrix[rowNumber, colNumber] == '-')
                            {
                                continue;
                            }

                            if (rowNumber == specialStartRow && colNumber == specialStartCol)
                            {
                                matrix[rowNumber, colNumber] = '-';
                                rowNumber = specialEndRow;
                                colNumber = specialEndCol;
                                earningPoints -= 3;
                                matrix[rowNumber, colNumber] = '-';
                            }
                            else if (rowNumber == specialEndRow && colNumber == specialEndCol)
                            {
                                matrix[rowNumber, colNumber] = '-';
                                rowNumber = specialStartRow;
                                colNumber = specialStartCol;
                                earningPoints -= 3;
                                matrix[rowNumber, colNumber] = '-';
                            }
                        }

                    }
                }
                else if (command == "right")
                {
                    colNumber++;
                    if (colNumber >= n)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        colNumber--;
                    }
                    else
                    {
                        if (char.IsDigit(matrix[rowNumber, colNumber]))
                        {
                            earningPoints += int.Parse(matrix[rowNumber, colNumber].ToString());
                            matrix[rowNumber, colNumber] = '-';
                        }
                        else
                        {
                            if (matrix[rowNumber, colNumber] == '-')
                            {
                                continue;
                            }

                            if (rowNumber == specialStartRow && colNumber == specialStartCol)
                            {
                                matrix[rowNumber, colNumber] = '-';
                                rowNumber = specialEndRow;
                                colNumber = specialEndCol;
                                earningPoints -= 3;
                                matrix[rowNumber, colNumber] = '-';
                            }
                            else if (rowNumber == specialEndRow && colNumber == specialEndCol)
                            {
                                matrix[rowNumber, colNumber] = '-';
                                rowNumber = specialStartRow;
                                colNumber = specialStartCol;
                                earningPoints -= 3;
                                matrix[rowNumber, colNumber] = '-';
                            }
                        }

                    }
                }

                if (earningPoints >= 25)
                {
                    break;
                }
            }

            if (earningPoints < 25)
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {earningPoints} points.");
            }
            else
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {earningPoints} points.");
            }
            matrix[rowNumber, colNumber] = 'M';

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");

                }
                Console.WriteLine();
            }

        }

    }
}
