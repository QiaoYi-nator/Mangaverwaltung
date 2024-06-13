using Mangaverwaltung3BHWII.Models;
using Mangaverwaltung3BHWII.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Mangaverwaltung3BHWII.Controllers;

public class MangaController : Controller
{
    // GET
    public IActionResult Index()
    {
        MangaRepository repo = new MangaRepository();
        List<Manga> myMangas = repo.GetAllMangas();
        
        return View(myMangas);
    }

    public IActionResult New()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SaveManga(Manga manga)
    {
        // Repository holen
        MangaRepository repo = new MangaRepository();
        
        // manga speichern
        repo.CreateManga(manga);
        
        // Zurück zur Übersicht
        return Redirect("/Manga");
    }
}