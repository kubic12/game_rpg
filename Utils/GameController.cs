using RPG.Nps;
using System;
using System.Collections.Generic;

namespace RPG.Utils
{
    public class GameController
    {
        private static List<string> PlayerNames = new List<string>() {
            "Luna", "William", "David", "Lina", "Kunka", "Blood"
        };

        private static List<BasePlayer> PlayerLists = new List<BasePlayer>();

        public static void GeneratePlayers(int count)
        {
            for (var i = 0; i < count; i++)
            {
                BasePlayer player;
                var name = PlayerNames[new Random().Next(0, PlayerNames.Count)];
                var force = new Random().Next(15, 31);
                var health = new Random().Next(80, 101);
                switch (new Random().Next(0, 3))
                {
                    case 0:
                        player = new KnightPlayer(name, force, health);
                        break;
                    case 1:
                        player = new ArcherPlayer(name, force, health);
                        break;
                    case 2:
                        player = new MagePlayer(name, force, health);
                        break;
                    default:
                        player = null;
                        break;
                }
                PlayerLists.Add(player);
            }
        }

        public static void StartRound()
        {
            while (PlayerLists.Count > 1)
            {
                var firstPlayer = PlayerLists[0];
                var secondPlayer = PlayerLists[1];
                while (firstPlayer.CheckHealth() && secondPlayer.CheckHealth())
                {
                    DoAttack(firstPlayer, secondPlayer);
                    DoAttack(secondPlayer, firstPlayer);
                }
                if (!firstPlayer.CheckHealth())
                {
                    Console.WriteLine($"The player {firstPlayer.Name} was killed.");
                    PlayerLists.Remove(firstPlayer);
                } 
                else
                {
                    Console.WriteLine($"The player {secondPlayer.Name} was killed.");
                    PlayerLists.Remove(secondPlayer);
                }
            }
        }

        public static BasePlayer GetWinner()
        {
            Console.WriteLine($"The {PlayerLists[0].Name} is winner.");
            return PlayerLists[0];
        }

        public static List<BasePlayer> GetPlayers()
        {
            return PlayerLists;
        }

        private static void DoAttack(BasePlayer skill, BasePlayer secondPlayer)
        {
            if (new Random().Next(0, 10) >= 6)
            {
                skill.UltaAttack(secondPlayer);
            }
            else
            {
                skill.Attack(secondPlayer);
            }
        }
    }
}