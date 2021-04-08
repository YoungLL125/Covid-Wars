using System;

class Func1{


  /*
  Covid-19 Announcement Function 1
  */


  public static void CovidAnnDraw(bool bought){
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("=================================================");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Cyan;

    if (bought){
      if (Global.alertLvl == Global.alertLvlCurrent){
        Console.WriteLine(" Alert Level:\t{0}", Global.alertLvl);
      }
      else{
        Console.WriteLine("    Initial Alert Level:\t{0}", Global.alertLvl);
        Console.WriteLine("Changing Alert Level to:\t{0}", Global.alertLvlCurrent);
      }
      
      Console.WriteLine("");
      Console.WriteLine(" Covid Announcement Options:");
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("\t(0) Open borders:\t$1 million");
      Console.WriteLine("\t(1) Alert Level 1:\t$1 million");
      Console.WriteLine("\t(2) Alert Level 2:\t$1 million");
      Console.WriteLine("\t(3) Alert Level 3:\t$1 million");
      Console.WriteLine("\t(4) Alert Level 4:\t$1 million");
      Console.WriteLine("");
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine(" Other:");
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("\t(5) Cancel Purchase");
      Console.WriteLine("\t(6) Return to Main Menu");
      if (Global.covidAnnSpent > 0){
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\t\t\tSpending:\t${0} million", Global.covidAnnSpent);
      }
    }
    else{
      Console.WriteLine(" Covid Announcement Option:");
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("\t(1) Covid Announcement Media:\t$10 million");
      Console.WriteLine("");
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine(" Other:");
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("\t(2) Cancel Purchase");
      Console.WriteLine("\t(3) Return to Main Menu");
      if (Global.covidAnnSpent > 0){
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\t\t\tSpending:\t${0} million", Global.covidAnnSpent);
      }
    }
    
    Console.WriteLine("");
    
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("=================================================");
    Console.ForegroundColor = ConsoleColor.Yellow;

  }

  public static void CovidAnnProg(bool bought){

    CovidAnnDraw(bought);


    string rawInput = "";
    bool check = false;
    int input = 0;

    while (!check){
      
      Console.Write("\nYour Input: ");
      rawInput = Console.ReadLine();
      try{

        input = Convert.ToInt32(rawInput);
        
        if (bought){
          if (input >= 0 && input <= 6){
            check = true;
          }
          else{
            CovidAnnDraw(bought);
            Console.WriteLine("Error: '{0}' is not a valid input", rawInput);
          }
        }
        else{
          if (input >= 1 && input <= 3){
            check = true;
          }
          else{
            CovidAnnDraw(bought);
            Console.WriteLine("Error: '{0}' is not a valid input", rawInput);
          }
        }
        
        
      }
      catch{
        CovidAnnDraw(bought);
        Console.WriteLine("Error: '{0}' is not a valid input", rawInput);
      }
    }


    // Changes values or Directs user to Game Menu
    if (bought){
      switch (input){

        case 0:
          if (Global.alertLvl != 0){
            Menu.LoadingSub(1);
            Global.covidAnnSpent = 1;
          }
          else{
            Global.covidAnnSpent = 0;
          }
          Global.alertLvlCurrent = 0;

          CovidAnnProg(Global.covidAnnPurch);
          break;
        
        case 1:

          if (Global.alertLvl != 1){
            Menu.LoadingSub(1);
            Global.covidAnnSpent = 1;
          }
          else{
            Global.covidAnnSpent = 0;
          }
          Global.alertLvlCurrent = 1;

          CovidAnnProg(Global.covidAnnPurch);
          break;

        case 2:

          if (Global.alertLvl != 2){
            Menu.LoadingSub(1);
            Global.covidAnnSpent = 1;
          }
          else{
            Global.covidAnnSpent = 0;
          }
          Global.alertLvlCurrent = 2;

          CovidAnnProg(Global.covidAnnPurch);
          break;

        case 3:

          if (Global.alertLvl != 3){
            Menu.LoadingSub(1);
            Global.covidAnnSpent = 1;
          }
          else{
            Global.covidAnnSpent = 0;
          }
          Global.alertLvlCurrent = 3;

          CovidAnnProg(Global.covidAnnPurch);
          break;

        case 4:

          if (Global.alertLvl != 4){
            Menu.LoadingSub(1);
            Global.covidAnnSpent = 1;
          }
          else{
            Global.covidAnnSpent = 0;
          }
          Global.alertLvlCurrent = 4;

          CovidAnnProg(Global.covidAnnPurch);
          break;

        case 5:

          if (Global.covidAnnSpent != 0){
            Menu.LoadingSub(0);
          }
          Global.covidAnnSpent = 0;
          Global.alertLvlCurrent = Global.alertLvl;

          CovidAnnProg(Global.covidAnnPurch);
          break;

        case 6:
          Menu.MenuProg();
          break;
      }
    }
    else{
      switch (input){

        case 1:
          if (Global.covidAnnSpent != 10){
            Menu.LoadingSub(1);
            Global.covidAnnSpent = 10;
            Global.covidAnnPurchCurrent = true;
          }

          CovidAnnProg(Global.covidAnnPurch);
          break;
        
        case 2:
          if (Global.covidAnnSpent != 0){
            Menu.LoadingSub(0);
            Global.covidAnnSpent = 0;
            Global.covidAnnPurchCurrent = false;
          }

          CovidAnnProg(Global.covidAnnPurch);
          break;
        
        case 3:
          Menu.MenuProg();
          break;

      }
    }
  }
}