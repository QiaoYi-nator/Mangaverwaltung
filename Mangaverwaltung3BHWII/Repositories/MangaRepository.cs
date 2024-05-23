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
            newManga.Titel = (string) reader["MangaId"];
            newManga.Autor = (string) reader["MangaId"];
            newManga.Veroeffentlichungsdatum = (DateTime) reader["MangaId"];
            newManga.Beschreibung = (string) reader["MangaId"];
            newManga.Bewertung = (double) reader["MangaId"];
            newManga.Sprache = (string) reader["MangaId"];
            newManga.Status = (string) reader["MangaId"];
            
            mangas.Add(newManga);
        }
        
        myConnection.Close();
        // mit return zurückgeben
        return mangas;
    }

    public void CreateManga(Manga manga)
    {
        
    }

    public void DeleteBurger(int mangaId)
    {
        
    }

    public void UpdateManga(Manga manga)
    {
        
    }
}