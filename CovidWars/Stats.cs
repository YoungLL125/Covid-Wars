using System;

class Stats{

  // rValue, popTotal, popGrowth, happiness, money, activeCases, currentCases, totalCases

  public static void Draw(){
    
    Console.ForegroundColor = ConsoleColor.Magenta;

    Console.WriteLine("=========================================================");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(" Current Statistics:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("");
    Console.WriteLine("\t            Week:\t{0}", Global.week);
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\tGovernment Money:\t${0} MM", Global.totalMoney);
    if (Global.weekRevenue >= 100){
      Console.ForegroundColor = ConsoleColor.Green;
    }
    else if (Global.weekRevenue >= 10){
      Console.ForegroundColor = ConsoleColor.Yellow;
    }
    else{
      Console.ForegroundColor = ConsoleColor.Red;
    }
    Console.WriteLine("\t  Weekly Revenue:\t${0} MM", Game.Rounding(Global.weekRevenue, 1));
    if (Global.population >= 25000000){
      Console.ForegroundColor = ConsoleColor.Green;
    }
    else if (Global.population >= 50000){
      Console.ForegroundColor = ConsoleColor.Yellow;
    }
    else if (Global.population >= 100){
      Console.ForegroundColor = ConsoleColor.Red;
    }
    else{
      Console.ForegroundColor = ConsoleColor.DarkRed;
    }
    Console.WriteLine("\t      Population:\t{0} people", Game.Rounding(Global.population, 0));
    if (Global.popGrowthYear > 0){
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("\t Pop Growth Rate:\t+{0}% per year", Game.Rounding(Global.popGrowthYear*100, 2));
    }
    else if (Global.popGrowthYear >= 0.5 && Global.popGrowthYear <= 0){
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("\t Pop Growth Rate:\t{0}% per year", Game.Rounding(Global.popGrowthYear*100, 2));
    }
    else{
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("\t Pop Growth Rate:\t{0}% per year", Game.Rounding(Global.popGrowthYear*100, 2));
    }
    
    if (Global.happiness >= 75){
      Console.ForegroundColor = ConsoleColor.Green;
    }
    else if (Global.happiness >= 50){
      Console.ForegroundColor = ConsoleColor.Yellow;
    }
    else{
      Console.ForegroundColor = ConsoleColor.Red;
    }
    Console.WriteLine("\t       Happiness:\t{0}%", Game.Rounding(Global.happiness, 1));
    if (Global.rValue < 1){
      Console.ForegroundColor = ConsoleColor.Green;
    }
    else{
      Console.ForegroundColor = ConsoleColor.Red;
    }
    Console.WriteLine("\t        R0 Value:\t{0}", Game.Rounding(Global.rValue, 2));
    if (Global.activeCases == 0){
      Console.ForegroundColor = ConsoleColor.Green;
    }
    else if (Global.population/2 >= Global.activeCases){
      Console.ForegroundColor = ConsoleColor.Yellow;
    }
    else{
      Console.ForegroundColor = ConsoleColor.Red;
    }
    Console.WriteLine("\t Community Cases:\t{0}", Game.Rounding(Global.activeCases, 0));
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\t    Border Cases:\t{0}", Game.Rounding(Global.borderCases, 0));
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("\t    Active Cases:\t{0}", Game.Rounding(Global.totalActiveCases, 0));
    Console.WriteLine("\t     Total Cases:\t{0}", Game.Rounding(Global.totalCases, 0));
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("\t      Death Rate:\t{0}%", Game.Rounding(Global.dieRate, 2));
    Console.WriteLine("");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(" This Week's Deaths:");

    if (Global.deathsWeek == 0){
      Console.ForegroundColor = ConsoleColor.Green;
    }
    else{
      Console.ForegroundColor = ConsoleColor.Red;
    }
    Console.WriteLine("\t    Covid Deaths:\t{0}", Game.Rounding(Global.deathsWeek, 0));
    if (Global.protestDeaths == 0){
      Console.ForegroundColor = ConsoleColor.Green;
    }
    else{
      Console.ForegroundColor = ConsoleColor.Red;
    }
    Console.WriteLine("\t  Protest Deaths:\t{0}", Game.Rounding(Global.protestDeaths, 0));
    if (Global.otherDeaths == 0){
      Console.ForegroundColor = ConsoleColor.Green;
    }
    else{
      Console.ForegroundColor = ConsoleColor.Red;
    }
    Console.WriteLine("\t    Other Deaths:\t{0}", Game.Rounding(Global.otherDeaths, 0));

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(" Total Deaths:");

    if (Global.deaths == 0){
      Console.ForegroundColor = ConsoleColor.Green;
    }
    else{
      Console.ForegroundColor = ConsoleColor.DarkRed;
    }
    if (Global.totalProtestDeaths != 0){
      Console.WriteLine("    Total Protest Deaths:\t{0}", Game.Rounding(Global.totalProtestDeaths, 0));
    }
    Console.WriteLine("\t    Total Deaths:\t{0}", Game.Rounding(Global.deaths, 0));
    
    Console.WriteLine("");
    if (Global.protest){
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine(" Warning: A protest has occured");
      Console.WriteLine("\tProtest Deaths:\t{0}", Game.Rounding(Global.protestDeaths, 0));
      Console.WriteLine("");
    }
    else{
      Console.WriteLine("");
      Console.WriteLine("");
      Console.WriteLine("");
    }
    if (Global.alertLvl > 0){
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("\t   Alert Level:\t{0}", Global.alertLvl);
    }
    if (Global.vaccineNum > 0){
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("\t    No. Vaccines:\t{0}", Global.vaccineNum);
    }
    if (Global.popVaccin > 0){
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("   No. People Vaccinated:\t{0}", Global.popVaccin);
    }
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("=========================================================");
    Console.WriteLine("");

  }

  
}