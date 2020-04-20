using System;

namespace RPG.Nps
{
    public class ArcherPlayer : BasePlayer
    {
        private bool IsActivateAttack;
        private Random Rnd;

        public ArcherPlayer(string name, int force, float health) : base(name, force, health)
        {
            Rnd = new Random();
        }

        public override void Attack(BasePlayer player)
        {
            int damage = Rnd.Next(5, Force + 1);
            if (IsActivateAttack)
            {
                player.Health -= damage + 2;
                Console.WriteLine($"Archer {Name} attack with aditional damage {damage}.");
                return;
            }
            player.Health -= damage;
            Console.WriteLine($"Archer {Name} attack with damage {damage}.");
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