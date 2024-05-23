namespace Mangaverwaltung3BHWII.Models;

public class Manga
{
    public int MangaId { get; set; }
    public string Titel { get; set; }
    public string Autor { get; set; }
    public DateTime Veroeffentlichungsdatum { get; set; }
    public string Beschreibung { get; set; }
    public double Bewertung { get; set; }
    public string Sprache { get; set; }
    public string Status { get; set; }
}
