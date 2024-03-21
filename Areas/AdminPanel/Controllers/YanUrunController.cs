using Hamburger_MVC.DAL;
using Hamburger_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hamburger_MVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Policy = "AdminOnly")]
    public class YanUrunController : Controller
    {
        private readonly ContextDB db;

        public YanUrunController(ContextDB _db)
        {
            db = _db;
        }

        public IActionResult Listele()
        {
            var yanUrunContext = db.YanUrunler.ToList();
            return View(yanUrunContext);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(YanUrun yanUrun)
        {
            string strDosyaAdi = yanUrun.Fotograf.FileName;
            FileStream fs = new FileStream("wwwroot/Admin/urunFoto/" + strDosyaAdi, FileMode.Create);
            await yanUrun.Fotograf.CopyToAsync(fs);
            fs.Close();
            yanUrun.UrunFotografı = strDosyaAdi;
            db.Add(yanUrun);
            await db.SaveChangesAsync();
            return Content("Eklendi");

        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || db.YanUrunler == null)
            {
                return NotFound();

            }
            var yanurun = await db.YanUrunler.FindAsync(id);
            if (yanurun == null)
            {
                return NotFound();
            }
            return View(yanurun);

        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, YanUrun yanUrun)
        {
            if (id == yanUrun.ID)
            {
                try
                {
                    if (yanUrun.Fotograf != null)
                    {
                        string strDosyaAdi = yanUrun.Fotograf.FileName;
                        FileStream fs = new FileStream("wwwroot/Admin/urunfoto/" + strDosyaAdi, FileMode.Create);
                        await yanUrun.Fotograf.CopyToAsync(fs);
                        fs.Close();
                        yanUrun.UrunFotografı = strDosyaAdi;
                    }
                    else
                    {
                        yanUrun.UrunFotografı = db.YanUrunler.Where(x => x.ID == yanUrun.ID).Select(s => s.UrunFotografı).FirstOrDefault();
                    }
                    db.Update(yanUrun);
                    await db.SaveChangesAsync();
                    return Content("Güncellendi");
                }
                catch (Exception)
                {
                    if (!YanUrunExists(yanUrun.ID))
                    {
                        return Content("Yan Urun Exixts false");
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(yanUrun);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || db.YanUrunler == null)
            {
                return NotFound();

            }
            var sos = await db.YanUrunler
                .Include(s => s.YanUrun_Customs)
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
            if (db.YanUrunler == null)
            {
                return Problem("Entity set 'ContextDB.Soslar' is null");
            }
            var sos = await db.YanUrunler.FindAsync(id);
            if (sos != null)
            {
                db.YanUrunler.Remove(sos);

            }
            await db.SaveChangesAsync();
            return RedirectToAction("Listele");

        }
        private bool YanUrunExists(int id)
        {
            return (db.YanUrunler?.Any(s => s.ID == id)).GetValueOrDefault();
        }

    }
}
