using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT
{
    public class Program
    {
        static string[,] takenBoxes = new string[3, 3];
        static bool win = false;
        
        static void Main(string[] args)
        {
            Random computerPick = new Random();
            while (!win)
            {
                PrintGameBoard();

                Console.WriteLine("Make a move:");
                Console.Write("\tEnter a row: ");
                int row = Convert.ToInt32(Console.ReadLine()) - 1;
                if (row < 0 || row > 2) // check if row in range, restart if not
                {
                    Console.WriteLine("Enter a row in range\nPress any key to continue");
                    Console.ReadLine();
                    continue;
                }
                Console.Write("\tEnter a column: ");
                int col = Convert.ToInt32(Console.ReadLine()) - 1;

                if (row < 0 || row > 2)//check if column in range, restart if not
                {
                    Console.WriteLine("Enter a column in range\nPress any key to continue");
                    Console.ReadLine();
                    continue;
                }              

                //variables to hold the computer's move
                int computerRow;
                int computerCol;

                if (MakeMove(row, col)) // calls MakeMove and proceeds if successful
                {
                    CheckForWin(row, col);
                    if (win)
                    {
                        Console.Clear();
                        PrintGameBoard();
                        Console.WriteLine("You won!");
                        continue;
                    }

                    //make the computer's move here. 
                    do
                    {
                        computerRow = computerPick.Next(0, 3);
                        computerCol = computerPick.Next(0, 3);
                    } while (!MakeCMove(computerRow, computerCol));
                }
            }
        }

        private static void PrintGameBoard()
        {
            Console.Clear();
            Console.Write("\t1\t2\t3\n");
            for (int i = 0; i <=2; i++)
            {
                Console.Write(i+1 + "\t{0}\t{1}\t{2}\n", takenBoxes[i,0], takenBoxes[i,1], takenBoxes[i,2]);                
            }
            

        }//end Main

        static bool MakeMove(int Row, int Column) //takes row, col from user and places in array
        {
            if (takenBoxes[Row, Column] == null)
            {
                takenBoxes[Row, Column] = "X";
                
                //return true if move was successfully made
                return true;
            }
            else
                return false;
        }

        static bool MakeCMove(int Row, int Column) //takes row, col from user and places in array
        {
            if (takenBoxes[Row, Column] == null)
            {
                takenBoxes[Row, Column] = "O";
                CheckForWin(Row, Column);
                if (win) //Check to see if the computer made the winning move
                {
                    Console.Clear();
                    PrintGameBoard();
                    Console.WriteLine("The computer won!");
                };
                
                //return true, 
                return true;
            }
            else
                return false;
        }


        static void CheckForWin(int row, int column)
        {
            CheckForRowWin(row, column);
            CheckColumnWin(row, column);
            CheckLeftDiagonalWin(row, column);
            CheckRightDiagonalWin(row, column);
        }

        static void CheckForRowWin(int row, int column)
        {
            if (!win) //only run if a win hasn't already been made
            {
                if (takenBoxes[row, 0] == takenBoxes[row, 1] 
                    && takenBoxes[row, 1] == takenBoxes[row, 2])                
                    win = true;                
            }
        }//End CheckForRowWin

        static void CheckColumnWin(int row, int column)
        {
            if (!win) //only run if a win hasn't already been made
            {
                if (takenBoxes[0, column] == takenBoxes[1, column]
                    && takenBoxes[1, column] == takenBoxes[2, column])
                    win = true;
            }
        }//end CheckColumnWin        

        static void CheckLeftDiagonalWin(int row, int col)
        {
            if (!win) //only run if a win hasn't already been made
            {
                string[] leftDiagonalPositions = { "00", "11", "22" };
                //convert row and col to strings, then concat for upcoming comparison
                string inputstr = row.ToString() + col.ToString();

                //only runs if the user input falls along the left diagonal
                if (Array.IndexOf(leftDiagonalPositions, inputstr) >= 0)
                {             
                    if (takenBoxes[0, 0] == takenBoxes[1, 1]
                        && takenBoxes[1, 1] == takenBoxes[2, 2])
                        win = true;
                }
            }
        }//end CheckLeftDiagonalWin

        static void CheckRightDiagonalWin(int row, int col)
        {
            if (!win) //only run if a win hasn't already been made
            {
                //
                string[] rightDiagonalPositions = { "02", "11", "20" };
                //convert row and col to strings, then concat for upcoming comparison
                string inputstr = row.ToString() + col.ToString();

                //only run if the user input falls along the right diagonal
                if (Array.IndexOf(rightDiagonalPositions, inputstr) >= 0)
                {
                    if (takenBoxes[0, 2] == takenBoxes[1, 1]
                        && takenBoxes[1, 1] == takenBoxes[2, 0])
                        win = true;
                }
            }
        }// end CheckRightDiagonalWin
    }
}
