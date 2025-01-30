using System.Runtime.CompilerServices;

namespace Heroes;
public class Heroe
{
    private int salud;
    private int velocidad;
    public string Nombre { get; set; }
    public int Salud
    {
        get => salud;
        set => salud = Math.Max(value, 0);
    }
    public int Velocidad
    {
        get => velocidad;
        set => velocidad = Math.Max(value, 0);

    }
    public string NombreHabilidad { get; set; }
    private string Emoji { get; set; }
    public int TiempoEnfriamiento { get; set; }
    public int EnfriamientoActual { get; set; }
    public Action HabilidadEspecial { get; set; }
    private List<Item> mochila = new List<Item>();

    public const int CapacidadMochila = 3;

    public Heroe(string nombre, int salud, int velocidad, string habilidad, int enfriamiento, string emoji)
    {
        Nombre = nombre;
        Salud = salud;
        Velocidad = velocidad;
        NombreHabilidad = habilidad;
        TiempoEnfriamiento = enfriamiento;
        EnfriamientoActual = 0;
        Emoji = emoji;
    }
    public void UsarHabilidad()
    {
        if (EnfriamientoActual > 0)
        {
            System.Console.WriteLine($"{Nombre} Habilidad Esta en enfriamiento !! durante {TiempoEnfriamiento} turnos");
            return;
        }
        System.Console.WriteLine($"\n==={Nombre} usa {NombreHabilidad} ===");
        HabilidadEspecial.Invoke();
        System.Console.WriteLine("=============================\n");
        EnfriamientoActual = TiempoEnfriamiento;
    }
    public void AgregarItem(Item item)
    {
        if (mochila.Count >= CapacidadMochila)
        {
            System.Console.WriteLine($"{Nombre}: Mochila LLena !(Maximo de la mochila 3 items) ");
        }
        mochila.Add(item);
        System.Console.WriteLine($" {Nombre} haz obtenido {item.Nombre}");
    }
    public void UsarItem(int indice)
    {
        if (indice < 0 || indice >= mochila.Count)
        {
            System.Console.WriteLine("Error: Indice de item invalido ");
        }
        Item item = mochila[indice];
        System.Console.WriteLine($"\n ==={Nombre} usa {item.Nombre}===");
        item.Usar(this);
        System.Console.WriteLine("==============================\n");
        mochila.RemoveAt(indice);
    }
    public void MostrarMochila()
    {
        System.Console.WriteLine($"\n === Mochila de {Nombre}");
        for (int i = 0; i < mochila.Count; i++)
        {
            System.Console.WriteLine($"{i} {mochila[i].Nombre} - {mochila[i].Efecto}");
            System.Console.WriteLine("=============================");
        }

    }
    public void ActualizarEstado()
    {
        if (EnfriamientoActual > 0) EnfriamientoActual--;
    }

}
public class Item
{
    public string Nombre { get; set; }
    public string Efecto { get; set; }
    public Action<Heroe> Usar { get; set; }
    
}

public static class HeroesConfg
{
    public static List<Heroe> ObtenerHeroesDisponibles()
    {
        List<Heroe> heroes = new List<Heroe> ();
        Heroe ariadna = new Heroe("Ariadna", 90, 3,"hilo de oro",4,"👸🏼");
        ariadna.HabilidadEspecial = () =>
        {
            System.Console.WriteLine("El hilo de oro guia el camino hasta la salida\nRevela el camino durante tres turnos");
        };
        heroes.Add(ariadna);

        Heroe perseo = new Heroe("Perseo", 100, 4 , "Cabeza de meduza",5, "👨🏼‍🎤");
        perseo.HabilidadEspecial = () =>
        {
            System.Console.WriteLine("La cabeza de medusa petrifica a los enemigos /nEnemigos en un radio de dos casillas quedan petrificados por dos turnos");
        };
        heroes.Add(perseo);

        Heroe teseo = new Heroe ("Teseo",120, 4,"furia del heroe",3, "🤴🏻"  );
        teseo.HabilidadEspecial = () => 
        {
            System.Console.WriteLine("Desata tal fuerza que es capaz de atravezar paredes/nActivo durante un turno/nAturde a todo los enemigos por un turno");
        };
        heroes.Add(teseo);

        Heroe hercules = new Heroe("Hercules", 150, 2 ,"Fuerza titanica" ,6, "💪🏻");
        hercules.HabilidadEspecial = () => 
        {
            System.Console.WriteLine("destruye todas las paredes adyacentes\n Aturde a los enemigos cercanos por 1 turno");
        };
        heroes.Add(hercules);

        Heroe icaro = new Heroe("Icaro", 80, 5, "Alas de Cera", 4, "👼🏼");
        int usosAlas = 0;
        icaro.HabilidadEspecial = () =>
        {
            usosAlas ++;
            System.Console.WriteLine("Icaro despega sus Alas de cera");
            System.Console.WriteLine("vuela sobre obstaculos durante 2 turnos");
            System.Console.WriteLine("Velocidad aumentada a 8");
            if(usosAlas > 2)
            {
                System.Console.WriteLine("las alas se derriten\nIcaro pierde 30 de salud");
                icaro.Salud -=30;
            }
        };
        heroes.Add(icaro);

        return heroes;


    }
}