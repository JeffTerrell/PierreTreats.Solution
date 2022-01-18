using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using PierreTreats.Models;

namespace PierreTreats.Controllers
{
  [Authorize]
  public class TreatsController : Controller
  {
    private readonly PierreTreatsContext _db;

    public TreatsController(PierreTreatsContext db)
    {
      _db = db;
    }

    [AllowAnonymous]
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

    [AllowAnonymous]
    public ActionResult Details(int Id)
    {
      ViewBag.FlavorId =  new SelectList(_db.Flavors, "FlavorId", "Name");
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

    [HttpPost]
    public ActionResult AddFlavor(Treat treat, int FlavorId)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(find => find.FlavorId == FlavorId);
      if (FlavorId != 0 && thisFlavor.JoinTreat.Where(find => find.FlavorId == FlavorId).Count() < 1)
      {
      _db.FlavorTreats.Add(new FlavorTreat() { FlavorId = FlavorId , TreatId = treat.TreatId});
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = treat.TreatId });
    }

    [HttpPost]
    public ActionResult DeleteFlavor(Treat treat, int joinId)
    {
      FlavorTreat joinEntry = _db.FlavorTreats.FirstOrDefault(find => find.FlavorTreatId == joinId);
      _db.FlavorTreats.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = treat.TreatId });
    }
  }
}