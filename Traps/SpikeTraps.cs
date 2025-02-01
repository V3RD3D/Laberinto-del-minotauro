using LabyrinthGame.Heroes;
namespace LabyrinthGame.Traps;

 public class SpikeTrap : Trap
    {
        public SpikeTrap()
        {
            Name = "Spike Trap";
            Symbol = "🗻";
        }

        public override void ApplyEffect(Heroes.Hero hero)
        {
            Console.WriteLine($"{hero.Name} steps on spikes! Loses 15 health!");
            hero.Health -= 15;
        }
    }