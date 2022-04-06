using NBitcoin;
using System;
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
                throw new ArgumentException("Arguments must be more than 3");
            }
            if (args.Length % 2 == 0)
            {
                throw new ArgumentException("The number of arguments must be odd");
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
                foreach (var d in HMAC)
                {
                    Console.Write($"{d:X2}");
                }
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
                    if (!Int32.TryParse(answer, out answerNumber))
                    {
                        Console.WriteLine("Wrong symbol");
                        continue;
                    }                 
                    Console.WriteLine("Your move: " + args[answerNumber - 1]);
                    Console.WriteLine($"Computer move: {args[computerMove]}");
                    Console.WriteLine(GameRules.StartGame(args, answerNumber - 1, computerMove));
                    foreach (var d in HMACKey)
                    {
                        Console.Write($"{d:X2}");
                    }
                    Console.WriteLine("\n");
                }
            }
            
        }
        
    }

   
}
