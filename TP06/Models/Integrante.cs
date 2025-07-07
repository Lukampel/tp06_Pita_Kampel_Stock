public class Integrante
{
    public string NombreUsuario { get; set; }
    public string Contrasena { get; private set; }
     public string Foto { get; private set; }
    public DateTime FechaNacimiento { get; set; }
    public string Hobby { get; set; }
    public string Deporte { get; set; }
    public string ColorFav { get; set; }
    public string PeliculaFav { get; set; }

    public bool InicioSesion(string ContrasenaIngresada)
    {
        Console.WriteLine(Contrasena);
        Console.WriteLine(ContrasenaIngresada);
        return (Contrasena == ContrasenaIngresada);

    }
}