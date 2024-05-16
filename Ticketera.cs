public static class Ticketera{
    private static Dictionary<int, Cliente> dicClientes {get; set;}
    private static int UltimoIDEntrada {get; set;}

    public static int DevolverUltimoID(){
        return dicClientes.Count;
    }
    public static int AgregarCliente(Cliente cliente){
        bool puede = false;
        while (puede == false)
        {
            Console.Write("Ingrese DNI: ");
            string strDNI = Console.ReadLine();
            puede = int.TryParse(strDNI, out int dni);
            if (puede == true){
                cliente.DNI = dni;
            }
        }
        Console.Write("Ingrese apellido: ");
        cliente.Apellido = Console.ReadLine();
        Console.Write("Ingrese nombre: ");
        cliente.Nombre = Console.ReadLine();
        bool puede2 = false;
        while (puede2 == false)
        {
            Console.Write("Ingrese fecha de inscripcion: ");
            string strFINS = Console.ReadLine();
            puede2 = DateTime.TryParse(strFINS, out DateTime fins);
            if (puede2 == true){
                cliente.FechaInscripcion = fins;
            }
        }
        bool puede3 = false;
        while (puede3 == false)
        {
            Console.WriteLine("Opción 1 -> Día 1 , valor a abonar $45000");
            Console.WriteLine("Opción 2 -> Día 2, valor a abonar $60000");
            Console.WriteLine("Opción 3 -> Día 3, valor a abonar $30000");
            Console.WriteLine("Opción 4 -> Full Pass, valor a abonar $100000");
            Console.Write("Ingrese tipo de entrada: ");
            string strTipoEntrada = Console.ReadLine();
            puede3 = int.TryParse(strTipoEntrada, out int tipo);
            if (puede3 == true){
                if (tipo <= 4 && tipo >= 1){
                    cliente.TipoEntrada = tipo;
                }
                else{
                    puede3 = false;
                }
            }
        }
        bool puede4 = false;
        while (puede4 == false)
        {
            Console.Write("Ingrese Cantidad: ");
            string strCant = Console.ReadLine();
            puede4 = int.TryParse(strCant, out int Cant);
            if (puede4 == true){
                if (Cant > 0){
                    cliente.Cantidad = Cant;
                }
                else{
                    puede4 = false;
                }
            }
        }
        UltimoIDEntrada = DevolverUltimoID() + 1;
        dicClientes.Add(UltimoIDEntrada, cliente);

        return UltimoIDEntrada;
    }
    public static void BuscarCliente(int id){
        if (dicClientes.ContainsKey(id) == true){
            Console.WriteLine("DNI: " + dicClientes[id].DNI);
            Console.WriteLine("Apellido: " + dicClientes[id].Apellido);
            Console.WriteLine("Nombre: " + dicClientes[id].Nombre);
            Console.WriteLine("Fecha de inscripcion: " + dicClientes[id].FechaInscripcion);
            Console.WriteLine("Tipo de entrada: " + dicClientes[id].TipoEntrada);
            Console.WriteLine("Cantidad: " + dicClientes[id].Cantidad);
        }
        else{
            Console.WriteLine("No existe");
        }
    }
    public static int CambiarEntrada(int id, int tipo, int cantidad){
        int totalNuevo = 0;
        int totalViejo = 0;
        if (dicClientes.ContainsKey(id) == true){

            totalNuevo = Tipo(tipo, cantidad);
            totalViejo = Tipo(tipo, cantidad);
            if (totalNuevo == 0 || totalNuevo <= totalViejo){
                Console.WriteLine("Error");
            }
            if (totalNuevo > totalViejo){
                dicClientes[id].Cantidad = cantidad;
                dicClientes[id].TipoEntrada = tipo;
            }
        }
        else{
            Console.WriteLine("No existe");
        }
        return totalNuevo;

    }

    public static int Tipo(int tipo, int cantidad){
        int total = 0;
        switch (tipo)
        {
            case 1:
                total = cantidad * 45000;
                break;
            case 2:
                total = cantidad * 60000;
                break;
            case 3:
                total = cantidad * 30000;
                break;
            case 4:
                total = cantidad * 100000;
                break;
            default:
                Console.WriteLine("Error, no exite ese tipo de entrada");
                break;
        }
            return total;
    }

    public static List<string> Estadisticas(){
        List<string> estadisticas = new List<string>(); 
        estadisticas.Add("Cantidad de Clientes inscriptos: " + UltimoIDEntrada.ToString());
        int opcion1Clientes = 0;
        int opcion2Clientes = 0;
        int opcion3Clientes = 0;
        int opcion4Clientes = 0;
        int recaudcion1 = 0;
        int recaudcion2 = 0;
        int recaudcion3 = 0;
        int recaudcion4 = 0;
        int recaudacionTotal = 0;
        
        if(dicClientes.Count == 0){
            Console.WriteLine("Aún no se anotó nadie");
        }
        else{
            foreach (int clave in dicClientes.Keys)
        {
            if(dicClientes[clave].TipoEntrada == 1){
                opcion1Clientes++;
                recaudcion1 += Tipo(dicClientes[clave].TipoEntrada, dicClientes[clave].Cantidad);
            }
            else if(dicClientes[clave].TipoEntrada == 2){
                opcion2Clientes++;
                recaudcion2 += Tipo(dicClientes[clave].TipoEntrada, dicClientes[clave].Cantidad);
            }
            else if(dicClientes[clave].TipoEntrada == 3){
                opcion3Clientes++;
                recaudcion3 += Tipo(dicClientes[clave].TipoEntrada, dicClientes[clave].Cantidad);
            }
            else if(dicClientes[clave].TipoEntrada == 4){
                opcion4Clientes++;
                recaudcion4 += Tipo(dicClientes[clave].TipoEntrada, dicClientes[clave].Cantidad);
            }
            recaudacionTotal += Tipo(dicClientes[clave].TipoEntrada, dicClientes[clave].Cantidad);
        }
        estadisticas.Add("Cantidad de Clientes en la opcion 1: " + opcion1Clientes);
        estadisticas.Add("Cantidad de Clientes en la opcion 2: " + opcion2Clientes);
        estadisticas.Add("Cantidad de Clientes en la opcion 3: " + opcion3Clientes);
        estadisticas.Add("Cantidad de Clientes en la opcion 4: " + opcion4Clientes);
        estadisticas.Add("Porcentaje de cantidad de entradas vendidas en la opcion 1: " + opcion1Clientes/dicClientes.Count * 100);
        estadisticas.Add("Porcentaje de cantidad de entradas vendidas en la opcion 2: " + opcion2Clientes/dicClientes.Count * 100);
        estadisticas.Add("Porcentaje de cantidad de entradas vendidas en la opcion 3: " + opcion3Clientes/dicClientes.Count * 100);
        estadisticas.Add("Porcentaje de cantidad de entradas vendidas en la opcion 4: " + opcion4Clientes/dicClientes.Count * 100);
        estadisticas.Add("Recaudacion en la opcion 1: " + recaudcion1);
        estadisticas.Add("Recaudacion en la opcion 2: " + recaudcion2);
        estadisticas.Add("Recaudacion en la opcion 3: " + recaudcion3);
        estadisticas.Add("Recaudacion en la opcion 4: " + recaudcion4);
        estadisticas.Add("Recaudacion total: " + recaudacionTotal);
        }
        

        return estadisticas;
    }
}