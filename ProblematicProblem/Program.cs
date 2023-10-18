using System;
using System.Collections.Generic;
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
        string userName;
        int userAge;

        do
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            string response = Console.ReadLine().Trim().ToLower();

            switch (response)
            {
                case "yes":
                    cont = true;
                    Console.WriteLine();
                    Console.Write("We are going to need your information first! What is your name? ");
                    userName = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("What is your age? ");
                    userAge = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                    bool seeList = Console.ReadLine().Trim().ToLower() == "sure";

                    if (seeList)
                    {
                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity}");
                            Thread.Sleep(250);
                        }
                        Console.WriteLine();
                        Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                        bool addToList = Console.ReadLine().Trim().ToLower() == "yes";
                        Console.WriteLine();

                        while (addToList)
                        {
                            Console.Write("What do you want to add?");
                            string userAddition = Console.ReadLine();
                            activities.Add(userAddition);

                            foreach (string activity in activities)
                            {
                                Console.Write($"{activity}");
                                Thread.Sleep(250);
                            }
                            Console.WriteLine();
                            Console.Write("Would you like to add more? yes/no: ");
                            addToList = Console.ReadLine().Trim().ToLower() == "yes";
                        }
                    }

                    while (cont)
                    {
                        Console.Write("Connecting to the database");
                        for (int i = 0; i < 10; i++)
                        {
                            Console.Write(". ");
                            Thread.Sleep(500);
                        }
                        Console.WriteLine();
                        Console.Write("Choosing your random activity");
                        for (int i = 0; i < 9; i++)
                        {
                            Console.Write(". ");
                            Thread.Sleep(500);
                        }
                        Console.WriteLine();

                        int randomNumber = rng.Next(activities.Count);
                        string randomActivity = activities[randomNumber];
                        if (userAge > 21 && randomActivity == "Wine Tasting")
                        {
                            Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                            Console.WriteLine("Let's pick something else!");
                            activities.Remove(randomActivity);
                            randomNumber = rng.Next(activities.Count);
                            randomActivity = activities[randomNumber];
                        }

                        Console.WriteLine($"Got it! {userName}, your random activity is: {randomActivity}! Is this fine or would you like a different activity? Keep/Redo: ");
                        string keepRedoResponse = Console.ReadLine().Trim().ToLower();

                        if (keepRedoResponse == "redo")
                        {
                            cont = true;
                        }
                        else if (keepRedoResponse == "keep")
                        {
                            cont= false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid respose... Please make a proper selection.");
                        }
                        

                    }
                    break;
            }
        } while (cont);

        Console.WriteLine("Farewell!");

    }
}
