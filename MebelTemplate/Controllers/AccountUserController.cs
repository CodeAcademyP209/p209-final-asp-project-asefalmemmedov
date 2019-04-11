using MebelTemplate.DAL;
using MebelTemplate.Models;
using MebelTemplate.Models.ViewModel.Account;
using MebelTemplate.Models.ViewModel.Login;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace MebelTemplate.Controllers
{
    public class AccountUserController : Controller
    {
        private readonly Db db;

        public AccountUserController()
        {
            db = new Db();
        }
        // GET: Account
        public async Task<ActionResult> Index()
        {
            
            var model = await db.Users.ToListAsync();
            return View(model);
        }
        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View("CreateAccount", new UserVM());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAccount(UserVM model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Zehmet olmasa Xanalari doldurun");
                return View("CreateAccount", model);
            }

            if (db.Users.Any(u=>u.Username==model.Username))
            {
                ModelState.AddModelError("","Bele User movcuddur zehmet olmasa ");
                model.Username = "";
                return View("CreateAccount", model);
            }
            if (!model.Password.Equals(model.ConfirmPassword))
            {
                ModelState.AddModelError("", "zehmet olmas pasvordlari duzgun daxil edin ");
                model.Password = "";
                return View("CreateAccount", model);
            }
            var userPassvord = Crypto.HashPassword(model.Password);
            //var ConfirmUserPassvord = Crypto.HashPassword(model.ConfirmPassword);

            UserDTO dto = new UserDTO()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password =userPassvord
            };
            db.Users.Add(dto);
            await db.SaveChangesAsync();
            int id = dto.Id;
            UserRolsDTO rolsDTO = new UserRolsDTO() {
                UserId=id,
                RoleId=2
            };
            db.UserRols.Add(rolsDTO);
            await db.SaveChangesAsync();
            TempData["SM"] = "Qeydiyyatdan muveffeqiyyetle kecdiniz!!";
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            string username = User.Identity.Name;
            if (!string.IsNullOrEmpty(username))
            {
                return RedirectToAction("user-profile");
            }
            return View("Login",new LoginVM());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Xanalari Duzgun Doldurun");
                return View(model);
            }
            bool isValid = false;
            //string pass = db.Users.FirstOrDefault().Password;
            var pass = db.Users.FirstOrDefault(u => u.Username == model.Username).Password;
            //var modelpass = Crypto.HashPassword(model.PassWord);
            bool userParol = Crypto.VerifyHashedPassword(pass,model.PassWord);
            if (userParol && db.Users.Any(x=>x.Username.Equals(model.Username)))
            {
                isValid = true;
               
            }
            if (!isValid)
            {
                ModelState.AddModelError("", "Sizin parol ve ya Username yalnisdir!!!");
                return View("Login", model);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                return Redirect(FormsAuthentication.GetRedirectUrl(model.Username, model.RememberMe));
            }
        }
    }
}