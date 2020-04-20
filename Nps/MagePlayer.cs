using System;

namespace RPG.Nps
{
    public class MagePlayer : BasePlayer
    {
        private bool IsActivateAttack;
        private Random Rnd;

        public MagePlayer(string name, int force, float health) : base(name, force, health)
        {
            Rnd = new Random();
        }

        public override void Attack(BasePlayer player)
        {
            int damage = Rnd.Next(5, Force + 1);
            if (IsActivateAttack)
            {
                IsActivateAttack = false;
                Console.WriteLine($"The player {player.Name} skip this step.");
                return;
            }
            player.Health -= damage;
            Console.WriteLine($"Mage {Name} attack with aditional damage {damage}.");
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