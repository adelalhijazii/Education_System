using Education.Areas.Admin.ViewModels;
using Education.Models;
using Education.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Education.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterAboutUsController : Controller
    {
        public IRepository<MasterAboutUs> MasterAboutUs { get; }
        public UserManager<AppUser> UserManager { get; }

        public MasterAboutUsController(IRepository<MasterAboutUs> _masterAboutUs, UserManager<AppUser> _userManager)
        {
            MasterAboutUs = _masterAboutUs;
            UserManager = _userManager;
        }
        // GET: MasterAboutUsController
        public ActionResult Index()
        {
            var data = MasterAboutUs.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterAboutUs.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterAboutUs.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterAboutUsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterAboutUsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterAboutUsViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterAboutUs
                {
                    MasterAboutUsId = collection.MasterAboutUsId,
                    MasterAboutUsTitle = collection.MasterAboutUsTitle,
                    MasterAboutUsDescription = collection.MasterAboutUsDescription,
                    MasterAboutUsPhone = collection.MasterAboutUsPhone,
                    MasterAboutUsEmail = collection.MasterAboutUsEmail,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterAboutUs.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterAboutUsController/Edit
        public ActionResult Edit(int id)
        {
            var data = MasterAboutUs.Find(id);
            MasterAboutUsViewModel aboutusmodel = new MasterAboutUsViewModel();
            aboutusmodel.MasterAboutUsId = data.MasterAboutUsId;
            aboutusmodel.MasterAboutUsTitle = data.MasterAboutUsTitle;
            aboutusmodel.MasterAboutUsDescription = data.MasterAboutUsDescription;
            aboutusmodel.MasterAboutUsPhone = data.MasterAboutUsPhone;
            aboutusmodel.MasterAboutUsEmail = data.MasterAboutUsEmail;
            aboutusmodel.CreateUser = data.CreateUser;
            aboutusmodel.CreateDate = data.CreateDate;
            return View(aboutusmodel);
        }

        // POST: MasterAboutUsController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterAboutUsViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterAboutUs
                {
                    MasterAboutUsId = collection.MasterAboutUsId,
                    MasterAboutUsTitle = collection.MasterAboutUsTitle,
                    MasterAboutUsDescription = collection.MasterAboutUsDescription,
                    MasterAboutUsPhone = collection.MasterAboutUsPhone,
                    MasterAboutUsEmail = collection.MasterAboutUsEmail,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterAboutUs.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterAboutUsController/Delete
        public ActionResult Delete(int Delete)
        {
            MasterAboutUs.Delete(Delete, new Models.MasterAboutUs { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
