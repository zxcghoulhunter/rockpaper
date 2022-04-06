using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace rockpaper
{
    class Help
    {
        public static void CreateTable(string[] args)
        {
            var strings = new List<string>(args);
            strings.Insert(0,"");

           
            string[] column = new string[args.Length + 1];
            PrintRow(strings.ToArray());
            for (int i = 0; i < args.Length; i++)
            {
                column[0] = args[i];
                for (int j = 1; j <= args.Length; j++)
                {
                    
                    column[j] = GameRules.StartGame(args, i, j - 1).ToUpper();
                    if (!(column[j].Length == 4))
                    {
                        column[j] = column[j].Substring(4, column[j].Length - 4);
                    }
                }
                PrintRow(column);               
            }            
        }

        static void PrintRow(params string[] columns)
        {
            int tableWidth = 100;
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }
        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

    }
}
