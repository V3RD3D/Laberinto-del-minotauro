// GameManager.cs
using System;
using System.Collections.Generic;
using System.Linq;
using LabyrinthGame.Heroes;
namespace LabyrinthGame
{
    public class GameManager
    {
        private List<Hero> selectedHeroes = new List<Hero>();
        private Maze maze;
        private int currentTurn;
        
        public void StartGame()
        {
            SelectHeroes();
            maze = new Maze(10);
            GameLoop();
        }

        // Selección de héroes sin repetición
        private void SelectHeroes()
        {
            var availableHeroes = HeroesConfig.GetAvailableHeroes();
            
            while (selectedHeroes.Count < 3) // Cambiar a 5 para selección completa
            {
                Console.Clear();
                Console.WriteLine("SELECT YOUR HEROES:");
                
                for (int i = 0; i < availableHeroes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {availableHeroes[i].Name} " +
                                    $"{availableHeroes[i].Emoji}");
                }

                if (int.TryParse(Console.ReadLine(), out int choice) && 
                    choice > 0 && choice <= availableHeroes.Count)
                {
                    selectedHeroes.Add(availableHeroes[choice - 1]);
                    availableHeroes.RemoveAt(choice - 1);
                }
                else
                {
                    Console.WriteLine("Invalid selection!");
                }
            }
        }

        // Bucle principal del juego
        private void GameLoop()
        {
            while (true)
            {
                var currentHero = selectedHeroes[currentTurn % selectedHeroes.Count];
                currentHero.UpdateStatus();
                
                maze.Display(currentHero, selectedHeroes);
                HandleTurn(currentHero);

                if (maze.CheckVictory(currentHero))
                {
                    Console.WriteLine($"VICTORY! {currentHero.Name} escaped the labyrinth!");
                    break;
                }

                currentTurn++;
            }
        }

        private void HandleTurn(Hero hero)
        {
            Console.WriteLine("\n1. Move  2. Use Ability  3. Use Item");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    MoveHero(hero);
                    CheckTrap(hero);
                    break;
                case "2":
                    hero.UseAbility();
                    break;
                case "3":
                    hero.ShowBackpack();
                    if (Hero.BackpackCapacity > 0)
                    {
                        Console.WriteLine("Select item index:");
                        if (int.TryParse(Console.ReadLine(), out int index))
                            hero.UseItem(index);
                    }
                    break;
            }
        }

        private void MoveHero(Hero hero)
        {
            Console.WriteLine("Movement (WASD):");
            var key = Console.ReadKey().Key;

            var newPos = hero.Position;
            switch (key)
            {
                case ConsoleKey.W: newPos.X--; break;
                case ConsoleKey.S: newPos.X++; break;
                case ConsoleKey.A: newPos.Y--; break;
                case ConsoleKey.D: newPos.Y++; break;
                default: return;
            }

            if (maze.IsValidMove(newPos)) hero.Position = newPos;
        }

        private void CheckTrap(Hero hero)
        {
            var trap = maze.GetTrapAt(hero.Position);
            trap?.ApplyEffect(hero);
        }
    }
}