namespace LabyrinthGame.Traps
{
    public abstract class Trap
    {
        public string Name { get; protected set; }
        public string Symbol { get; protected set; }
        public abstract void ApplyEffect(Heroes.Hero hero);
    }
}