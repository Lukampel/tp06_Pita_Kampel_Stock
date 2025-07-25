using Microsoft.Data.SqlClient;
using Dapper;

namespace TP06.Models;

public static class BaseDeDatos
{
   private static string _connectionString = 
    @"Server=localhost;DataBase=Usuarios;Integrated Security=True;TrustServerCertificate=True;";



public static Integrante LevantarIntegrante(string nombreUsuario)
{


    Integrante miIntegrante = null;
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
string query = @"SELECT 
                    NombreUsuario, 
                    Contrasena, 
                    FechaNacimiento, 
                    Hobby, 
                    Deporte, 
                    ColorFav, 
                    PeliculaFav 
                FROM Integrantes 
                WHERE NombreUsuario = @NombreUsuario";


       miIntegrante = connection.QueryFirstOrDefault<Integrante>(
    query, new { NombreUsuario = nombreUsuario });

    }
    return miIntegrante;
}





    public static void AgregarIntegrante(Integrante I) 
    {
        string query = "INSERT INTO Integrantes (NombreUsuario, Contrasena, FechaNacimiento, Hobby, Deporte, ColorFav, PeliculaFav) VALUES(@pNombreUsuario, @pContrasena, @pFechaNacimiento, @pHobby, @pDeporte, @pColorFav, @pPeliculaFav)";
        using(SqlConnection connection = new SqlConnection(_connectionString)) 
        {
            connection.Execute(query, new {pNombreUsuario = I.NombreUsuario, pContrasena =I.Contrasena, pFechaNacimiento = I.FechaNacimiento, pHobby = I.Hobby, pDeporte = I.Deporte, pColorFav = I.ColorFav, pPeliculaFav = I.PeliculaFav});
        }
    }
}
