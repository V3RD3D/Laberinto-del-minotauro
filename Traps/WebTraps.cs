using LabyrinthGame.Heroes;
namespace LabyrinthGame.Traps;
 public class WebTrap : Trap
    {
        public WebTrap()
        {
            Name = "Web Trap";
            Symbol = "🕸";
        }

        public override void ApplyEffect(Hero hero)
        {
            Console.WriteLine($"{hero.Name} caught in web! Loses 2 turns!");
            hero.CurrentCooldown += 2;
        }
    }