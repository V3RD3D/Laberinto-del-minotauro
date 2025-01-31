using System;
using System.Collections.Generic;
using LabyrinthGame.Heroes;
namespace LabyrinthGame;

public class Trampa
{
    public string Nombre { get; set; }
    public string Efecto { get; set; }
    public char Simbolo { get; set; }
    public Action<Hero> AplicarEfecto { get; set; }
    public (int X, int Y) Posicion { get; set; }
}

public class Jefe
{
    public string Nombre { get; set; }
    public int Salud { get; set; }
    public char Simbolo { get; set; }
    public (int X, int Y) Posicion { get; set; }
    public string Lore { get; set; }
    public Action<Hero> Encuentro { get; set; }
}