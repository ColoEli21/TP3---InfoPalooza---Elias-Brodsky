namespace TP3___InfoPalooza;

class Program
{
    static void Main(string[] args)
    {
        int menu = 0;
        do
        {
            Console.WriteLine("1 -> Nueva Inscripcion");
            Console.WriteLine("2 -> Obtener Estadísticas del Evento");
            Console.WriteLine("3 -> Buscar Cliente");
            Console.WriteLine("4 -> Cambiar entrada de un Cliente");
            Console.WriteLine("5 -> Salir");
            menu = int.Parse(Console.ReadLine());
            int id= 0;
            switch (menu)
            {
                case 1:
                    Cliente cliente = new Cliente();
                    Console.WriteLine("el id del ticket es " + Ticketera.AgregarCliente(cliente));
                    break;
                case 2:
                    List<string> lista = Ticketera.Estadisticas();
                    foreach (string palabra in lista)
                    {
                        Console.WriteLine(palabra);
                    }
                    break;
                case 3:
                    Console.Write("Ingrese id: ");
                    id = int.Parse(Console.ReadLine());
                    Ticketera.BuscarCliente(id);
                    break;
                case 4:
                    Console.Write("Ingrese id: ");
                    id = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese cantidad: ");
                    int cantidad = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese tipo: ");
                    int tipo = int.Parse(Console.ReadLine());
                    int nuevo = Ticketera.CambiarEntrada(id, tipo, cantidad);
                    if (nuevo != 0){
                        Console.WriteLine("se cambio la entrada. nuevo valor: " + nuevo);
                    }
                    break;
                case 5:
                    Console.WriteLine("Saliste");
                    break;
                default:
                    Console.WriteLine("error, volver a intentar");
                    break;
            }
        } while (menu != 5);
    }
}
