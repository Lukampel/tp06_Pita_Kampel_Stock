using Microsoft.Data.SqlClient;
using Dapper;

namespace try_catch_poc.Models;

public static class BD
{
    private static string _connectionString = @"Server=localhost;DataBase=NombreBase;Integarted Security=True;TrustServerCertificate=True;";
    /*public List<Integrante> LevantarIntegrantes()
    {
        List<Integrante> integrantes = new List<Integrante>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Integrantes";
            integrantes = connection.Query<Integrante>(query).ToList();
        }
        return integrantes;
    }*/
    public static Integrante LevantarIntegrante(string nombreUsuario)
    {
        Integrante miIntegrante = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT NombreUsuario FROM Integrantes WHERE NombreUsuario = @nombreUsuario";
            miIntegrante = connection.QueryFirstOrDefault<Integrante>(query, new {@nombreUsuario = nombreUsuario} );
        }
        return miIntegrante;
    }

    public static void AgregarIntegrante(Integrante I) 
    {
        string query = "INSERT INTO Integrantes (NombreUsuario, Contraseña, FechaNacimiento, Hobby, Deporte, ColorFav, PeliculaFav) VALUES(@pNombreUsuario, @pContraseña, @pFechaNacimiento, @pHobby, @pDeporte, @pColorFav, @pPeliculaFav)";
        using(SqlConnection connection = new SqlConnection(_connectionString)) {
            connection.Execute(query, new {pNombreUsuario = I.NombreUsuario, pContraseña =I.Contraseña, pFechaNacimiento = I.FechaNacimiento, pHobby = I.Hobby, pDeporte = I.Deporte, pColorFav = I.ColorFav, pPeliculaFav = I.PeliculaFav});
        }
    }
}