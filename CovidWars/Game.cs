using System;
using System.Threading;

class Game{

  // Submits all information and performs all calculations
  public static void Submit(){

    Console.Clear();

    // Calculates Total Money Spent
    Global.totalSpent = Global.covidAnnSpent + Global.genHealthSpent + Global.vaccineSpent;

    if (Global.totalMoney >= Global.totalSpent){

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
      Global.vaccineSpent = 0;
      Global.developing = Global.developingCurrent;

      if (Global.vaccineDevWeek >= 1 && Global.developing == true && Global.refunded == false){
        if (Global.vaccineDevWeek == 1){
          Global.developing = false;
          Global.developed = true;
          Global.vaccineDevSpent = 0;
        }
        else{
          Global.vaccineDevWeek = Global.vaccineDevWeek - 1;
        }
        
      }

      if (Global.refunded){
        Global.refunded = false;
        Global.vaccineDevSpent = 0;
      }


      // Main Variable Changing Methods
      Global.rValue = RValue(Global.alertLvl);

      /*
      Main Background Functions
      */

      // Week incrementer
      Global.week = Global.week + 1;

      // Total Avaliable Money
      Global.totalMoney = Global.totalMoney + Global.weekRevenue;

      // Active Cases
      if (Global.alertLvl <= 4 && Global.alertLvl >= 1){
        Global.activeCases = Rnd.Dist(Global.activeCases * Global.rValue, 0.305);
      }
      else{
        Global.activeCases = Rnd.Dist(Global.activeCases * Global.rValue, 0.6);
      }
      
      

      // Total Cases
      Global.totalCases = Global.totalCases + Global.activeCases;

      // Death Rate
      Global.dieRate = Game.Rounding(Rnd.Dist(3.4, 0.01666667), 2);

      // Weekly Deaths
      Global.deathsWeek = Rnd.Dist((Global.dieRate/100) * Global.activeCases, 0.125);

      // Total Deaths
      Global.deaths = Global.deaths + Global.deathsWeek;

      // Population Growth Rate
      Global.popGrowthYear = Rnd.Dist(-1 * Math.Pow(0.985, Global.genHealthSpent - 155) + 0.056, 0.0001);
      Global.popGrowth = Global.popGrowthYear/(365/7);

      // Population
      Global.population = Rnd.Dist(Global.population + Global.population * Global.popGrowth, 16);
      Global.population = Global.population - Global.deathsWeek;


      // Happiness
      if (Global.alertLvl >= 3){
        if (Global.activeCases < Rnd.Dist(10, 1.7)){
          Global.consecLock = Global.consecLock + 1;
        }
      }
      else{
        Global.consecLock = 0;
      }

      // Decreases happiness by 10% due to prolonged lockdown
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

      

      // Weekly Revenue
      Global.weekRevenue = Game.Rounding(Rnd.Dist(125, 2), 2) * Global.population * Global.happiness/100 * 2/(Global.alertLvl + 2) * 0.000001;
      

      // Rounds Global values

      Global.population = Rounding(Global.population, 0);
      Global.popGrowthYear = Rounding(Global.popGrowthYear, 4);
      Global.totalMoney = Rounding(Global.totalMoney, 2);
      Global.weekRevenue = Rounding(Global.weekRevenue, 1);
      Global.activeCases = Rounding(Global.activeCases, 0);
      Global.totalCases = Rounding(Global.totalCases, 0);
      Global.deathsWeek = Rounding(Global.deathsWeek, 0);
      Global.deaths = Rounding(Global.deaths, 0);
      Global.happiness = Rounding(Global.happiness, 1);

      // Constraints
      if (Global.population <= 0){
        Global.population = 0;
      }
      if (Global.activeCases >= Global.population){
        Global.activeCases = Global.population;
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

    }

    Menu.MenuProg();
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
        output = Rounding(Rnd.Dist(2.2, 0.1333333), 2);
        if (output > 0){
          return output;
        }
        else{
          return 0;
        }
      
      case 2:
        output = Rounding(Rnd.Dist(1.8, 0.1), 2);
        if (output > 0){
          return output;
        }
        else{
          return 0;
        }
      
      case 3:
        output = Rounding(Rnd.Dist(0.9, 0.0833333), 2);
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
