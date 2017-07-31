using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/*
Program brief
15 sliding puzzle game

4 x 4 square allowing the movement of one empty slot, requires the numbers to be put in order 1-15

 */

namespace _15Puzzle
{
    class Program
    {

        // Strut for finding the location for the x counter
        public struct Posofx
        {
           public int y;
           public int x;
        }

        // Declare game board
        static string[,] gameboard = new string[4, 4];

        // Declare position instlaiser
        static Posofx position = new Posofx();

        // Method to print the game board to the console
        public static void printboard()
        {
            Console.Clear();
            Console.WriteLine("Use Arrow Keys To Move\n\n");
            //Print board
            for (int cols = 0; cols < 4; cols++)
            {
                //for each row
                for (int rows = 0; rows < 4; rows++)
                {
                    Console.Write( " | ");
                    //Just for asthetics, adds a seperator between the elements
                    if (gameboard[rows, cols].Length > 1)
                    {
                        Console.Write(gameboard[rows, cols] + " | ");
                    }

                    else
                    {
                        Console.Write(gameboard[rows, cols] + "  | ");
                    }
                    //  Console.WriteLine(gameboard[cols, rows]+"-");
                }
                Console.WriteLine("");
            }
        }

        //Win Condition Check
        //Quick and dirty, checks to see if the elements are in the right place
        public static bool winCondition()
        {
            if((gameboard[0,0] == "1")&&(gameboard[0, 1] == "2")&& (gameboard[0, 2] == "3") && (gameboard[0,3] == "4")
                    && (gameboard[1, 0] == "5") && (gameboard[1, 1] == "6") && (gameboard[1, 2] == "7") && (gameboard[1, 3] == "8")
                    && (gameboard[2, 0] == "9") && (gameboard[2, 1] == "10") && (gameboard[2, 2] == "11") && (gameboard[2, 3] == "12")
                    && (gameboard[3, 0] == "13") && (gameboard[3, 1] == "14") && (gameboard[3, 2] == "15"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /*
        Method for movement
        Creates a temp string called temp that moves the element out of the array and replaces it with x
        x is held in the struct for the xposit, the position of the x is then updated
        */
        public static void movethis(String movedir)
        {
            string temp = "";
            switch(movedir)
            {
                case "up":
                    if (position.y > 0)
                    {
                        temp = gameboard[position.x , position.y-1];
                        gameboard[position.x , position.y-1] = "x";
                        gameboard[position.x , position.y] = temp.ToString();
                        position.y = position.y - 1;
                    }
                    break;
                case "down":
                    if (position.y < 3)
                    {
                        temp = gameboard[position.x, position.y + 1];
                        gameboard[position.x, position.y + 1] = "x";
                        gameboard[position.x, position.y] = temp.ToString();
                        position.y = position.y + 1;
                    }
                    break;
                case "left":
                    if (position.x > 0)
                    {
                        temp = gameboard[position.x - 1, position.y];
                        gameboard[position.x - 1, position.y] = "x";
                        gameboard[position.x, position.y] = temp.ToString();
                        position.x = position.x - 1;

                    }
                    break;
                case "right":
                    if (position.x < 3)
                    {
                        temp = gameboard[position.x + 1, position.y];
                        gameboard[position.x + 1, position.y] = "x";
                        gameboard[position.x, position.y] = temp.ToString();
                        position.x = position.x + 1;
                    }
                    break;
            }
        }

        static void Main(string[] args)
        {
            bool active;
            // Number tiles, create list then create 1-15, fill list
            List<int> gameNumbers = new List<int>();
            for (int iq = 1; iq < 16; iq++)
            {
                gameNumbers.Add(iq);
            }


            // Random Variable
            Random rnd = new Random();


            ///Set up board
            // For each column
            for (int rows = 0;rows < 4; rows++)
            {
                //for each row
                for (int col = 0; col < 4; col++)
                {
                    // If there are numbers in the list
                    if (gameNumbers.Count > 0)
                    {
                        //choose a random number from the list
                        int temp = rnd.Next(gameNumbers.Count);
                        //Set it to the array
                        gameboard[rows, col] = gameNumbers[temp].ToString();
                        //Remove it from the list
                        gameNumbers.Remove(Int32.Parse(gameboard[rows, col]));
                       
                    }
                    //If there are no numbers in the list then this is the empty slider set as x
                    else
                    {
                        gameboard[rows, col] = "x";
                        //Set position of x
                        
                        position.x = rows;
                        position.y = col;
                    }
                }
            }
            active = true;
            while(active)
            {
                printboard();
                switch(Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        movethis("up");
                        break;
                    case ConsoleKey.DownArrow:
                        movethis("down");
                        break;
                    case ConsoleKey.LeftArrow:
                        movethis("left");
                        break;
                    case ConsoleKey.RightArrow:
                        movethis("right");
                        break;
                }
                 
            }

            if(winCondition())
            {
                active = false;
                Console.Clear();
                Console.WriteLine("Winner Winner Chicken Dinner");
                Console.ReadKey();
            }
            

            
        }
    }
}
