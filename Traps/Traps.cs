namespace LabyrinthGame.Traps
{
    public abstract class Trap
    {
        public string Name { get; protected set; }
        public char Symbol { get; protected set; }
        public abstract void ApplyEffect(Heroes.Hero hero);
    }
}