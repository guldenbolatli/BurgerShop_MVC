using Hamburger_MVC.DAL;
using Hamburger_MVC.Models;
using Hamburger_MVC.Models.ViewModels;
using Hamburger_MVC.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hamburger_MVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Policy = "AdminOnly")]
    public class MenuController : Controller
    {
        private readonly ContextDB _contextDB;
        public MenuController(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }
        public IActionResult Listele()
        {
            var menuler = _contextDB.Menuler.Include(x=>x.Icecek).Include(x=>x.Burger).ToList();
            return View(menuler);
        }
        public IActionResult Create()
        {
            Menu menu = new Menu();
            return View(menu);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Menu _menu)
        {//if (ModelState.IsValid)
         //{
            if (_menu != null)
            {
                string strDosyaAdi = _menu.Fotograf.FileName;
                FileStream fs = new FileStream("wwwroot/Admin/urunfoto/" + strDosyaAdi, FileMode.Create);
                await _menu.Fotograf.CopyToAsync(fs);
                fs.Close();
                _menu.UrunFotografı = strDosyaAdi;
                _contextDB.Add(_menu);
            }

            await _contextDB.SaveChangesAsync();
            return RedirectToAction("Listele");

            //}
        }
    }
}
