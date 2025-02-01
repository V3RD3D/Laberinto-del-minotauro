namespace LabyrinthGame.Traps;
public class TeleportTrap : Trap
    {
        public TeleportTrap()
        {
            Name = "Teleport Trap";
            Symbol = "🛸";
        }

        public override void ApplyEffect(Heroes.Hero hero)
        {
            Console.WriteLine($"{hero.Name} gets teleported!");
            Random rnd = new Random();
            hero.Position = (rnd.Next(0, 9), rnd.Next(0, 9));
        }
    }