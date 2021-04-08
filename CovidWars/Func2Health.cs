using System;

class Func2
{



    /*
    Function 2 General Health
    */



    public static void HealthDraw(){
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=================================================");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" General Health Options:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t(1) Money Spend in General Health");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Other:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t(2) Cancel Purchase");
        Console.WriteLine("\t(3) Return to Main Menu");

        if (Global.genHealthSpent > 0){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\tSpending:\t${0} million", Global.genHealthSpent);
        }

        Console.WriteLine("");
    
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=================================================");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;


    }

    public static void HealthProg(){

        HealthDraw();

        string rawInput = "TBC";
        int input = 0;
        bool check = false;

        while (!check){
            Console.Write("Your Input: ");
            rawInput = Console.ReadLine();

            try{
                input = Convert.ToInt32(rawInput);
                if(input >= 1 && input <= 3){
                    check = true;
                }
                else{
                    HealthDraw();
                    Console.WriteLine("Error: '{0}' is not a valid input", input);
                }
            }
            catch{
                HealthDraw();
                Console.WriteLine("Error: '{0}' is not a valid input", rawInput);
            }
        }

        switch (input){
            case 1:
                Purchase();
                HealthProg();
                break;
            case 2:
                if(Global.genHealthSpent != 0){
                    Menu.LoadingSub(0);
                    Global.genHealthSpent = 0;
                }

                HealthProg();
                break;
            
            case 3:
                Menu.MenuProg();
                break;
        }
    }


    public static void Purchase(){

        string rawInput = " ";
        double input = 0;
        bool check = false;

        Console.Clear();

        while (!check){

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter a sum of money between 0 - 500 ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Your Payment: ");
            rawInput = Console.ReadLine();

            Console.Clear();

            try{
                input = Convert.ToDouble(rawInput);
                if (input >= 0 && input <= 500){
                    check = true;
                }
                else{
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: '{0}' is not within the range of 0 - 500", input);
                }
            }
            catch{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: '{0}' is not a valid input", rawInput);
            }

        }

        Menu.LoadingSub(1);

        Global.genHealthSpent = Game.Rounding(input, 1);


    }
}