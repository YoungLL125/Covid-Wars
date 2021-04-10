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
            Console.WriteLine("\t(1) Stagnant 200 weeks:\t$2500 million");
            Console.WriteLine("\t(2) Slow 100 weeks:\t$5000 million");
            Console.WriteLine("\t(3) Moderate 50 weeks:\t$10000 million");
            Console.WriteLine("\t(4) Fast 20 weeks:\t$25000 million");
            Console.WriteLine("\t(5) Hyper 10 weeks:\t$350000 million");
            Console.WriteLine("\t(6) Instant 1 week:\t$700000 million");
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Other:");
            Console.ForegroundColor = ConsoleColor.Yellow;
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
        if (Global.vaccineNum > 0 && Global.developed){
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" No. Vaccines avaliable: {0}", Global.vaccineNum);
            Console.WriteLine("");
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Vaccine Production Options:");
        Console.ForegroundColor = ConsoleColor.Yellow;

        if (Global.developed){
            Console.WriteLine("\t(1)  3000 vaccines/week:\t$50 million");
            Console.WriteLine("\t(2)  6000 vaccines/week:\t$100 million");
            Console.WriteLine("\t(3) 10000 vaccines/week:\t$250 million");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Other:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t(4) Cancel Purchase");
            Console.WriteLine("\t(5) Return to Vaccine Menu");
        }
        else{
            Console.WriteLine("\tWarning: There is no avaliable vaccine");
            Console.WriteLine("\tA vaccine hasn't been developed yet...");
            Console.WriteLine("\tOr, the virus may have mutated");
            Console.WriteLine("\tPlease develop a new vaccine in the Vaccine Development");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Other:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t(1) Return to Vaccine Menu");

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
    Vaccine Implementation Draw Menu
    */




    public static void VaccineImpDraw(){
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=================================================");
        Console.WriteLine("");
        if (Global.vaccineNum > 0 && Global.developed){
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" No. Vaccines avaliable: {0}", Global.vaccineNum);
            Console.WriteLine("");
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Vaccine Implementation Options:");
        Console.ForegroundColor = ConsoleColor.Yellow;

        if (Global.developed && Global.vaccineNum > 0){
            Console.WriteLine("\t(1)  1000 people/week:\t$100 million");
            Console.WriteLine("\t(2)  5000 people/week:\t$250 million");
            Console.WriteLine("\t(3) 10000 people/week:\t$500 million");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Other:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t(4) Cancel Purchase");
            Console.WriteLine("\t(5) Return to Vaccine Menu");
        }
        else{
            Console.WriteLine("\tWarning: There are no vaccines avaliable");
            Console.WriteLine("\tPlease develop and produce vaccines before implementing them");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Other:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t(1) Return to Vaccine Menu");
        }

        Console.WriteLine("");

        if (Global.vaccineImpSpent > 0){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\tSpending:\t${0} million", Global.vaccineImpSpent);
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
                VaccineProdProg();
                break;
            case 3:
                VaccineImpProg();
                break;
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
                        Global.vaccineDevSpent = 2500;
                        Global.vaccineDevWeek = 200;
                        break;
                    case 2:
                        Global.vaccineDevSpent = 5000;
                        Global.vaccineDevWeek = 100;
                        break;
                    case 3:
                        Global.vaccineDevSpent = 10000;
                        Global.vaccineDevWeek = 50;
                        break;
                    case 4:
                        Global.vaccineDevSpent = 25000;
                        Global.vaccineDevWeek = 20;
                        break;
                    case 5:
                        Global.vaccineDevSpent = 35000;
                        Global.vaccineDevWeek = 10;
                        break;
                    case 6:
                        Global.vaccineDevSpent = 70000;
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

                if (Global.developed){
                    if (input >= 1 && input <= 5){
                    check = true;
                    }
                    else{
                        VaccineProdDraw();
                        Console.WriteLine("Error: '{0}' is not a valid input", input);
                    }
                }
                else{
                    if (input == 1){
                    check = true;
                    }
                    else{
                        VaccineProdDraw();
                        Console.WriteLine("Error: '{0}' is not a valid input", input);
                    }
                }
                
            }
            catch{
                VaccineProdDraw();
                Console.WriteLine("Error: '{0}' is not a valid input", rawInput);
            }
        }

        if (Global.developed){

            if (input >= 1 && input <= 4){
                Global.vaccineSpent = Global.vaccineSpent - Global.vaccineProdSpent;
            }

            switch (input){
                case 1:
                    Global.vaccineProdSpent = 50;
                    Global.vaccineProdRate = 3000;
                    break;
                case 2:
                    Global.vaccineProdSpent = 100;
                    Global.vaccineProdRate = 6000;
                    break;
                case 3:
                    Global.vaccineProdSpent = 250;
                    Global.vaccineProdRate = 10000;
                    break;
                case 4:
                    Global.vaccineProdSpent = 0;
                    Global.vaccineProdRate = 0;
                    break;
                case 5:
                    VaccineProg();
                    break;
            }

            if (input >= 1 && input <= 4){

                if (input == 4){
                    Menu.LoadingSub(0);
                }
                else{
                    Menu.LoadingSub(1);
                }
                
                Global.vaccineSpent = Global.vaccineSpent + Global.vaccineProdSpent;
                VaccineProdProg();
            }
        }
        else{
            if (input == 1){
                VaccineProg();
            }
        }
        
    }






    /*
    Vaccine Implementation program
    */




    public static void VaccineImpProg(){
        Console.Clear();

        VaccineImpDraw();

        string rawInput = "TBC";
        int input = 0;
        bool check = false;

        while (!check){
            Console.Write("Your Input: ");
            rawInput = Console.ReadLine();

            try{
                input = Convert.ToInt32(rawInput);

                if (Global.developed && Global.vaccineNum > 0){
                    if (input >= 1 && input <= 5){
                    check = true;
                    }
                    else{
                        VaccineImpDraw();
                        Console.WriteLine("Error: '{0}' is not a valid input", input);
                    }
                }
                else{
                    if (input == 1){
                        check = true;
                    }
                    else{
                        VaccineImpDraw();
                        Console.WriteLine("Error: '{0}' is not a valid input", input);
                    }
                }
                
            }
            catch{
                VaccineImpDraw();
                Console.WriteLine("Error: '{0}' is not a valid input", rawInput);
            }
        }

        if (Global.developed && Global.vaccineNum > 0){

            if (input >= 1 && input <= 4){
                Global.vaccineSpent = Global.vaccineSpent - Global.vaccineImpSpent;
            }

            switch (input){
                case 1:
                    Global.vaccineImpSpent = 100;
                    Global.vaccineImpRate = 1000;
                    break;
                case 2:
                    Global.vaccineImpSpent = 250;
                    Global.vaccineImpRate = 5000;
                    break;
                case 3:
                    Global.vaccineImpSpent = 500;
                    Global.vaccineImpRate = 10000;
                    break;
                case 4:
                    Global.vaccineImpRate = 0;
                    Global.vaccineImpSpent = 0;
                    break;
                case 5:
                    VaccineProg();
                    break;
            }

            if (input >= 1 && input <= 4){

                if (input == 4){
                    Menu.LoadingSub(0);
                }
                else{
                    Menu.LoadingSub(1);
                }

                Global.vaccineSpent = Global.vaccineSpent + Global.vaccineImpSpent;

                VaccineImpProg();
            }
        }
        else{
            if (input == 1){
                VaccineProg();
            }
        }

        
    }




}