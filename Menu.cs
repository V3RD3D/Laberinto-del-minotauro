using System;
using Heroes;

public static class MenuSeleccion
{
    public static List<Heroe> SeleccionarHeroes()
    {
        List<Heroe> HeroesDisponibles = Heroes.HeroesConfg.ObtenerHeroesDisponibles();
        List<Heroe> HeroesSeleccionados = new List<Heroe>();
        int seleccion;
        System.Console.WriteLine("===SELECCION DE HEROES");
        do
        {
            MostrarHeroesDisponible(HeroesDisponibles);
            System.Console.WriteLine("\nSelecciona un heroe (1-5) o (0)para terminar seleccion");
            seleccion = LeerEntradaNumerica(0,5);
            if (seleccion > 0 && seleccion <= HeroesDisponibles.Count)
            {
               Heroe heroeSeleccionado = HeroesDisponibles[seleccion - 1];
               HeroesSeleccionados.Add(heroeSeleccionado);
               System.Console.WriteLine($"\n{heroeSeleccionado.Nombre} Se ha unido al grupo");
            }


        }while (seleccion != 0 && HeroesSeleccionados.Count < 5);
        return HeroesSeleccionados;

    }
    private static void MostrarHeroesDisponible(List<Heroe> heroes)
    {
        System.Console.WriteLine("===============Heroes Disponibles============");
        for (int i = 0; i < heroes.Count; i++)
        {
            System.Console.WriteLine($"{i + 1}. {heroes[i].Nombre}\nSalud : {heroes[i].Salud} \nVelocidad : {heroes[i].Velocidad} \nHabilidad : {heroes[i].HabilidadEspecial} Tiempo de enfriamiento{heroes[i].TiempoEnfriamiento}");
            heroes[i].HabilidadEspecial?.Invoke();
            System.Console.WriteLine();
        }

    }
    private static int LeerEntradaNumerica(int min , int max)
    {
        int entrada;
        while(true)
        {
            if(int .TryParse(Console.ReadLine(),out entrada) && entrada >= min && entrada <= max)
            {
                return entrada;
            }
            System.Console.WriteLine("Entrada ivalida introduzca un valor correcto");
        }
    }
}