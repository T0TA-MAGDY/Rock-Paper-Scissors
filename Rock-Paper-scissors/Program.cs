using System;
using System.Runtime.Remoting.Messaging;

namespace Rock_Paper_scissors
{
    // Enum class to ease readability 
    public enum choice { rock =1,paper ,scissors } // auto numbering 
    internal class Program
    {
        static void Main(string[] args)
        {
            // the game will repeat itself if the player wants toplay again
            int play = 1;
            while (play>0)
            {
                Console.WriteLine("Welcome to rock-paper-scissors game");
                Console.WriteLine("make your choice");
                Console.Write("for rock click 1\nfor paper click 2\nfor scissors click 3 :");
                // computer playing randomly for fairness 
                Random rnd = new Random();
                choice computerchoice = (choice)rnd.Next(1, 4);
                choice userchoice;
                // checking for invalid inputs 
                while (!Enum.TryParse(Console.ReadLine(), out userchoice) || !Enum.IsDefined(typeof(choice), userchoice))
                {
                    Console.Write("invaild choice , please choose 1,2 or 3 : ");
                }
                Console.WriteLine($"you chose {userchoice}");
                Console.WriteLine($"computer (randomly) chose {computerchoice}");
                Console.WriteLine("soooo........");
                Console.WriteLine($"{determinewinner(computerchoice, userchoice)}");
                Console.Write("toplay again press 1 to exit press 0 : ");
                while (!int.TryParse(Console.ReadLine(), out play))
                {
                    Console.Write("invaild choice , please choose 0 or 1 : ");
                }
            }
           

        }
        static string determinewinner (choice computerchoice , choice userchoice)
        {
            if (computerchoice == userchoice) return "it's a tie!";
            switch (computerchoice) 
            {
                case choice.rock:
                    return userchoice == choice.paper ? "paper covers rock ,you win :)" : "rock crushes scissors ,you lose :(";
                case choice.scissors:
                    return userchoice == choice.rock ? "rock crushes scissors ,you win :)" : "scissors cut paper ,you lose :(";
                case choice.paper:
                    return userchoice == choice.scissors ? "scissors cut paper ,you win :)" : "paper covers rock ,you lose :(";
                default:
                    return "invaild choice"; // won't ever be used because we validate choices before caliing the function 
            }
        }

    }
}