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
  public class FlavorsController : Controller
  {
    private readonly PierreTreatsContext _db;

    public FlavorsController(PierreTreatsContext db)
    {
      _db = db;
    }

    [AllowAnonymous]
    public ActionResult Index()
    {
      return View(_db.Flavors.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [AllowAnonymous]
    public ActionResult Details(int Id)
    {
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
      Flavor thisFlavor = _db.Flavors
      .Include(flavor => flavor.JoinTreat)
      .ThenInclude(join => join.Treat)
      .FirstOrDefault(flavor => flavor.FlavorId == Id);
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = flavor.FlavorId });
    }

    [HttpPost]
    public ActionResult Delete(Flavor flavor)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(find => find.FlavorId == flavor.FlavorId);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int TreatId)
    {
      Treat thisTreat = _db.Treats
      .Include(treat => treat.JoinFlavor)
      .ThenInclude(join => join.Flavor)
      .FirstOrDefault(treat => treat.TreatId == TreatId);
      if (TreatId != 0 && thisTreat.JoinFlavor.Where(find => find.TreatId == TreatId).Count() < 1)
      {
      _db.FlavorTreats.Add(new FlavorTreat() { TreatId = TreatId , FlavorId = flavor.FlavorId});
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = flavor.FlavorId });
    }

    [HttpPost]
    public ActionResult DeleteTreat(Flavor flavor, int joinId)
    {
      FlavorTreat joinEntry = _db.FlavorTreats.FirstOrDefault(find => find.FlavorTreatId == joinId);
      _db.FlavorTreats.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = flavor.FlavorId });
    }
  }
}