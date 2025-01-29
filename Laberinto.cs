using System;
namespace ELlabe;
public class Laberinto
{
    private int[,] laberinto;
    private int tamano;
    private Random random;
    public Laberinto(int tamano)
    {
        this.tamano = tamano;
        laberinto = new int[tamano, tamano];
        random = new Random();
        GenerarLaberinto();
    }
    private void GenerarLaberinto()
    {
        for (int i = 0; i < tamano; i++)
        {
            for (int j = 0; j < tamano; j++)
            {
                laberinto[i, j] = 1;
            }
        }
        //comenzar a generar el laberinto desde un valor random 
        int empezarx = random.Next(1, tamano - 1);
        int empezary = random.Next(1, tamano - 1);
        laberinto[empezarx, empezary] = 0;
        RecursionBactracking(empezarx, empezary);
        int centro = tamano / 2;
        laberinto[centro, centro] = 2;

    }
    private void RecursionBactracking(int x, int y)
    {
        int[] dx = { 0, 0, -1, 1};
        int[] dy = {-1, 1, 0, 0 };
        List<int> direcciones = new List<int> {0,1,2,3};
        Mezclar(direcciones) ; 
        foreach (var dir in direcciones)
        {
            int nx = x + dx [dir] * 2;
            int ny = y + dy [dir] * 2;
            if (nx > 0 && nx < tamano - 1 && ny > 0 && ny < tamano - 1 && laberinto[nx, ny] == 1)
            {
                laberinto [nx , ny] = 0;
                laberinto [x + dx[dir], y  + dy[dir]] = 0;
                RecursionBactracking(nx , ny); 
            }
        }
    }
    private void Mezclar(List<int> list )
    {
        int n = list.Count;
        while(n > 1)
        {
            n --;
            int k = random.Next(n + 1);
            int value = list[k];
            list[k] =list[n];
            list [n] = value;
        }
    }
    public void Printeo()
    {
        for (int i = 0; i < tamano; i++)
        {
            for (int j = 0; j < tamano; j++)
            {
                if (laberinto [i, j] == 0)
                {
                    Console.Write("⬛");

                }
                else if(laberinto[i , j] == 1)
                {
                    System.Console.Write("⬜");
                }
                else if (laberinto[i , j] == 2)
                {
                    System.Console.Write("🎯");
                }
            }
            System.Console.WriteLine();
        }
    }
}
