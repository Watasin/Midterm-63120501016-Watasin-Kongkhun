using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string selectMenu;

            Console.WriteLine("Welcome to Hangman Game");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("    1.Play game");
            Console.WriteLine("    2.Exit");
            Console.Write("Please Select Menu:");

            selectMenu = Console.ReadLine();

            if (selectMenu == "1")
            {
                Hangman.initHangman();
            }
            else
            {
                Environment.Exit(0);
            }

        }
    }

    static class Hangman
    {
        private static int incorrect_score = 0;
        private static int correct_score = 0;
        private static string[] randomWord = { "Tennis", "Football", "Badminton" };
        private static string randomString;
        private static string[] hangmanString;

        public static void initHangman()
        {
            string inputString;

            clearscreen();

            randomString = randomWord[Next(0, 3)];

            hangmanString = new String[randomString.Length];

            Console.WriteLine("Play Game Hangman");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Incorrect Score: " + incorrect_score);

            Console.WriteLine("");
            for (int i = 0; i <= randomString.Length - 1; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Input letter alphabet:");

            inputString = Console.ReadLine();

            playHangman(inputString);
        }

        public static void playHangman(string inputString)
        {
            bool match = false;

            clearscreen();



            for (int i = 0; i <= randomString.Length - 1; i++)
            {
                if (randomString[i].ToString() == inputString && hangmanString[i] == null)
                {
                    match = true;
                    correct_score++;
                    hangmanString[i] = inputString;
                    break;
                }
            }

            if (match == false)
            {
                incorrect_score++;
            }

            Console.WriteLine("Play Game Hangman");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Incorrect Score: " + incorrect_score);
            Console.WriteLine("");

            for (int i = 0; i <= hangmanString.Length - 1; i++)
            {
                if (hangmanString[i] == null)
                {
                    Console.Write("-");
                }
                else
                {
                    Console.Write(hangmanString[i]);
                }

            }
            Console.WriteLine("");
            Console.WriteLine("");
            if (incorrect_score == randomString.Length)
            {
                Console.WriteLine("Game Over");
                Sleep(5);
                Environment.Exit(0);
            }
            else if (correct_score == randomString.Length)
            {
                Console.WriteLine("You win!!");
                Sleep(5);
                Environment.Exit(0);
            }
            else
            {
                Console.Write("Input letter alphabet:");

                inputString = Console.ReadLine();

                playHangman(inputString);
            }



        }

        private static void Sleep(int v)
        {
            Thread.Sleep(5);
        }

        static void clearscreen()
        {
            Console.Clear();
        }

        static int Next(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
