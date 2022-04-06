using System;

namespace rockpaper
{
    class GameRules
    {
        public static string StartGame(string[] args, int answer, int computerMove)
        {
            if (args[answer] == args[computerMove])
            {
                return"Draw";
            }
            else
            {
                int length = args.Length;
                for (int i = 0; i <= (length - 1) / 2; i++)
                {

                    if (args[answer] == args[computerMove])
                    {
                        return "You win";
                    }

                    answer++;
                    if (answer >= length)
                    {
                        answer %= length;
                    }
                }
                return "You lose";

            }

        }
    }
}
