using ELlabe;
using Heroes;
namespace Programa;
public class Programa
{
    private static void Main(string [] args)
    {
        Console.Title = "Laberinto";
        List<Heroe> equipo = MenuSeleccion.SeleccionarHeroes();
        System.Console.WriteLine("===== TU EQUIPO ====");
        foreach(Heroe heroe in equipo)
        {
            System.Console.WriteLine($"{heroe.Nombre} ");
        }
         //System.Console.WriteLine("aqui tienes tu laberinto \n Pum");
        //Laberinto laberinto = new Laberinto(51);
        //laberinto.Printeo();
    }
}
