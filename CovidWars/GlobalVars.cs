using System;

// Special Thanks to this website below as global variables are the backbone of this game
// https://www.arclab.com/en/kb/csharp/global-variables-fields-functions-static-class.html


// rValue, popTotal, popGrowth, happiness, money, activeCases, totalCases

class Global{


  /*
  Main Global Varibles
  */


  // Week Counter
  public static int week;

  // Money
  public static double totalMoney;
  public static double weekRevenue;
  public static double totalSpent;
  public static bool overspent;

  // Population
  public static double population;
  public static double popGrowth;
  public static double popGrowthYear;

  // Happiness
  public static double happiness;

  // R0 Value
  public static double rValue;

  // Covid Cases
  public static double totalCases;
  public static double activeCases;
  public static double borderCases;
  public static double totalActiveCases;

  // Death
  public static double deaths;
  public static double deathsWeek;
  public static double dieRate;

  // Consecutive weeks of Lockdown after Active cases reaches 0
  public static double consecLock;

  // Vaccinated people
  public static double popVaccin;

  // Game End
  public static bool gameEnd;


  /*
  Functions
  */


  // Function 1 CovidAnn
  public static double covidAnnSpent;
  public static bool covidAnnPurch;
  public static bool covidAnnPurchCurrent;
  public static int alertLvl;
  public static int alertLvlCurrent;


  // Function 2 GeneralHealth
  public static double genHealthSpent;

  // Function 3 Vaccination

  // Vaccine Development
  public static double vaccineSpent;
  public static double vaccineDevSpent;
  public static double vaccineDevWeek;
  public static bool developing;
  public static bool developingCurrent;
  public static bool developed;
  public static bool refunded;


  // Vaccine Production
  public static double vaccineNum;
  public static double vaccineProdSpent;
  public static double vaccineProdRate;
  

  // Vaccine Implementation
  public static double vaccineImpSpent;
  public static double vaccineImpRate;
  

  // Function 4 Border Restrictions
  public static double borderSpent;
  public static double borderCap;
}