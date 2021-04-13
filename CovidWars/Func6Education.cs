using System;

class Func6{

    // Draws Menu
    public static void EducationDraw(){
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=================================================");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Increases Happiness Percentage");
        Console.WriteLine(" Health Education Options:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("");
        Console.WriteLine("\t(1) Posters\t 5% - 10%:\t$10 million");
        Console.WriteLine("\t(2) Website\t 10% - 20%:\t$25 million");
        Console.WriteLine("\t(3) Advert\t 15% - 30%:\t$100 million");
        Console.WriteLine("\t(4) Presentation 25% - 50%:\t$500 million");
        Console.WriteLine("\t(5) Primary, Seconday, Tertiary Educational");
        Console.WriteLine("\t    Programs\t 50% - 100%:\t$1000 million");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Other:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t(6) Cancel Purchase");
        Console.WriteLine("\t(7) Return to Main Menu");
        Console.WriteLine("");
        if (Global.educationSpent > 0){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\tSpending: ${0} million", Global.educationSpent);
            Console.WriteLine("");
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=================================================");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;
    }


    public static void EducationProg(){
        Console.Clear();

        EducationDraw();

        string rawInput = "TBC";
        int input = 0;
        bool check = false;

        while (!check){
            Console.Write("Your Input: ");
            rawInput = Console.ReadLine();

            try{
                input = Convert.ToInt32(rawInput);

                if (input >= 1 && input <= 7){
                    check = true;
                }
                else{
                    EducationDraw();
                    Console.WriteLine("Error: '{0}' is not a valid input", input);
                }
            }
            catch{
                EducationDraw();
                Console.WriteLine("Error: '{0}' is not a valid input", rawInput);
            }
        }

        Random random = new Random();

        if (input >= 1 && input <= 5){
            Menu.LoadingSub(1);
        }


        switch (input){
            case 1:
                Global.educationSpent = 10;
                Global.educationHappiness = 0.5 + 0.5 * random.NextDouble();
                break;
            case 2:
                Global.educationSpent = 25;
                Global.educationHappiness = 0.1 + 0.1 * random.NextDouble();
                break;
            case 3:
                Global.educationSpent = 100;
                Global.educationHappiness = 0.15 + 0.15 * random.NextDouble();
                break;
            case 4:
                Global.educationSpent = 500;
                Global.educationHappiness = 0.25 + 0.25 * random.NextDouble();
                break;
            case 5:
                Global.educationSpent = 1000;
                Global.educationHappiness = 0.5 + 0.5 * random.NextDouble();
                break;
            case 6:
                Menu.LoadingSub(0);
                Global.educationSpent = 0;
                Global.educationHappiness = 0;
                break;
            case 7:
                Menu.MenuProg();
                break;
            default:
                Menu.MenuProg();
                break;
        }

        if (input >= 1 && input <= 6){
            EducationProg();
        }


    }



}