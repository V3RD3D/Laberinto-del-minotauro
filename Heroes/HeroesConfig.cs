    // Configuración de héroes disponibles
    namespace LabyrinthGame.Heroes;
    public static class HeroesConfig
    {
        public static List<Hero> GetAvailableHeroes()
        {
            var heroes = new List<Hero>();

            var ariadne = new Hero("Ariadne", 90, 3, "Golden Thread", 4, "👸🏼");
            ariadne.SpecialAbility = () => 
            {
                Console.WriteLine("Golden thread reveals path to exit for 3 turns!");
            };
            heroes.Add(ariadne);

            var perseus = new Hero("Perseus", 100, 4, "Medusa's Head", 5, "👨🏼");
            perseus.SpecialAbility = () =>
            {
                Console.WriteLine("Petrifies enemies in 2-tile radius for 2 turns!");
            };
            heroes.Add(perseus);

            var theseus = new Hero("Theseus", 120, 4, "Hero's Fury", 3, "🤴🏻");
            theseus.SpecialAbility = () =>
            {
                Console.WriteLine("Breaks through walls and stuns enemies for 1 turn!");
            };
            heroes.Add(theseus);

            var hercules = new Hero("Hercules", 150, 2, "Titanic Strength", 6, "💪🏻");
            hercules.SpecialAbility = () =>
            {
                Console.WriteLine("Destroys adjacent walls and stuns nearby enemies!");
            };
            heroes.Add(hercules);

            var icarus = new Hero("Icarus", 80, 5, "Wax Wings", 4, "👼🏻");
            int wingUses = 0;
            icarus.SpecialAbility = () =>
            {
                wingUses++;
                Console.WriteLine("Flies over obstacles for 2 turns! Speed increased to 8!");
                icarus.Speed = 8;
                if (wingUses > 2)
                {
                    Console.WriteLine("Wings melt! Icarus loses 30 health!");
                    icarus.Health -= 30;
                }
            };
            heroes.Add(icarus);

            return heroes;
        }
    }