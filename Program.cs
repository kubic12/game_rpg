using RPG.Utils;
using System;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            bool isRightValues = true;
            int count = 0;
            while (isRightValues) {
                Console.WriteLine("Count players:");
                count = int.Parse(Console.ReadLine());
                if (count % 2 == 0)
                {
                    isRightValues = false;
                }
            }
            GameController.GeneratePlayers(count);
            GameController.StartRound();
            GameController.GetWinner();
        }
    }
}
