using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
       
        static void Main(string[] args)
{
        Random rng = new Random ();
           bool cont;
        List<string> activities = new List<string>() {"Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };


        Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            //cont = bool.Parse(Console.ReadLine());
           var randAct = Console.ReadLine();
            switch (randAct.ToLower())
            {
                case "yes":
                case "y":
                    cont = true;
                    break;
                case "no":
                case "n":
                    cont = false;
                    Console.WriteLine("Sorry to hear that. Come back soon!");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
                default:
                    cont = false;
                    Console.WriteLine("Sorry to hear that. Come back soon!");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
            }
    Console.WriteLine();
    Console.Write("We are going to need your information first! What is your name? ");
    string userName = Console.ReadLine();
    Console.WriteLine();

            bool canParse = false;
            int userAge = 0;
            while (canParse == false)
                {
                Console.Write("What is your age? ");
                canParse = Int32.TryParse(Console.ReadLine(), out userAge);
            }
    Console.WriteLine();
    Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            bool seeList;

            var seeListAns = Console.ReadLine();
            switch (seeListAns.ToLower())
            {
                case "yes":
                case "y":
                case "sure":
                case "s":
                    seeList = true;
                    break;
                case "no":
                case "n":
                case "no thanks":
                case "nt":
                    seeList = false;
                    break;
                default:
                    seeList = false;
                    break;
            }


            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
            }
        Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                bool addToList;
                var addToListAns = Console.ReadLine();
                switch (addToListAns.ToLower())
                {
                    case "yes":
                    case "y":
                        addToList = true;
                        break;
                    case "no":
                    case "n":
                        addToList = false;
                        break;
                    default:
                        addToList = false;
                        break;
                }
                while (addToList)
        {
            Console.Write("What would you like to add? ");
            string userAddition = Console.ReadLine();
            activities.Add(userAddition);
            foreach (string activity in activities)
            {
                Console.Write($"{activity} ");
                Thread.Sleep(250);
            }
            Console.WriteLine();
            Console.WriteLine("Would you like to add more? yes/no: ");
                    addToListAns = Console.ReadLine();

                    switch (addToListAns.ToLower())
                    {
                        case "yes":
                        case "y":
                            addToList = true;
                            break;
                        case "no":
                        case "n":
                            addToList = false;
                            break;
                        default:
                            addToList = false;
                            break;
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
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Let's pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }

                
                
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();

                var keepOrRedo = Console.ReadLine();

                switch (keepOrRedo.ToLower())
                {
                    case "keep":
                    case "yes":
                    case "y":
                        cont = false;
                            Console.WriteLine("Thank you for choosing an activity! Enjoy!");
                        Console.ReadLine();
                        break;
                    case "no":
                    case "redo":
                    case "n":
                        cont = true;
                        break;
                    default:
                        cont = false;
                            Console.WriteLine("Thank you for choosing an activity! Enjoy!");
                        Console.ReadLine();
                        break;
                }
            
            }
}
    }
}