public class Cliente{
    public int DNI {get; set;}
    public string Apellido {get; set;}
    public string Nombre {get; set;}
    public DateTime FechaInscripcion {get; set;}
    public int TipoEntrada {get; set;}
    public int Cantidad {get; set;}
    public Cliente(){
        
    }

    public Cliente(int dni, string ape, string nom, DateTime fins, int tipo, int cant){
        DNI = dni;
        Apellido = ape;
        Nombre = nom;
        FechaInscripcion = fins;
        TipoEntrada = tipo;
        Cantidad = cant;
    }
}