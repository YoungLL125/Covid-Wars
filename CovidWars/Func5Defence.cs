using System;

class Func5{

    // Draws Menu
    public static void DefenceDraw(){
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=================================================");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Lowers chance of protest");
        Console.WriteLine(" Defense Options:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("");
        Console.WriteLine("\t(0) Protest/Riot Control:\t10 million");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Forces a percentage of people to pay");
        Console.WriteLine(" Full tax regardless of the current");
        Console.WriteLine(" happiness and alert level");
        Console.WriteLine("");
        Console.WriteLine(" Tax Enforcement:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("");
        Console.WriteLine("\t(1) Restrained 25%:\t$2 million");
        Console.WriteLine("\t(2) Demanding 50%:\t$5 million");
        Console.WriteLine("\t(3) Dictator 100%:\t$10 million");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Other:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t(4) Cancel Purchase");
        Console.WriteLine("\t(5) Return to Main Menu");
        Console.WriteLine("");
        if (Global.defenceSpent > 0){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\tSpending: ${0} million", Global.defenceSpent);
            Console.WriteLine("");
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=================================================");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;

    }


    public static void DefenceProg(){
        Console.Clear();

        DefenceDraw();

        string rawInput = "TBC";
        int input = 0;
        bool check = false;

        while (!check){
            Console.Write("Your Input: ");
            rawInput = Console.ReadLine();

            try{
                input = Convert.ToInt32(rawInput);

                if (input >= 0 && input <= 5){
                    check = true;
                }
                else{
                    DefenceDraw();
                    Console.WriteLine("Error: '{0}' is not a valid input", input);
                }
            }
            catch{
                DefenceDraw();
                Console.WriteLine("Error: '{0}' is not a valid input", rawInput);
            }
        }
        

        if (input >= 0 && input <= 3){
            Menu.LoadingSub(1);
        }

        switch (input){
            case 0:
                Global.defenceSpentRiot = 10;
                Global.defenceRiotControl = true;
                break;
            case 1:
                Global.defenceSpentTax = 2;
                Global.taxPercent = 0.25;
                break;
            case 2:
                Global.defenceSpentTax = 5;
                Global.taxPercent = 0.5;
                break;
            case 3:
                Global.defenceSpentTax = 10;
                Global.taxPercent = 1;
                break;
            case 4:
                Menu.LoadingSub(0);
                Global.defenceRiotControl = false;
                Global.taxPercent = 0;
                Global.defenceSpentRiot = 0;
                Global.defenceSpentTax =  0;
                Global.defenceSpent = 0;
                DefenceProg();
                break;
            case 5:
                Menu.MenuProg();
                break;
            default:
                Menu.MenuProg();
                break;
        }

        if (input >= 0 && input <= 3){
            Global.defenceSpent = Global.defenceSpentRiot + Global.defenceSpentTax;
            DefenceProg();
        }
    }
}