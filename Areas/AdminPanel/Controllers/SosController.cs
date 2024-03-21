using Hamburger_MVC.DAL;
using Hamburger_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Hamburger_MVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Policy = "AdminOnly")]
    public class SosController : Controller
    {
        private readonly ContextDB _contexDB;

        public SosController(ContextDB contexDB)
        {
            _contexDB = contexDB;
        }

        public IActionResult Listele()
        {
            var sosContext = _contexDB.Soslar.ToList();
            return View(sosContext);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Sos sos)
        {
            string strDosyaAdi = sos.Fotograf.FileName;
            FileStream fs = new FileStream("wwwroot/Admin/urunfoto/" + strDosyaAdi, FileMode.Create);
            await sos.Fotograf.CopyToAsync(fs);
            fs.Close();
            sos.UrunFotografı = strDosyaAdi;
            _contexDB.Add(sos);
            await _contexDB.SaveChangesAsync();
            return Content("Eklendi");
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || _contexDB.Soslar == null)
            {
                return NotFound();
            }
            var sos = await _contexDB.Soslar.FindAsync(id);
            if (sos == null)
            {
                return NotFound();
            }
            return View(sos);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Sos sos)
        {
            if (id == sos.ID)
            {
                try
                {
                    if (sos.Fotograf != null)
                    {
                        string strDosyaAdi = sos.Fotograf.FileName;
                        FileStream fs = new FileStream("wwwroot/Admin/urunFoto/" + strDosyaAdi, FileMode.Create);
                        await sos.Fotograf.CopyToAsync(fs);
                        fs.Close();
                        sos.UrunFotografı = strDosyaAdi;
                    }
                    else
                    {
                        sos.UrunFotografı = _contexDB.Soslar.Where(x => x.ID == sos.ID).Select(s => s.UrunFotografı).FirstOrDefault();
                    }
                    _contexDB.Update(sos);
                    await _contexDB.SaveChangesAsync();
                    return Content("Güncellendi");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SosExists(sos.ID))
                    {
                        return Content("Burger Exists false");
                    }
                    else
                    {
                        throw;
                    }
                }


            }
            return View(sos);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _contexDB.Soslar == null)
            {
                return NotFound();

            }
            var sos = await _contexDB.Soslar
                .Include(s => s.Sos_Customs)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sos == null)
            {
                return NotFound();
            }
            return View(sos);
        }
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id)
        {
            if (_contexDB.Soslar == null)
            {
                return Problem("Entity set 'ContextDB.Soslar' is null");
            }
            var sos = await _contexDB.Soslar.FindAsync(id);
            if (sos != null)
            {
                _contexDB.Soslar.Remove(sos);

            }
            await _contexDB.SaveChangesAsync();
            return RedirectToAction("Listele");

        }
        private bool SosExists(int id)
        {
            return (_contexDB.Soslar?.Any(s => s.ID == id)).GetValueOrDefault();
        }

    }
}
