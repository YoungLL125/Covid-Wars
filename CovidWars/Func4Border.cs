using System;

class Func4{
    public static void BorderDraw(){
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=================================================");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Prevents border cases entering community");
        Console.WriteLine(" Shows max amount of border cases \n the quaratine facilities can hold\n");
        Console.WriteLine(" Border Control Options:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t(1)     Weak 50 max:\t$10 million");
        Console.WriteLine("\t(2) Moderate 90 max:\t$50 million");
        Console.WriteLine("\t(3)   Strong 110 max:\t$100 million");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Other:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t(4) Cancel Purchase");
        Console.WriteLine("\t(5) Return to Main Menu");
        Console.WriteLine("");
        if (Global.borderSpent > 0){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\tSpending: ${0} million", Global.borderSpent);
            Console.WriteLine("");
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=================================================");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;
    }

    public static void BorderProg(){
        Console.Clear();

        BorderDraw();

        string rawInput = "TBC";
        int input = 0;
        bool check = false;

        while (!check){
            Console.Write("Your Input: ");
            rawInput = Console.ReadLine();

            try{
                input = Convert.ToInt32(rawInput);

                if (input >= 1 && input <= 5){
                    check = true;
                }
                else{
                    BorderDraw();
                    Console.WriteLine("Error: '{0}' is not a valid input", input);
                }
            }
            catch{
                BorderDraw();
                Console.WriteLine("Error: '{0}' is not a valid input", rawInput);
            }
        }

        switch (input){
            case 1:
                Global.borderSpent = 10;
                Global.borderCap = 50;
                break;
            case 2:
                Global.borderSpent = 50;
                Global.borderCap = 90;
                break;
            case 3:
                Global.borderSpent = 100;
                Global.borderCap = 110;
                break;
            case 4:
                Global.borderSpent = 0;
                Global.borderCap = 0;
                break;
            case 5:
                Menu.MenuProg();
                break;
        }

        if (input >= 1 && input <= 4){
            if (input == 4){
                Menu.LoadingSub(0);
            }
            else{
                Menu.LoadingSub(1);
            }
            Func4.BorderProg();
        }

    }
}