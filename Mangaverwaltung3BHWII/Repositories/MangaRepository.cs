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

    public Manga GetManga(int mangaId)
    {
        // Connect to DB
        NpgsqlConnection myConnection = ConnectToDB();
        // SQL Query ausführen

        using NpgsqlCommand cmd = new NpgsqlCommand("select * from manga where mangaid = :v1;", myConnection);
        cmd.Parameters.AddWithValue("v1", mangaId);
        using NpgsqlDataReader reader = cmd.ExecuteReader();

        Manga newManga = new Manga();
        while (reader.Read())
        {
            // Datensätze in Objekte umwandeln
            newManga.MangaId = (int)reader["MangaId"];
            newManga.Titel = (string)reader["Titel"];
            newManga.Autor = (string)reader["Autor"];
            newManga.Veroeffentlichungsdatum = (DateTime)reader["Veroeffentlichungsdatum"];
            newManga.Beschreibung = (string)reader["Beschreibung"];
            newManga.Bewertung = (double)reader["Bewertung"];
            newManga.Sprache = (string)reader["Sprache"];
            newManga.Status = (string)reader["Status"];
        }

        myConnection.Close();
        // mit return zurückgeben
        return newManga;
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
            newManga.MangaId = (int)reader["MangaId"];
            newManga.Titel = (string)reader["Titel"];
            newManga.Autor = (string)reader["Autor"];
            newManga.Veroeffentlichungsdatum = (DateTime)reader["Veroeffentlichungsdatum"];
            newManga.Beschreibung = (string)reader["Beschreibung"];
            newManga.Bewertung = (double)reader["Bewertung"];
            newManga.Sprache = (string)reader["Sprache"];
            newManga.Status = (string)reader["Status"];

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
        
        myConnection.Close();
    }

    public void DeleteManga(int mangaId)
    {
        NpgsqlConnection myConnection = ConnectToDB();

        using NpgsqlCommand cmd = new NpgsqlCommand(
            "Delete FROM manga where MangaId = :v1;", myConnection);

        cmd.Parameters.AddWithValue("v1", mangaId);

        int rowsAffected = cmd.ExecuteNonQuery();
        
        myConnection.Close();
    }

    public void UpdateManga(Manga manga)
    {
        NpgsqlConnection myConnection = ConnectToDB();
        


        using NpgsqlCommand cmd = new NpgsqlCommand(
            "UPDATE manga SET titel=:v1,autor=:v2,veroeffentlichungsdatum=:v3,beschreibung=:v4,bewertung=:v5,sprache=:v6,status=:v7 " + 
            "WHERE mangaid=:v8", myConnection);

        cmd.Parameters.AddWithValue("v1", manga.Titel);
        cmd.Parameters.AddWithValue("v2", manga.Autor);
        cmd.Parameters.AddWithValue("v3", manga.Veroeffentlichungsdatum);
        cmd.Parameters.AddWithValue("v4", manga.Beschreibung);
        cmd.Parameters.AddWithValue("v5", manga.Bewertung);
        cmd.Parameters.AddWithValue("v6", manga.Sprache);
        cmd.Parameters.AddWithValue("v7", manga.Status);
        cmd.Parameters.AddWithValue("v8", manga.MangaId);


        int rowsAffected = cmd.ExecuteNonQuery();
        
        myConnection.Close();
    }
}