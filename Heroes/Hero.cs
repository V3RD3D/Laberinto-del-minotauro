
// Hero.cs
using System;
using System.Collections.Generic;

namespace LabyrinthGame.Heroes
{
    // Clase base para los héroes
    public class Hero
    {
        private int health;
        private int speed;
        private int currentCooldown;
        private List<Item> backpack = new List<Item>();
        
        public string Name { get; set; }
        public string AbilityName { get; set; }
        public string Emoji { get; set; }
        public int Cooldown { get; set; }
        public (int X, int Y) Position { get; set; }
        public const int BackpackCapacity = 3;

        public int Health
        {
            get => health;
            set => health = Math.Max(value, 0);
        }

        public int Speed
        {
            get => speed;
            set => speed = Math.Max(value, 0);
        }

        public int CurrentCooldown
        {
            get => currentCooldown;
            set => currentCooldown = Math.Max(value, 0);
        }

        public Action SpecialAbility { get; set; }

        public Hero(string name, int health, int speed, string ability, int cooldown, string emoji)
        {
            Name = name;
            Health = health;
            Speed = speed;
            AbilityName = ability;
            Cooldown = cooldown;
            Emoji = emoji;
            CurrentCooldown = 0;
        }

        // Usar la habilidad especial del héroe
        public void UseAbility()
        {
            if (CurrentCooldown > 0)
            {
                Console.WriteLine($"{Name}: Ability is on cooldown! ({Cooldown} turns remaining)");
                return;
            }
            
            Console.WriteLine($"\n=== {Name} uses {AbilityName} ===");
            SpecialAbility?.Invoke();
            Console.WriteLine("=============================\n");
            CurrentCooldown = Cooldown;
        }

        // Añadir ítem a la mochila
        public void AddItem(Item item)
        {
            if (backpack.Count >= BackpackCapacity)
            {
                Console.WriteLine($"{Name}: Backpack is full! (Max {BackpackCapacity} items)");
                return;
            }
            backpack.Add(item);
            Console.WriteLine($"{Name} obtained {item.Name}");
        }

        // Usar un ítem de la mochila
        public void UseItem(int index)
        {
            if (index < 0 || index >= backpack.Count)
            {
                Console.WriteLine("Invalid item index!");
                return;
            }
            
            Item item = backpack[index];
            Console.WriteLine($"\n=== {Name} uses {item.Name} ===");
            item.Use(this);
            Console.WriteLine("==============================\n");
            backpack.RemoveAt(index);
        }

        // Mostrar contenido de la mochila
        public void ShowBackpack()
        {
            Console.WriteLine($"\n=== {Name}'s Backpack ===");
            for (int i = 0; i < backpack.Count; i++)
            {
                Console.WriteLine($"{i}: {backpack[i].Name} - {backpack[i].Effect}");
            }
            Console.WriteLine("=========================");
        }

        // Actualizar estado cada turno
        public void UpdateStatus()
        {
            if (CurrentCooldown > 0) CurrentCooldown--;
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public string Effect { get; set; }
        public Action<Hero> Use { get; set; }
    }
}