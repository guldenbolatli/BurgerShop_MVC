using Hamburger_MVC.DAL;
using Hamburger_MVC.Models;
using Hamburger_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hamburger_MVC.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class KullaniciController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ContextDB _contextDB;

        public KullaniciController(UserManager<User> userManager, ContextDB contextDB)
        {
            _userManager = userManager;
            _contextDB = contextDB;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail()
        {
            User user = await _userManager.GetUserAsync(User);
            UserAdresVM userAdresVM = new UserAdresVM()
            {
                User = user,
                Adresler = _contextDB.Adresler.Where(x => x.UserID == user.Id).ToList(),
            };
            return View(userAdresVM);
        }

        public async Task<IActionResult> Edit(User user)
        {
            User editUser = _contextDB.Users.FirstOrDefault(x => x.Id.Equals(user.Id));
            if(user.Ad!=null && user.Soyad != null)
            {
                editUser.Ad = user.Ad;
                editUser.Soyad = user.Soyad;
                editUser.PhoneNumber = user.PhoneNumber;
                await _userManager.UpdateAsync(editUser);
            }

            return RedirectToAction("Detail");
        }
        public async Task<IActionResult> EditEmail()
        {
            User editUser = await _userManager.GetUserAsync(User);
            EditEmailVM editEmailVM = new EditEmailVM()
            {
                CurrentEmail = editUser.Email,
            };

            return View(editEmailVM);


        }
        [HttpPost]
        public async Task<IActionResult> EditEmail(EditEmailVM user)
        {
            User editUser = _contextDB.Users.FirstOrDefault(x => x.Email.Equals(user.CurrentEmail));
            if (editUser != null)
            {
                bool isPasswordValid = await _userManager.CheckPasswordAsync(editUser, user.Password);
                if (isPasswordValid)
                {
                    editUser.Email = user.NewEmail;
                    editUser.UserName = user.NewEmail;
                }
            }
            await _userManager.UpdateAsync(editUser);
            return RedirectToAction("Detail");


        }
        public IActionResult AdresEkle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdresEkle(Adres adres)
        {
            User user = await _userManager.GetUserAsync(User);
            adres.UserID = user.Id;
            _contextDB.Adresler.Add(adres);
            _contextDB.SaveChanges();

            return RedirectToAction("Detail");
        }

    }
}
