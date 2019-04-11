using MebelTemplate.DAL;
using MebelTemplate.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MebelTemplate.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public readonly Db db;
        public HomeController()
        {
            db = new Db();
        }
        // GET: Admin/Home
        public async Task<ActionResult> Index()
        {
            var model = await db.Homes.ToListAsync();
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id==null&&id==0)
            {
                TempData["SM"] = "Bele Basliq movcud deyil";
                return RedirectToAction("Index");
            }
            var homeModel = await db.Homes.FirstOrDefaultAsync(h => h.Id == id);
            return View(homeModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(HomeDTO home,HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(" ", "duzgun yazilmayib metin !!!!");
                return View(home);
            }
            int id = home.Id;
            HomeDTO dto = await db.Homes.FirstOrDefaultAsync(x => x.Id == id);
            dto.HeaderTitle = home.HeaderTitle;
            dto.HeaderPrice =home.HeaderPrice;
            await db.SaveChangesAsync();

            #region imageUpload

            if (file != null && file.ContentLength > 0)
            {

                // Get extension
                string ext = file.ContentType.ToLower();

                // Verify extension
                if (ext != "image/jpg" &&
                    ext != "image/jpeg" &&
                    ext != "image/pjpeg" &&
                    ext != "image/gif" &&
                    ext != "image/x-png" &&
                    ext != "image/png")
                {
                    
                        ModelState.AddModelError("", "The image was not uploaded - wrong image extension.");
                        return View(home);
                    
                }

                // Set uplpad directory paths
                var originalDirectory = new DirectoryInfo(string.Format("{0}Content\\img", Server.MapPath(@"\")));

                var pathString1 = Path.Combine(originalDirectory.ToString(), "slider\\" + id.ToString());
                var pathString2 = Path.Combine(originalDirectory.ToString(), "slider\\" + id.ToString() + "\\thumbs");

                if (!Directory.Exists(pathString1))
                    Directory.CreateDirectory(pathString1);
                if (!Directory.Exists(pathString2))
                    Directory.CreateDirectory(pathString2);
                // Delete files from directories

                DirectoryInfo di1 = new DirectoryInfo(pathString1);
                DirectoryInfo di2 = new DirectoryInfo(pathString2);

                foreach (FileInfo file2 in di1.GetFiles())
                    file2.Delete();
                foreach (FileInfo file3 in di2.GetFiles())
                    file3.Delete();
                if (di1.GetFiles() == null)
                {
                    ModelState.AddModelError("Image", "Sekilin yolu movcud deyil");
                }
                //foreach (FileInfo file3 in di2.GetFiles())
                //    file3.Delete();

                // Save image name

                string imageName = file.FileName;


                HomeDTO dtoBase = await db.Homes.FindAsync(id);
                dtoBase.Image = imageName;

                await db.SaveChangesAsync();


                // Save original and thumb images

                var path = string.Format("{0}\\{1}", pathString1, imageName);
                var path2 = string.Format("{0}\\{1}", pathString2, imageName);

                file.SaveAs(path);

                WebImage img = new WebImage(file.InputStream);
                img.Resize(200, 200);
                img.Save(path2);
            }

            #endregion
            TempData["SM"] = "You have edited the home page!";

            return RedirectToAction("Index");
        }
    }
}