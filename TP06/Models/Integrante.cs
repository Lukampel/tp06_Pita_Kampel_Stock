public class Integrante
{
    public string NombreUsuario { get; set; }
    public string Contraseña { get; private set; }
     public string Foto { get; private set; }
    public DateTime FechaNacimiento { get; set; }
    public string Hobby { get; set; }
    public string Deporte { get; set; }
    public string ColorFav { get; set; }
    public string PeliculaFav { get; set; }

    public bool InicioSesion(string nombreUsuarioIngresado, string ContraseñaIngresada)
    {
        return (NombreUsuario == nombreUsuarioIngresado && Contraseña == ContraseñaIngresada);
    }
}