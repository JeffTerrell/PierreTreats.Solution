using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using PierreTreats.Models;

namespace PierreTreats.Controllers
{
  public class TreatsController : Controller
  {
    private readonly PierreTreatsContext _db;

    public TreatsController(PierreTreatsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Treats.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Treat treat)
    {
      _db.Treats.Add(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int Id)
    {
      Treat thisTreat = _db.Treats
      .Include(treat => treat.JoinFlavor)
      .ThenInclude(join => join.Flavor)
      .FirstOrDefault(treat => treat.TreatId == Id);
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit (Treat treat)
    {
      _db.Entry(treat).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = treat.TreatId });
    }

    [HttpPost]
    public ActionResult Delete (Treat treat)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(find => find.TreatId == treat.TreatId);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}