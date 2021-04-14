using System;
using System.Threading;

class Menu{


  /*
  The Main Menu of the Game
  */



  public static void GameDraw(){
    Console.Clear();
    GameMenuTitle();
    Stats.Draw();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("=========================================================");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(" Submit:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\t(Enter) Click Enter to Submit");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(" Government Options:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("\t(1) Covid-19 Announcment");
    if (Global.covidAnnSpent > 0){
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write("  Spending:  ${0} MM", Global.covidAnnSpent);
      Console.ForegroundColor = ConsoleColor.Yellow;
    }
    Console.WriteLine("");
    Console.Write("\t(2) General Health      ");
    if (Global.genHealthSpent > 0){
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write("  Spending:  ${0} MM", Global.genHealthSpent);
      Console.ForegroundColor = ConsoleColor.Yellow;
    }
    Console.WriteLine("");
    Console.Write("\t(3) Vaccination         ");
    if (Global.vaccineSpent != 0){
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write("  Spending:  ${0} MM", Global.vaccineSpent);
      Console.ForegroundColor = ConsoleColor.Yellow;
    }
    Console.WriteLine("");
    Console.Write("\t(4) Border Control      ");
    if (Global.borderSpent > 0){
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write("  Spending:  ${0} MM", Global.borderSpent);
      Console.ForegroundColor = ConsoleColor.Yellow;
    }
    Console.WriteLine("");
    Console.Write("\t(5) Military            ");
    if (Global.defenceSpent > 0){
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write("  Spending:  ${0} MM", Global.defenceSpent);
      Console.ForegroundColor = ConsoleColor.Yellow;
    }
    Console.WriteLine("");
    Console.Write("\t(6) Health Education    ");
    if (Global.educationSpent > 0){
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write("  Spending:  ${0} MM", Global.educationSpent);
      Console.ForegroundColor = ConsoleColor.Yellow;
    }
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(" Other:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\t(7) Return to Introduction");
    Console.WriteLine("\t(8) Help");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("=========================================================");

    if (Global.overspent){
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("The total money spent (${0}) is greater than \nthe amount of money avaliable (${1})", Global.totalSpent, Global.totalMoney);
    }

    Console.ForegroundColor = ConsoleColor.Yellow;
    
  }



  /*
  ASCII art title of the Main Menu

  Refernce Website 
  http://patorjk.com/software/taag/#p=display&f=Standard&t=Game%20Menu%3A
  */



  public static void GameMenuTitle(){
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("   ____                        __  __                    ");
    Console.WriteLine("  / ___| __ _ _ __ ___   ___  |  \u005C/  | ___ _ __  _   _ _ ");
    Console.WriteLine(" | |  _ / _` | '_ ` _ \u005C / _ \u005C | |\u005C/| |/ _ \u005C '_ \u005C| | | (_)");
    Console.WriteLine(" | |_| | (_| | | | | | |  __/ | |  | |  __/ | | | |_| |_ ");
    Console.WriteLine("  \u005C____|\u005C__,_|_| |_| |_|\u005C___| |_|  |_|\u005C___|_| |_|\u005C__,_(_)");
    Console.WriteLine("");
  }


  // The program part of the Main Menu
  // Directs players to other parts of the program

  public static void MenuProg(){
    string rawInput = "TBC";
    char input = '0';
    bool check = false;

    GameDraw();

    

    // Checks if player input is valid
    while (!check){
      
      Console.Write("\nYour Input: ");

      rawInput = Console.ReadLine();
      try{
        input = Convert.ToChar(rawInput);
        if (input >= 49 && input <= 56){
          check = true;
        }
        else{
          GameDraw();
          Console.WriteLine("\nError: '{0}' is not a valid input", rawInput);
        }
        
      }
      catch{
        if (rawInput == ""){
          check = true;
        }
        else{
          GameDraw();
        Console.WriteLine("\nError: '{0}' is not a valid input", rawInput);
        }
      }
    }

    // Directs player to corresponding menu
    switch (input){
      case '1':
        Func1.CovidAnnProg(Global.covidAnnPurch);
        break;
      case '2':
        Func2.HealthProg();
        break;
      case '3':
        Func3.VaccineProg();
        break;
      case '4':
        Func4.BorderProg();
        break;
      case '5':
        Func5.DefenceProg();
        break;
      case '6':
        Func6.EducationProg();
        break;
      case '7':
        Intro(true);
        break;
      case '8':
        Help();
        break;
      default:
        // Initiates all inputs and simulates Covid-19
        Game.Submit();
        break;
    }
  }



  /*
  Introduction
  Runs at beginning of Game
  */



  public static void Intro(bool started){
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    CovidWars();
    Console.WriteLine("");
    Console.WriteLine("\nWelcome to 21st century war fronts \nwhere Humanity fights against Covid-19. \n\nNew Zealand has by far the best control over \nCovid-19 compared to other countries. \nUnfortunately, since the world does NOT \nfight covid as well as New Zealand, \nnew strains of covid-19 appear randomly \ninto NZ when the borders are opened.");

    Thread.Sleep(3000);

    Console.WriteLine("\n\nClick Enter to Continue...");
    Console.ReadLine();
    Console.Clear();

    CovidWars();
    Console.WriteLine("\nIn this game, you are the leader of the NZ government\nfor managing Covid-19. \n\nYou are responsible for leading the country, \nprotecting the people \nand keeping the population happy and healthy.");

    Thread.Sleep(3000);

    Console.WriteLine("\n\nClick Enter to Continue...");
    Console.ReadLine();
    Console.Clear();

    CovidWars();
    Console.WriteLine("\nCurrently: \n\t\u2022 There are reports of 3 new imported cases in New Zealand\n\t\u2022 The R value is around 2.5\n\t\u2022 The Happiness level is around 90%");

    Console.WriteLine("\nThe R value is the infection rate of the virus.");

    Thread.Sleep(3000);

    if (!started){
      Console.WriteLine("\n\nClick Enter to Start...");
      Console.ReadLine();
      GameDraw();
      MenuProg();
    }
    else{
      Console.WriteLine("\n\nReturn to Game...");
      Console.ReadLine();
      GameDraw();
      MenuProg();
    }
    
    
  }



  /*
  Help Menu for more information
  */



  public static void Help(){
    Console.Clear();
    CovidWars();


    Console.WriteLine("");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("General:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("");
    Console.WriteLine("\tAt the start of game,");
    Console.WriteLine("\tPopulation begins at around 5 million");
    Console.WriteLine("\tGovernment starts with $40 billion dollars");
    Console.WriteLine("");
    Console.WriteLine("\tIn the Game Menu, each time the player clicks enter,");
    Console.WriteLine("\tthe game will move on to the next week and the game will perform a bunch of calculations");
    Console.WriteLine("\tbased on the player input to simulate the virus");
    Console.WriteLine("");
    Console.WriteLine("\tIf the player enters a number that corresponds to one of the");
    Console.WriteLine("\tnumbers on screen and in brackets, then that option will be selected");
    Console.WriteLine("");
    Console.WriteLine("\tWhen the player spends money in sub menus,");
    Console.WriteLine("\tthe amount spent will be displayed in the Game Menu");
    Console.WriteLine("");
    Console.WriteLine("");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Statistics Variables");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Government Money:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\tThe amount of money the government currently have");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Weekly Revenue");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\tThe estimated amount of money the government earns next week");
    Console.WriteLine("\tThis value is based on the current happiness and Alert Level");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Population:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\tThe current number of people alive in New Zealand");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Population growth rate:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\tThe rate at which the population grows per year (every 52 weeks)");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Happiness:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\tA measure of the percentage of people in total population willing to pay tax");
    Console.WriteLine("\tThis is affected by multiple factors in the game");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" R0 Value/R value:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\tThe reproduction rate of the virus in the given circumstance");
    Console.WriteLine("\tThis is affected by the current Alert Level and whether or not a protest is occuring");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Community Cases:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\tThe number of active cases in the community");
    Console.WriteLine("\tCommunity cases can be lowered by an R value below 1");
    Console.WriteLine("\tCommunity cases are capable of infecting the entire population");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Border Cases:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\tA random normally distributed number that simulates border cases");
    Console.WriteLine("\tBorder cases can overflow into community if border control isn't put in place");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Quarantined Border Cases:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\tThe number of border cases that are quarantined");
    Console.WriteLine("\tThis value has a maximum capacity that can be selected in border control");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Active Cases:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\tThe total number of community cases and border cases in this week");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Total Cases:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\tThe total number of community and border cases");
    Console.WriteLine("\tSince people can get re-infected multiple times,");
    Console.WriteLine("\tthis number tends to be greater than the initial population when the game finishes");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Death Rate:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\tA value that states the expected percentage of deaths based on current community cases");
    Console.WriteLine("\tThis value tends to average at 3.4%");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Covid Deaths:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\tTotal deaths caused by Covid-19");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Protest Deaths:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\tTotal deaths caused by Protests");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Other deaths:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\tTotal deaths caused by a negative population growth rate");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Total deaths:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\tA total of all deaths that occured in the length of the entire simulation");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Main Sub Menus");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("");
    Console.WriteLine("\tIn the Main Game Menu, the player has access to 8 different options");
    Console.WriteLine("\tThis includes:");
    Console.WriteLine("\tCovid 19 Announcement");
    Console.WriteLine("\tGeneral Health");
    Console.WriteLine("\tVaccination");
    Console.WriteLine("\tBorder Control");
    Console.WriteLine("\tMillitary");
    Console.WriteLine("\tHealth Education");
    Console.WriteLine("");
    Console.WriteLine("\tAll 6 options listed above are sub menus that have a unique function");
    Console.WriteLine("");
    Console.WriteLine("\tThe 7th option is return to Introduction and the");
    Console.WriteLine("\t8th option directs player to this help menu");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Covid 19 Announcement");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("");
    Console.WriteLine("\tWhen game begins, the player will be required to purchase a starter fund of $10 million");
    Console.WriteLine("\tAfter purchased, the player will be able to change alert levels");
    Console.WriteLine("\tAlert Levels controls the R0 value (R value)");
    Console.WriteLine("");
    Console.WriteLine("\tWhen borders are open, R value averages at 2.5");
    Console.WriteLine("\tWhen Alert Level 1, R value averages at 2");
    Console.WriteLine("\tWhen Alert Level 2, R value averages at 1.25");
    Console.WriteLine("\tWhen Alert Level 3, R value averages at 0.75");
    Console.WriteLine("\tWhen Alert Level 4, R value averages at 0.4");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" General Health");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("");
    Console.WriteLine("\tThis is a fund that the govenment is required to pay weekly");
    Console.WriteLine("\tIt controls the population growth rate");
    Console.WriteLine("\tIf the money input is too low, the population will decrease so be sure to manage it well");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Vaccination");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("");
    Console.WriteLine("\tVaccine Development is used for developing vaccines");
    Console.WriteLine("\tVaccine Production is the amount of vaccines produced every week");
    Console.WriteLine("\tA vaccine must be developed before producing/manufacturing them");
    Console.WriteLine("\tVaccine Implementation is the amount of people the government vaccinates every week");
    Console.WriteLine("\tThere must be vaccines in order to implement them");
    Console.WriteLine("\tNotice the main menu displays the current number of vaccines and the people vaccinated");
    Console.WriteLine("\tThe vaccine can also expire so be sure to be ready for it when it happens");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Border Control");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("");
    Console.WriteLine("\tBorder control is used to control the maximum capacity of cases");
    Console.WriteLine("\tquarantine facilities can hold in the border");
    Console.WriteLine("\tThis is important because border cases will always occur and if not managed,");
    Console.WriteLine("\tthe border cases will spill into the community creating community cases");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Military/Defense");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("");
    Console.WriteLine("\tWhen the happiness percentage gets too low, protest/riots occuring will increase");
    Console.WriteLine("\tThe first option Protest/Riot control is used to lower the chances");
    Console.WriteLine("\tof a protest/riot occuring");
    Console.WriteLine("\tThe other options below is used to force the population to pay full tax");
    Console.WriteLine("\tregardless of their current happiness level");
    Console.WriteLine("\tBut note that this will definetly have a negative impact on the happiness of the population");
    Console.WriteLine("\tso be cautious when using it");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" Health Education");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("");
    Console.WriteLine("\tThis section holds all the possible methods the government can increase happiness");
    Console.WriteLine("\tThe more happiness the option grants, the more costly it becomes");



    Console.WriteLine("\n\nClick Enter to Return to Game...");
    Console.ReadLine();
    Console.Clear();
    MenuProg();
  }



  /*
  Loading Screen
  */



  public static void LoadingSub(int type){

    string keyWord = "";

    if (type == 0){
      keyWord = "Cancelling";
    }
    if (type == 1){
      keyWord = "Submitting";
    }
    if (type == 2){
      keyWord = "Refunding";
    }

    Random rnd = new Random();

    int loadTimes = rnd.Next(2,5);

    Console.ForegroundColor = ConsoleColor.Yellow;

    for (int i = 0; i < loadTimes; i++){
      for (int dot = 0; dot <= 3; dot++){
        Console.Clear();
        Console.WriteLine(keyWord + " purchase" + new string('.', dot));
        Thread.Sleep(250);
      }
    }

  }



  /*
  Draws Title of Game
  Appears at Introduction

  Refernce Website
  http://patorjk.com/software/taag/#p=display&f=Standard&t=Game%20Menu%3A
  */



  public static void CovidWars(){
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("  ______   ______   ____    ____  __   _______  ");
    Console.WriteLine(" /      | /  __  \u005C  \u005C   \u005C  /   / |  | |       \u005C ");
    Console.WriteLine("|  ,----'|  |  |  |  \u005C   \u005C/   /  |  | |  .--.  |");
    Console.WriteLine("|  |     |  |  |  |   \u005C      /   |  | |  |  |  |");
    Console.WriteLine("|  `----.|  `--'  |    \u005C    /    |  | |  '--'  |");
    Console.WriteLine(" \u005C______| \u005C______/      \u005C__/     |__| |_______/ ");
    Console.WriteLine("                                                ");

    Console.WriteLine("____    __    ____  ___      .______          _______.");
    Console.WriteLine("\u005C   \u005C  /  \u005C  /   / /   \u005C     |   _  \u005C        /       |");
    Console.WriteLine(" \u005C   \u005C/    \u005C/   / /  ^  \u005C    |  |_)  |      |   (----`");
    Console.WriteLine("  \u005C            / /  /_\u005C  \u005C   |      /        \u005C   \u005C    ");
    Console.WriteLine("   \u005C    /\u005C    / /  _____  \u005C  |  |\u005C  \u005C----.----)   |   ");
    Console.WriteLine("    \u005C__/  \u005C__/ /__/     \u005C__\u005C | _| `._____|_______/    ");

  }
}