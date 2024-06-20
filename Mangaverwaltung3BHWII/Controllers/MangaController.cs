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
    
    public IActionResult Edit(int MangaId)
    {
        // Repo holen
        MangaRepository repo = new MangaRepository();
        // manga mit MangaId aus DB holen
        Manga meinManga = repo.GetManga(MangaId);
        
        // manga der view übergeben
        return View(meinManga);
    }
    
    public IActionResult Delete(int MangaId)
    {
        // Repo holen
        MangaRepository repo = new MangaRepository();
        // manga mit MangaId aus DB holen
        Manga meinManga = repo.GetManga(MangaId);
        
        // manga der view übergeben
        return View(meinManga);
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
    
    [HttpPost]
    public IActionResult UpdateManga(Manga manga)
    {
        // Repository holen
        MangaRepository repo = new MangaRepository();
        
        // manga speichern
        repo.UpdateManga(manga);
        
        // Zurück zur Übersicht
        return Redirect("/Manga");
    }
    
    [HttpPost]
    public IActionResult DeleteManga(Manga manga)
    {
        // Repository holen
        MangaRepository repo = new MangaRepository();
        
        // manga speichern
        repo.DeleteManga(manga.MangaId);
        
        // Zurück zur Übersicht
        return Redirect("/Manga");
    }
    
}