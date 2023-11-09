using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Word_Game.Models;

namespace Word_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begining");

            int levelCount = 0;
            var levels = Levels.GetLevels();
            foreach (var level in levels) {
                levelCount++;
                Console.WriteLine($"---------------  Level - {levelCount} ---------------");
                GameClass gameClassOne = new GameClass(level);
                StartTheGame(gameClassOne);
            }
        }

        private static void StartTheGame(GameClass gm)
        {
            do
            {
                Console.WriteLine(gm.Line);

                Console.Write($"{gm.Level.Question} ");
                var key = Console.ReadKey();

                Console.Write(Environment.NewLine);

                gm.CheckTheAnswer(key.KeyChar);


            } while (gm.IsSuccess);

            Console.WriteLine($"Congratulations. You found the wright answer. {gm.Level.Answer}");
            Console.Read();

        }

    }
}
