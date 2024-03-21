using Hamburger_MVC.DAL;
using Hamburger_MVC.Models.VMs;
using Hamburger_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hamburger_MVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Policy = "AdminOnly")]
    public class BurgerIcMalzemeController : Controller
    {
        private readonly ContextDB _contextDB;

        public BurgerIcMalzemeController(ContextDB context)
        {
            _contextDB = context;
        }

        // Burger_IcMalzeme'yi listelemek için bir action
        public IActionResult Index()
        {
            var model = new Burger_IcMalzeme_VM();
            model.IcMalzemeler = _contextDB.IcMalzemeler.Include(x => x.IcMalzemeninBurgerleri)
                .ThenInclude(x => x.Burger).ToList();
            model.Burgerler = _contextDB.Burgerler.Include(x => x.BurgerinIcMalzemeleri)
                .ThenInclude(x => x.IcMalzeme).ToList();

            return View(model);
        }

        public IActionResult BurgerEditor(int id)
        {
            var burger = _contextDB.Burgerler.Find(id);
            ViewBag.IcMalzemeler = _contextDB.IcMalzemeler
                                    .Include(x => x.IcMalzemeninBurgerleri);
            return View(burger);
        }
        [HttpPost]
        public IActionResult BurgerEditor(int id, int[] icMalzemeId)
        {
            Burger burger = _contextDB.Burgerler.Include(x => x.BurgerinIcMalzemeleri)
                                .First(x => x.ID == id);
            if (burger != null)
            {
                burger.BurgerinIcMalzemeleri = icMalzemeId.Select(x => new Burger_IcMalzeme()
                {
                    BurgerID = id,
                    IcMalzemeID = x
                }).ToList();
                _contextDB.SaveChanges();
            }
            return RedirectToAction("Listele","Burger");
        }


        // Burger_IcMalzeme eklemek için bir form göstermek için action
        //public IActionResult Create()
        //{
        //    ViewBag.Burgerler = _contextDB.Burgerler.ToList();
        //    ViewBag.IcMalzemeler = _contextDB.IcMalzemeler.ToList();
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Burger_IcMalzeme burgerIcMalzeme)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _contextDB.Add(burgerIcMalzeme);
        //        await _contextDB.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(burgerIcMalzeme);
        //}

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _contextDB.IcMalzemeler == null)
            {
                return NotFound();
            }
            var burger_IcMalzeme = await _contextDB.IcMalzemeler.FindAsync(id);
            if (burger_IcMalzeme != null)
            {
                _contextDB.IcMalzemeler.Remove(burger_IcMalzeme);
            }
            await _contextDB.SaveChangesAsync();
            return RedirectToAction("Listele", "Burger");
        }
    }
}
