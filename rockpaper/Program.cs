using NBitcoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace rockpaper
{
    class Program
    {
        static void Main(string[] args)
        {        
            if (args.Length < 3)
            {
                Console.WriteLine("--------Arguments must be more than 3--------");
                Environment.Exit(0);
            }
            if (args.Length % 2 == 0)
            {
                Console.WriteLine("--------The number of arguments must be odd--------");
                Environment.Exit(0);
            }
            for (int i = 0; i < args.Length; i++)
            {
                for (int j = i; j < args.Length; j++)
                {
                    if (args[i] == args[j] && j != i)
                    {
                        Console.WriteLine("--------There must be no duplicate arguments--------");
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine("Availavle moves:");
            for (int i =1;i <= args.Length; i++)
            {
                Console.WriteLine($"{i} - {args[i - 1]}");
            }
            Console.WriteLine("0 - exit \n? - help");


            while (true)
            {

                int computerMove = Hash.GenerateComputerMove(args);
                byte[] HMACKey = Hash.GenerateKey();
                byte[] HMAC = Hash.GenerateHMAC(args, computerMove, HMACKey);
                Console.Write("HMAC: ");
                Print256(HMAC);
                Console.WriteLine("");
                Console.Write("Enter value: ");
                string answer = Console.ReadLine();              
                if(answer == "0")
                {
                    break;
                }
                else if(answer == "?")
                {
                    Help.CreateTable(args);
                }
                else
                {
                    int answerNumber;
                    if (!Int32.TryParse(answer, out answerNumber) || answerNumber > args.Length)
                    {
                        Console.WriteLine("--------Wrong argument--------");
                        continue;
                    }
                    Console.WriteLine("Your move: " + args[answerNumber - 1]);
                    Console.WriteLine($"Computer move: {args[computerMove]}");
                    Console.WriteLine(GameRules.StartGame(args, answerNumber - 1, computerMove));
                    Console.Write("Key: ");
                    Print256(HMACKey);
                    Console.WriteLine("\n");
                }
            }                       
        }

        public static void Print256(byte[] shaaLg)
        {
            foreach (var d in shaaLg)
            {
                Console.Write($"{d:X2}");
            }
        }
        
    }

   
}
