using System;

class Func3{



    /*
    Function 3 Vaccines
    */

    

    public static void VaccineDraw(){
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=================================================");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Vaccine Options:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t(1) Vaccine Development");
        Console.WriteLine("\t(2) Vaccine Production");
        Console.WriteLine("\t(3) Vaccine Implementation");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Other:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t(4) Return to Main Menu");
        if (Global.vaccineSpent > 0 && Global.developing == false || Global.vaccineSpent < 0){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\tSpending:\t${0} million", Global.vaccineSpent);
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=================================================");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;
    }

    public static void VaccineDevDraw(){
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=================================================");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Vaccine Development Options:");
        Console.ForegroundColor = ConsoleColor.Yellow;

        if (!Global.developed){
            if (!Global.developing){
            Console.WriteLine("\t(1) Stagnant 200 weeks:\t$500 million");
            Console.WriteLine("\t(2) Slow 100 weeks:\t$1000 million");
            Console.WriteLine("\t(3) Moderate 50 weeks:\t$2000 million");
            Console.WriteLine("\t(4) Fast 20 weeks:\t$5000 million");
            Console.WriteLine("\t(5) Hyper 10 weeks:\t$10000 million");
            Console.WriteLine("\t(6) Instant 1 week:\t$50000 million");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Other:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t(7) Cancel Purchase");
            Console.WriteLine("\t(8) Return to Vaccine Menu");
            }
            else{
                
                Console.WriteLine("\t(1) Refund");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" Other:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t(2) Return to Vaccination Menu");
            }
            Console.WriteLine("");

            if (Global.vaccineDevWeek > 0){
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t\tVaccine is developing...");
                Console.WriteLine("\t\t\tEstimated weeks remaining: {0}", Global.vaccineDevWeek);
            }
            if (Global.vaccineDevSpent > 0 && Global.developing == false || Global.vaccineDevSpent < 0){
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t\tSpending:\t${0} million", Global.vaccineDevSpent);
            }

        }
        else{
            Console.WriteLine("\n A vaccine for the current form of \n Covid-19 is already developed");
            Console.WriteLine(" You may produce and implement the vaccine\n");
            Console.WriteLine("\t(1) Return to Vaccine Menu");
        }
        
        Console.WriteLine("");
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=================================================");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;

    }



    public static void VaccineProdDraw(){
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=================================================");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Vaccine Production Options:");
        Console.ForegroundColor = ConsoleColor.Yellow;

        if (Global.developed){
            Console.WriteLine("\t(1)  2000 vaccines/week:\t$30 million");
            Console.WriteLine("\t(2)  6000 vaccines/week:\t$60 million");
            Console.WriteLine("\t(3) 12000 vaccines/week:\t$100 million");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Other:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t(4) Return to Vaccine Menu");
        }
        else{
            Console.WriteLine("\tWarning: There is no avaliable vaccine");
            Console.WriteLine("\tThe virus may have mutated");
            Console.WriteLine("\tPlease develop a new vaccine");
        }

        Console.WriteLine("");

        if (Global.vaccineProdSpent > 0){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\tSpending:\t${0} million", Global.vaccineProdSpent);
        }

        Console.WriteLine("");
    
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=================================================");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;


    }





    /*
    Main Vaccine Menu Program
    */





    public static void VaccineProg(){
        Console.Clear();

        VaccineDraw();

        string rawInput = "TBC";
        int input = 0;
        bool check = false;

        while (!check){
            Console.Write("Your Input: ");
            rawInput = Console.ReadLine();

            try{
                input = Convert.ToInt32(rawInput);

                if (input >= 1 && input <= 4){
                    check = true;
                }
                else{
                    VaccineDraw();
                    Console.WriteLine("Error: '{0}' is not a valid input", input);
                }
            }
            catch{
                VaccineDraw();
                Console.WriteLine("Error: '{0}' is not a valid input", rawInput);
            }
        }

        switch (input){
            case 1:
                VaccineDevProg();
                break;
            case 2:
            case 3:
            case 4:
                Menu.MenuProg();
                break;
        }
    }





    /*
    Vaccine Development Program
    */





    public static void VaccineDevProg(){
        Console.Clear();

        VaccineDevDraw();

        string rawInput = "TBC";
        int input = 0;
        bool check = false;

        while (!check){
            Console.Write("Your Input: ");
            rawInput = Console.ReadLine();

            try{
                input = Convert.ToInt32(rawInput);

                if (!Global.developed){
                    if (!Global.developing){
                        if(input >= 1 && input <= 8){
                        check = true;
                        }
                        else{
                            VaccineDevDraw();
                            Console.WriteLine("Error: '{0}' is not a valid input", input);
                        }
                    }
                    else{
                        if(input >= 1 && input <= 2){
                        check = true;
                        }
                        else{
                            VaccineDevDraw();
                            Console.WriteLine("Error: '{0}' is not a valid input", input);
                        }
                    }
                }
                else{
                    if (input == 1){
                        check = true;
                    }
                    else{
                        VaccineDevDraw();
                        Console.WriteLine("Error: '{0}' is not a valid input", input);
                    }
                }
                
                
            }
            catch{
                VaccineDevDraw();
                Console.WriteLine("Error: '{0}' is not a valid input", rawInput);
            }
        }

        if (!Global.developed){

            if (!Global.developing){
                if (input >= 1 && input <= 6){
                Menu.LoadingSub(1);
                }

                if (input >= 1 && input <= 7){
                    Global.vaccineSpent = Global.vaccineSpent - Global.vaccineDevSpent;
                }
                

                switch (input){
                    case 1:
                        Global.vaccineDevSpent = 500;
                        Global.vaccineDevWeek = 200;
                        break;
                    case 2:
                        Global.vaccineDevSpent = 1000;
                        Global.vaccineDevWeek = 100;
                        break;
                    case 3:
                        Global.vaccineDevSpent = 2000;
                        Global.vaccineDevWeek = 50;
                        break;
                    case 4:
                        Global.vaccineDevSpent = 5000;
                        Global.vaccineDevWeek = 20;
                        break;
                    case 5:
                        Global.vaccineDevSpent = 10000;
                        Global.vaccineDevWeek = 10;
                        break;
                    case 6:
                        Global.vaccineDevSpent = 50000;
                        Global.vaccineDevWeek = 1;
                        break;
                    case 7:
                        Menu.LoadingSub(0);
                        Global.vaccineDevSpent = 0;
                        VaccineDevProg();
                        break;
                    case 8:
                        VaccineProg();
                        break;
                }

                if (input >= 1 && input <= 7){
                    Global.vaccineSpent = Global.vaccineSpent + Global.vaccineDevSpent;
                }

                if (input >= 1 && input <= 6){
                    Global.developingCurrent = true;
                    VaccineDevProg();
                }
            }
            else{
                switch (input){
                    case 1:
                        if (!Global.refunded){
                            Menu.LoadingSub(2);
                            Global.vaccineSpent = Global.vaccineSpent - Global.vaccineDevSpent/2;
                            Global.vaccineDevSpent = -1 * Global.vaccineDevSpent/2;
                            Global.developingCurrent = false;
                            Global.refunded = true;
                        }
                        
                        VaccineDevProg();
                        break;
                    case 2:
                        VaccineProg();
                        break;
                }
            }
        }
        else{
            VaccineProg();
        }
        
    }





    /*
    Vaccine Production Program
    */





    public static void VaccineProdProg(){
        Console.Clear();

        VaccineProdDraw();

        string rawInput = "TBC";
        int input = 0;
        bool check = false;

        while (!check){
            Console.Write("Your Input: ");
            rawInput = Console.ReadLine();

            try{
                input = Convert.ToInt32(rawInput);

                if (input >= 1 && input <= 4){
                    check = true;
                }
                else{
                    VaccineProdDraw();
                    Console.WriteLine("Error: '{0}' is not a valid input", input);
                }
            }
            catch{
                VaccineProdDraw();
                Console.WriteLine("Error: '{0}' is not a valid input", rawInput);
            }
        }

        switch (input){
            case 1:
            case 2:
            case 3:
            case 4:
                VaccineProg();
                break;
        }
    }




}