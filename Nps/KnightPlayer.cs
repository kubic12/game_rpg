using System;

namespace RPG.Nps
{
    public class KnightPlayer : BasePlayer
    {
        private bool IsActivateAttack;
        private Random Rnd;

        public KnightPlayer(string name, int force, float health) : base(name, force, health)
        {
            Rnd = new Random();
        }

        public override void Attack(BasePlayer player)
        {
            int damage = Rnd.Next(5, Force + 1);
            if (IsActivateAttack)
            {
                Console.WriteLine($"Knight {Name} attack to with aditional damage {damage}.");
                player.Health -= damage * 0.3f + damage;
                IsActivateAttack = false;
                return;
            }
            player.Health -= damage;
            Console.WriteLine($"Knight {Name} attack with damage {damage}.");
        }

        public override void UltaAttack(BasePlayer player)
        {
            IsActivateAttack = true;
            Attack(player);
        }

        public override bool CheckHealth()
        {
            if (Health > 0)
            {
                return true;
            }
            return false;
        }
    }
}