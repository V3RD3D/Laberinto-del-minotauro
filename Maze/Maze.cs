// Maze.cs
using System;
using System.Collections.Generic;
using LabyrinthGame.Heroes;
using LabyrinthGame.Traps;

namespace LabyrinthGame
{
    public class Maze
    {
        private string[,] grid;
        private List<Trap> traps;
        private (int X, int Y) exit;
        private Random random = new Random();

        public int Size { get; }

        public Maze(int size)
        {
            Size = size;
            grid = new string[size, size];
            exit = (size - 1, size - 1);
            InitializeTraps();
            Generate();
        }

        private void InitializeTraps()
        {
            traps = new List<Trap>
            {
                new SpikeTrap(),
                new WebTrap(),
                new TeleportTrap()
            };
        }

        // Generar laberinto con obstáculos y trampas
        private void Generate()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (random.Next(100) < 15) grid[i, j] = "🏛"; // Obstáculos
                    else if (random.Next(100) < 10) // Trampas
                    {
                        var trap = traps[random.Next(traps.Count)];
                        grid[i, j] = trap.Symbol;
                    }
                    else grid[i, j] = "  ";
                }
            }
            grid[exit.X, exit.Y] = "🚪"; // Salida
        }

        public bool IsValidMove((int X, int Y) position)
        {
            return position.X >= 0 && position.Y >= 0 &&
                   position.X < Size && position.Y < Size &&
                   grid[position.X, position.Y] != "🏛";
        }

        public Trap GetTrapAt((int X, int Y) position)
        {
            return traps.Find(t => t.Symbol == grid[position.X, position.Y]);
        }

        public bool CheckVictory(Hero hero)
        {
            return hero.Position == exit;
        }

        public void Display(Hero currentHero, List<Hero> heroes)
        {
            Console.Clear();
            Console.WriteLine("=== LABYRINTH ===");
            
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    var hero = heroes.Find(h => h.Position == (i, j));
                    Console.Write(hero != null ? hero.Emoji : grid[i, j].ToString());
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            
            Console.WriteLine("\nLEGEND:");
            Console.WriteLine("🏛: Wall | 🗻: Spikes | 🕸: Web | 🛸: Teleport | 🚪: Exit");
            Console.WriteLine($"Current Hero: {currentHero.Name} ({currentHero.Emoji})");
        }
    }
}
