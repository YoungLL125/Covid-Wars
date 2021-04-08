using System;

namespace CovidWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            // Presets all the global variables

            // Main Variables
            Global.week = 0;
            Global.totalMoney = 40000;
            Global.totalSpent = 0;
            Global.population = Game.Rounding(Rnd.Dist(5000000, 2000), 0);
            Global.popGrowthYear = Rnd.Dist(0.01, 0.0001);
            Global.popGrowth = Global.popGrowthYear/(52.14286);
            Global.happiness = Game.Rounding(Rnd.Dist(90, 0.2), 1);
            Global.rValue = Game.Rounding(Rnd.Dist(2.5, 0.1666667), 2);
            Global.totalCases = 3;
            Global.activeCases = 3;
            Global.deaths = 0;
            Global.dieRate = Game.Rounding(Rnd.Dist(3.4, 0.01666667), 2);

            // Consecutive Lockdowns after Active Cases Reaches 0
            Global.consecLock = 0;

            // Weekly Revenue
            Global.weekRevenue = Game.Rounding(Rnd.Dist(125, 2), 2) * Global.population * Global.happiness/100 * 0.000001;

            // Function 1 CovidAnn
            Global.covidAnnPurch = false;
            Global.covidAnnPurchCurrent = false;
            Global.alertLvl = 0;

            // Function 2 GenHealth
            Global.genHealthSpent = 360;

            // Function 3 Vaccine
            Global.vaccineSpent = 0;
            Global.developing = false;
            Global.vaccineDevSpent = 0;

            Menu.Intro(false);
        }
    }
}
