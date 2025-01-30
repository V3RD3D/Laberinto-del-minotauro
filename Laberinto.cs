using System;
using Heroes;
namespace ELlabe;
public class trampa
{
    public string Nombre { get; set; }
    public string Efecto { get; set; }
    public string Simbolo { get; set; }
    public Action<Heroe> AplicarEfecto { get; set; }
    public (int X, int Y) Posicion { get; set; }
}
public class jefe
{
    public string Nombre { get; set; }
    public int Salud {get ; set ;}
    public string Efecto { get; set; }
    public string Simbolo { get; set; }
    public (int X, int Y) Posicion { get; set; }
    public string Lore { get; set; }
    public Action<Heroe> Encuentro { get; set; }
}

public class Laberinto
{
    private int[,] laberinto;
    private int tamaño;
    private Random random;
    public List<trampa> Trampas { get; set; }
    public List<jefe> Jefes { get; private set; }
    public Laberinto(int tamaño)
    {
        this.tamaño = tamaño;
        laberinto = new int[tamaño, tamaño];
        random = new Random();
        Trampas = new List<trampa>();
        Jefes = new List<jefe>();
        GenerarLaberinto();
    }
    private void ColocarTrampasYJefes()
    {
        new trampa
        {
            Nombre = "Garras de la Bestia",
            Efecto = "Desgarra Sandalias de los heroes (-2 velocidad)",
            Simbolo = "🗻",
            AplicarEfecto = f => f.Velocidad = Math.Max(f.Velocidad - 2, 1)
        };
        new trampa
        {
            Nombre = "Aliento de Hadez",
            Efecto = "Niebla venenoza (- 15 salud)",
            Simbolo = "😶‍🌫️",
            AplicarEfecto = f => f.Salud -= 15
        };
        new trampa
        {
            Nombre = "Espejo de Egeo",
            Efecto = "Confucion Divina (Intercambia Posicion con otros heroes)",
            Simbolo = "🪞",
            AplicarEfecto = f => System.Console.WriteLine("Teletransportacion Caotica!!!!")
        };


    
    var jefesConfig = new List<jefe>
    {

        new jefe
        {
            Nombre = "Cerbero",
            Salud = 200,
            Simbolo  = "🐕",
            Lore = "EL guardian de tres Cabezas de las puertas del inframundo",
            Encuentro = f => f.Velocidad = 1,
        },
        new jefe
        {
            Nombre = "Medusa",
            Salud = 150 ,
            Simbolo = "🧟‍♀️",
            Lore  = "Mirada  que convierte en Piedra a los incautos",
            Encuentro = f => f.Velocidad = 1

        },

        new jefe 
        {
            Nombre = "Hidra de Lerna",
            Salud = 300,
            Simbolo = "🐉",
            Lore = "Por cada cabeza cortada aparecen dos mas",
            Encuentro = f => f.Salud -= 25
        },

        new jefe 
        {

        }
    };
}
    private void GenerarLaberinto()
    {
        for (int i = 0; i < tamaño; i++)
        {
            for (int j = 0; j < tamaño; j++)
            {
                laberinto[i, j] = 1;
            }
        }
        //comenzar a generar el laberinto desde un valor random 
        int empezarx = random.Next(1, tamaño - 1);
        int empezary = random.Next(1, tamaño - 1);
        laberinto[empezarx, empezary] = 0;
        RecursionBactracking(empezarx, empezary);
        int centro = tamaño / 2;
        laberinto[centro, centro] = 2;

    }
    private void RecursionBactracking(int x, int y)
    {
        int[] dx = { 0, 0, -1, 1 };
        int[] dy = { -1, 1, 0, 0 };
        List<int> direcciones = new List<int> { 0, 1, 2, 3 };
        Mezclar(direcciones);
        foreach (var dir in direcciones)
        {
            int nx = x + dx[dir] * 2;
            int ny = y + dy[dir] * 2;
            if (nx > 0 && nx < tamaño - 1 && ny > 0 && ny < tamaño - 1 && laberinto[nx, ny] == 1)
            {
                laberinto[nx, ny] = 0;
                laberinto[x + dx[dir], y + dy[dir]] = 0;
                RecursionBactracking(nx, ny);
            }
        }
    }
    private void Mezclar(List<int> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            int value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
    public void Printeo()
    {
        for (int i = 0; i < tamaño; i++)
        {
            for (int j = 0; j < tamaño; j++)
            {
                if (laberinto[i, j] == 0)
                {
                    Console.Write("  ");

                }
                else if (laberinto[i, j] == 1)
                {
                    System.Console.Write("🏛");
                }
                else if (laberinto[i, j] == 2)
                {
                    System.Console.Write("🎯");
                }
            }
            System.Console.WriteLine();
        }
    }
}
