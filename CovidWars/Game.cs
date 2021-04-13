using System;
using System.Threading;

class Game{

  // Submits all information and performs all calculations
  public static void Submit(){

    Console.Clear();

    // Calculates Total Money Spent
    Global.totalSpent = Global.covidAnnSpent + Global.genHealthSpent + Global.vaccineSpent + Global.borderSpent + Global.defenceSpent + Global.educationSpent;

    if (Global.totalMoney >= Global.totalSpent && Global.gameEnd == false){

      // Tells program user hasn't spent too much money
      Global.overspent = false;

      /*
      Function Calculations
      */

      // Total Money Spent per week
      Global.totalMoney = Global.totalMoney - Global.totalSpent;


      // Function 1 CovidAnn
      Global.covidAnnSpent = 0;
      Global.covidAnnPurch = Global.covidAnnPurchCurrent;
      Global.alertLvl = Global.alertLvlCurrent;

      // Function 3 Vaccinations
      Global.vaccineSpent = Global.vaccineProdSpent + Global.vaccineImpSpent;

      // Vaccine Development

      Global.developing = Global.developingCurrent;

      if (Global.vaccineExpired){
        Global.vaccineExpired = false;
      }

      if (Global.developed && Global.developedWeeks < Global.vaccineExpiryNum){
        Global.developedWeeks = Global.developedWeeks + 1;
      }
      else if (Global.developed && Global.developedWeeks == Global.vaccineExpiryNum){
        Global.developed = false;
        Global.developing = false;
        Global.developingCurrent = false;
        Global.vaccineExpired = true;
        Global.developedWeeks = 0;
        Global.vaccineDevWeek = 0;
        Global.vaccineSpent = 0;
        Global.vaccineProdSpent = 0;
        Global.vaccineProdRate = 0;
        Global.vaccineImpSpent = 0;
        Global.vaccineImpSpent = 0;
        Global.vaccineNum = 0;
        Global.popVaccin = 0;
      }

      if (Global.vaccineDevWeek >= 1 && Global.developing == true && Global.refunded == false){
        if (Global.vaccineDevWeek == 1){

          Global.developing = false;
          Global.developingCurrent = false;
          Global.developed = true;
          Global.vaccineDevSpent = 0;
          Global.vaccineDevWeek = 0;

          // Initiates counter for the number of weeks vaccine is effective
          Global.developedWeeks = 0;

          // Creates the expiry week for vaccine
          Random value = new Random();
          int vaccineExp = value.Next(100, 250);
          Global.vaccineExpiryNum = Rounding(Rnd.Dist(Convert.ToDouble(vaccineExp), 7), 0);
        }
        else{
          Global.vaccineDevWeek = Global.vaccineDevWeek - 1;
        }
        
      }
      

      if (Global.refunded){
        Global.refunded = false;
        Global.vaccineDevSpent = 0;
        Global.vaccineDevWeek = 0;
      }

      // Vaccine Production
      if (Global.vaccineProdRate > 0){
        Global.vaccineNum = Global.vaccineNum + Rounding(Rnd.Dist(Global.vaccineProdRate, 35), 0);
      }

      // Vaccine Implementation

      if (Global.vaccineNum >= Global.vaccineImpRate && Global.developed){
        Global.vaccineNum = Global.vaccineNum - Global.vaccineImpRate;
        Global.popVaccin = Global.popVaccin + Rounding(Global.vaccineImpRate * Rnd.Dist(0.95, 0.02), 0);
      }
      else if (Global.vaccineNum > 0 && Global.developed){
        Global.popVaccin = Global.popVaccin + Global.vaccineNum;
        Global.vaccineNum = 0;
        Global.vaccineImpRate = 0;
        Global.vaccineImpSpent = 0;
      }
      else{
        Global.vaccineNum = 0;
        Global.vaccineImpRate = 0;
        Global.vaccineImpSpent = 0;
      }




      /*
      Main Background Calculations
      */





      // Week incrementer
      Global.week = Global.week + 1;

      // Total Avaliable Money
      Global.totalMoney = Global.totalMoney + Global.weekRevenue;

      // R Value
      Global.rValue = RValue(Global.alertLvl);

      // Protest Chance based on last week's Happiness
      if (Global.happiness >= Rnd.Dist(12.5,20)){
        Global.protest = false;
      }
      else{
        Global.protest = true;
      }
      
      if (Global.defenceRiotControl){
        if (Global.happiness >= Rnd.Dist(0,10)){
          Global.protest = false;
        }
        else{
          Global.protest = true;
        }
      }

      // Protests R0 Value
      if (Global.protest){
        Global.rValue = Rnd.Dist(5, 0.25);
      }


      // Happiness



      // Increases happiness by Health Education
      if (Global.educationHappiness > 0){
        Global.happiness = Global.happiness + Global.happiness * Global.educationHappiness;
      }

      // Decreases happiness due to prolonged lockdown
      if (Global.alertLvl >= 4){
        Global.consecLock = Global.consecLock + 1;
      }
      else if (Global.alertLvl >= 3){
        Global.consecLock = Global.consecLock + 0.5;
      }
      else{
        Global.consecLock = 0;
      }

      
      if (Global.consecLock > Rnd.Dist(8, 0.35)){
        Global.happiness = Global.happiness * Rnd.Dist(0.9, 0.0035);
      }

      // Decreases happiness due to number of active cases
      if (Global.population < Rnd.Dist(Global.activeCases, 1.6)){
        Global.happiness = Global.happiness * Rnd.Dist(0.5, 0.03);
      }
      else if (Global.population/2 < Rnd.Dist(Global.activeCases, 1.6)){
        Global.happiness = Global.happiness * Rnd.Dist(0.75, 0.015);
      }
      else if ((Global.population * 2)/3 < Rnd.Dist(Global.activeCases, 1.6)){
        Global.happiness = Global.happiness * Rnd.Dist(0.825, 0.015);
      }

      // Decreases happiness due to Forced Taxing rates
      if (Global.taxPercent > 0){
        Global.happiness = Global.happiness - Global.happiness * Rnd.Dist(Global.taxPercent * 0.75, 0.015);
      }

      // Active Cases

      if (Global.alertLvl <= 4 && Global.alertLvl >= 1){
        Global.activeCases = Rnd.Dist(Global.activeCases * Global.rValue, 0.305);
        if (Global.activeCases <= 1.5 && Global.alertLvl <= 3 && Global.alertLvl >= 1){
          if (Rnd.Dist(0,1) < 1){
            Global.activeCases = 0;
          }
          else{
            Global.activeCases = 1;
          }
        }
      }
      else{
        Global.activeCases = Rnd.Dist(Global.activeCases * Global.rValue, 0.6);  
      }

      // Border Cases
      Global.borderCases = Rounding(Rnd.Dist(25, 35), 0);
      Global.borderQuaranCases = Global.borderCases;

      if (Global.borderCases <= 0){
        Global.borderCases = 0;
      }

      if (Global.borderQuaranCases <= 0){
        Global.borderQuaranCases = 0;
      }

      if (Global.borderCases > Global.borderCap){
        Global.activeCases = Global.activeCases + (Global.borderQuaranCases - Global.borderCap);
      }

      if (Global.borderQuaranCases > Global.borderCap){
        Global.borderQuaranCases = Global.borderCap;
      }
      

      

      // Total Active Cases
      Global.totalActiveCases = Global.activeCases + Global.borderCases;

      // Total Cases
      Global.totalCases = Global.totalCases + Global.activeCases + Global.borderCases;

      // Population Growth Rate
      Global.popGrowthYear = Rnd.Dist(0.5 * Math.Log(Global.genHealthSpent + 10, 10) - 1.27, 0.0001);
      Global.popGrowth = Global.popGrowthYear/(365/7);


      // Other deaths
      if (Global.popGrowthYear < 0){
        Global.otherDeaths = Rounding(Global.population * Global.popGrowth * -1, 0);
      }

      if (Global.protest){
        Global.protestDeaths = Global.population * (1 - Global.happiness/100) * Rnd.Dist(0.025, 0.002);
        Global.totalProtestDeaths = Global.totalProtestDeaths + Global.protestDeaths;
      }
      else{
        Global.protestDeaths = 0;
      }

      // Death Rate
      Global.dieRate = Game.Rounding(Rnd.Dist(3.4, 0.01666667), 2);

      // Weekly Deaths
      Global.deathsWeek = Rnd.Dist((Global.dieRate/100) * Global.activeCases, 0.125);

      // Total Deaths
      Global.deaths = Global.deaths + Global.deathsWeek + Global.otherDeaths;


      // Population
      Global.population = Rnd.Dist(Global.population + Global.population * Global.popGrowth, 16);
      Global.population = Global.population - Global.deathsWeek - Global.protestDeaths;
      

      // Weekly Revenue
      if (Global.taxPercent == 0){
        Global.weekRevenue = Game.Rounding(Rnd.Dist(185, 2), 2) * Global.population * Global.happiness/100 * 2/(Global.alertLvl + 2) * 0.000001;
      }
      else{
        Global.weekRevenue = Game.Rounding(Rnd.Dist(185, 2), 2) * ((Global.population * (1 - Global.taxPercent)) * Global.happiness/100 * 2/(Global.alertLvl + 2) + Global.population * Global.taxPercent) * 0.000001;
      }


      

      // Rounds Global values

      Global.population = Rounding(Global.population, 0);
      Global.popGrowthYear = Rounding(Global.popGrowthYear, 4);
      Global.totalMoney = Rounding(Global.totalMoney, 2);
      Global.weekRevenue = Rounding(Global.weekRevenue, 1);
      Global.activeCases = Rounding(Global.activeCases, 0);
      Global.borderCases = Rounding(Global.borderCases, 0);
      Global.totalCases = Rounding(Global.totalCases, 0);
      Global.deathsWeek = Rounding(Global.deathsWeek, 0);
      Global.deaths = Rounding(Global.deaths, 0);
      Global.otherDeaths = Rounding(Global.otherDeaths, 0);
      Global.happiness = Rounding(Global.happiness, 1);
      Global.protestDeaths = Rounding(Global.protestDeaths, 0);
      Global.totalProtestDeaths = Rounding(Global.totalProtestDeaths, 0);

      // Constraints
      if (Global.population <= 0){
        Global.population = 0;
        Global.gameEnd = true;
      }
      if (Global.popVaccin >= Global.population){
        Global.popVaccin = Global.population;
      }
      if (Global.happiness >= 100){
        Global.happiness = 100;
      }
      if (Global.happiness <= 0){
        Global.happiness = 0;
      }
      if (Global.activeCases >= Global.population - Global.popVaccin){
        Global.activeCases = Global.population - Global.popVaccin;
      }
      if (Global.totalActiveCases - Global.borderCases > Global.population){
        Global.totalActiveCases = Global.borderCases + Global.activeCases;
      }
      if (Global.totalActiveCases <= 0){
        Global.totalActiveCases = 0;
      }
      if (Global.activeCases <= 0){
        Global.activeCases = 0;
      }
      if (Global.deaths <= 0){
        Global.deaths = 0;
      }
      if (Global.deathsWeek <= 0){
        Global.deathsWeek = 0;
      }

      if (Global.gameEnd == true){
        Console.Clear();

        Stats.Draw();

        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\tEveryone is dead");
        Console.WriteLine("\tThe virus has won");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\tNew Zealand has survived for {0} weeks", Global.week);
        Console.WriteLine("\tThank you for playing Covid Wars");
        Console.WriteLine("");
        Console.WriteLine("\t(0) Enter 0 to restart");
        Console.WriteLine("\tEnter anything else to Exit");
        Console.WriteLine("");
        Console.WriteLine("");

        string input = "";

        Console.Write("Your Input: ");

        input = Console.ReadLine();

        if (input == "0"){
          Func0.Restart();
        }
        Console.WriteLine("");
      }
      else{
        if (Global.week == 10000){
          Console.Clear();

          Stats.Draw();

          Console.WriteLine("");

          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.WriteLine("\tYou Win!");
          Console.WriteLine("\tNew Zealand has successfully survived for {0} weeks", Global.week);
          Console.WriteLine("");
          Console.WriteLine("\tAfter {0} weeks, Covid-19 has finally been defeated", Global.week);
          Console.WriteLine("\tAll {0} people who have died in the process", Global.deaths);
          Console.WriteLine("\tshall be commemorated with a full 10 seconds");
          Console.Write("\n\n\tPress Enter to commence commemoration");

          Console.ReadLine();

          for (int i = 1; i <= 10; i++){
            Console.WriteLine("\t" + i);
            Thread.Sleep(1000);
          }

          Console.WriteLine("");

          Console.WriteLine("\nClick Enter to Continue...");
          Console.ReadLine();
          
          Menu.CovidWars();

          Console.WriteLine("\nThank you for playing Covid Wars");

          Console.WriteLine("");
          Console.WriteLine("\t(0) Enter 0 to Exit");
          Console.WriteLine("\t(1) Enter 1 to continue game");
          

          bool check = false;
          string input = "";

          while (!check){
            Console.WriteLine("");
            Console.WriteLine("Your input: ");
            input = Console.ReadLine();
            if (input == "0" || input == "1"){
              check = true;
            }
            else{
              Console.WriteLine("Error: {0} is not a valid input", input);
            }
          }

          if (input == "1"){
            Menu.MenuProg();
          }
          else{
            Console.WriteLine("");
          }







        }
        else{
          Menu.MenuProg();
        }
        
      }

    }
    else{
      // User has spent too much money
      if (Global.totalSpent > Global.totalMoney){
        Global.overspent = true;
      }
      Menu.MenuProg();
    }
  }

  // Rounds decimal number to specified position

  public static double Rounding(double input, double rndValue){

    double output;

    input = input * Math.Pow(10, rndValue + 1);

    double temp = Convert.ToInt32(input);
    string nums = Convert.ToString(temp);

    char lastChar = nums[nums.Length - 1];

    // Reference Website for Char.GetNumericValue Method
    // https://docs.microsoft.com/en-us/dotnet/api/system.char.getnumericvalue?view=net-5.0
    double lastNum = Char.GetNumericValue(lastChar);

    if (lastNum >= 5){
      temp = temp - lastNum + 10;
    }
    if (lastNum < 5){
      temp = temp - lastNum;
    }

    output = temp/(Math.Pow(10, rndValue + 1));

    return output;

  }



  // Calculates Current population

  public static double Population(double popTotal, double popGrowth, double deaths){

    double popCurrent = popTotal;

    popCurrent = popCurrent - deaths;

    popCurrent = popCurrent*popGrowth;

    if (popCurrent < 1){
      return 0;
    }
    else{
      return Rounding(popCurrent, 0);
    }

  }


  // Calculates Current R value

  public static double RValue(int alertLvl){

    double output;

    switch (alertLvl){

      case 0:
        output = Rounding(Rnd.Dist(2.5, 0.1666667), 2);
        if (output > 0){
          return output;
        }
        else{
          return 0;
        }
      
      case 1:
        output = Rounding(Rnd.Dist(2, 0.1333333), 2);
        if (output > 0){
          return output;
        }
        else{
          return 0;
        }
      
      case 2:
        output = Rounding(Rnd.Dist(1.25, 0.1), 2);
        if (output > 0){
          return output;
        }
        else{
          return 0;
        }
      
      case 3:
        output = Rounding(Rnd.Dist(0.75, 0.0833333), 2);
        if (output > 0){
          return output;
        }
        else{
          return 0;
        }
      
      case 4:
        output = Rounding(Rnd.Dist(0.4, 0.0666667), 2);
        if (output > 0){
          return output;
        }
        else{
          return 0;
        }
      
      default:
        return 0;
    }
  }

}
