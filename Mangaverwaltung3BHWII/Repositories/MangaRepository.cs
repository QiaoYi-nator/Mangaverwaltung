using Mangaverwaltung3BHWII.Models;
using Npgsql;

namespace Mangaverwaltung3BHWII.Repositories;

public class MangaRepository
{
    private NpgsqlConnection ConnectToDB()
    {
        string connectionString = "Host=localhost;Database=Mangaverwaltung;User Id=dbuser;Password=dbuser;";
        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        
        connection.Open();
        return connection;
    }
    
    public List<Manga> GetAllMangas()
    {
        // Connect to DB
        NpgsqlConnection myConnection = ConnectToDB();
        // SQL Query ausführen

        using NpgsqlCommand cmd = new NpgsqlCommand("Select * from manga;", myConnection);

        using NpgsqlDataReader reader = cmd.ExecuteReader();

        List<Manga> mangas = new List<Manga>();
        while (reader.Read())
        {
            // Datensätze in Objekte umwandeln
            Manga newManga = new Manga();
            newManga.MangaId = (int) reader["MangaId"];
            newManga.Titel = (string) reader["Titel"];
            newManga.Autor = (string) reader["Autor"];
            newManga.Veroeffentlichungsdatum = (DateTime) reader["Veroeffentlichungsdatum"];
            newManga.Beschreibung = (string) reader["Beschreibung"];
            newManga.Bewertung = (double) reader["Bewertung"];
            newManga.Sprache = (string) reader["Sprache"];
            newManga.Status = (string) reader["Status"];
            
            mangas.Add(newManga);
        }
        
        myConnection.Close();
        // mit return zurückgeben
        return mangas;
    }

    public void CreateManga(Manga manga)
    {
        NpgsqlConnection myConnection = ConnectToDB();
        
        using NpgsqlCommand cmd = new NpgsqlCommand(
            "INSERT INTO Manga (Titel, Autor, Veroeffentlichungsdatum, Beschreibung, Bewertung, Sprache, Status) " +
            "VALUES (:v1,:v2,:v3,:v4,:v5,:v6,:v7)", myConnection);
        
        cmd.Parameters.AddWithValue("v1", manga.Titel);
        cmd.Parameters.AddWithValue("v2", manga.Autor);
        cmd.Parameters.AddWithValue("v3", manga.Veroeffentlichungsdatum);
        cmd.Parameters.AddWithValue("v4", manga.Beschreibung);
        cmd.Parameters.AddWithValue("v5", manga.Bewertung);
        cmd.Parameters.AddWithValue("v6", manga.Sprache);
        cmd.Parameters.AddWithValue("v7", manga.Status);

        int rowsAffected = cmd.ExecuteNonQuery();
    }

    public void DeleteBurger(int mangaId)
    {
        
    }

    public void UpdateManga(Manga manga)
    {
        
    }
}