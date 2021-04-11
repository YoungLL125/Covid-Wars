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
    Console.Write("\t(5) Military             ");
    if (Global.defenceSpent > 0){
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write("  Spending:  ${0} MM", Global.defenceSpent);
      Console.ForegroundColor = ConsoleColor.Yellow;
    }
    Console.WriteLine("");
    Console.WriteLine("\t(6) Health Education");
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

    // Thread.Sleep(3000);

    Console.WriteLine("\n\nClick Enter to Continue...");
    Console.ReadLine();
    Console.Clear();

    CovidWars();
    Console.WriteLine("\nIn this game, you are the leader of the NZ government\nfor managing Covid-19. \n\nYou are responsible for leading the country, \nprotecting the people \nand keeping the population happy and healthy.");

    // Thread.Sleep(3000);

    Console.WriteLine("\n\nClick Enter to Continue...");
    Console.ReadLine();
    Console.Clear();

    CovidWars();
    Console.WriteLine("\nCurrently: \n\t\u2022 There are reports of 3 new imported cases in New Zealand\n\t\u2022 The R value is around 2.5\n\t\u2022 The Happiness level is around 90%");

    Console.WriteLine("\nThe R value is the infection rate of the virus.");

    // Thread.Sleep(3000);

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

  *** Under Construction ***
  */



  public static void Help(){
    Console.Clear();
    CovidWars();
    Console.WriteLine("");


    Console.WriteLine("Work it out yourself");


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