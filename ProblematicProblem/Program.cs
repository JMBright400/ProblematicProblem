using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;



class Program
{
    static Random rng = new Random();
    static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

    static void Main(string[] args)
    {
        bool cont = true;
        string userName = "";
        int userAge = 0; 
        bool seeList = false;
        bool addToList = false;

        do
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            string response = Console.ReadLine().Trim().ToLower();

            switch (response)
            {


                case "yes":
                    cont = true;
                    Console.WriteLine("We are going to need your information first!");
                    Console.Write("What is your name? ");
                    userName = Console.ReadLine();
                    Console.Write("What is your age? ");

                    if (!int.TryParse(Console.ReadLine(), out userAge))
                    {
                        Console.WriteLine("Invalid age. Please enter numbers only.");
                        continue;
                    }


                    Console.WriteLine();
                    Console.Write("Would you like to see the current list of activities? (Yes/No): ");
                    seeList = Console.ReadLine().Trim().ToLower() == "yes";
                    break;

                case "no":
                    Console.WriteLine("Thanks for stopping by. Feel free to visit the activity generator again in the future!");
                    cont = false;
                    break;

                default:
                    Console.WriteLine("Invalid selection. Please try again!");
                    break;
                 }
                 if (seeList)
                 {
                 DisplayActivities();
                 Console.Write("Would you like to add any activities before we generate one? (Yes/No): ");
                 addToList = Console.ReadLine().Trim().ToLower() == "yes";

                while (addToList)
                {
                    Console.Write("What do you want to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    DisplayActivities();

                    Console.Write("What do you want to add? ");
                    addToList = Console.ReadLine().Trim().ToLower() == "yes";
                }
            }

            while (cont)
            {
                Console.WriteLine("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.WriteLine("Selecting your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();

                string randomActivity = GenerateRandomActivity(userAge);

                Console.Write($"Got it, {userName}! Your random activity is: {randomActivity}! Is this fine or would you like a different activity? (Keep/Redo:)");
                string keepRedoResponse = Console.ReadLine().Trim().ToLower();

                if (keepRedoResponse == "redo")
                {
                    cont = true;
                }
                else if (keepRedoResponse == "keep")
                {
                    cont = false;
                }
                else
                {
                    Console.WriteLine("Invalid response. Please make a proper selection.");
                }
            }
        } while (cont);

        Console.WriteLine("Farewell!");
      }
    static void DisplayActivities()
    {
        Console.WriteLine("Current list of activities:");
        foreach (string activity in activities)
        {
            Console.WriteLine(activity);
            Thread.Sleep(250);
        }
    }

    static string GenerateRandomActivity(int userAge)
    {
        int randomNumber;
        string randomActivity;

        do
        {
            randomNumber = rng.Next(activities.Count);
            randomActivity = activities[randomNumber];
        } while (userAge < 21 && randomActivity == "Wine Tasting");

        return randomActivity;
    }
}

       