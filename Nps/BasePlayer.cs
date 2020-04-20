namespace RPG.Nps
{
    public abstract class BasePlayer
    {
        public string Name { get; set; }
        public int Force { get; set; }
        public float Health { get; set; }

        public BasePlayer(string name, int force, float health)
        {
            Name = name;
            Force = force;
            Health = health;
        }

        public abstract void Attack(BasePlayer player);

        public abstract void UltaAttack(BasePlayer player);

        public abstract bool CheckHealth();
    }
}