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
    public class MasterWhyChooseController : Controller
    {
        public IRepository<MasterWhyChoose> MasterWhyChoose { get; }
        public UserManager<AppUser> UserManager { get; }

        public MasterWhyChooseController(IRepository<MasterWhyChoose> _masterWhyChoose, UserManager<AppUser> _userManager)
        {
            MasterWhyChoose = _masterWhyChoose;
            UserManager = _userManager;
        }
        // GET: MasterWhyChooseController
        public ActionResult Index()
        {
            var data = MasterWhyChoose.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterWhyChoose.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterWhyChoose.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterWhyChooseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterWhyChooseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterWhyChooseViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterWhyChoose
                {
                    MasterWhyChooseId = collection.MasterWhyChooseId,
                    MasterWhyChooseIcon = collection.MasterWhyChooseIcon,
                    MasterWhyChooseTitle = collection.MasterWhyChooseTitle,
                    MasterWhyChooseDescription = collection.MasterWhyChooseDescription,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterWhyChoose.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWhyChooseController/Edit
        public ActionResult Edit(int id)
        {
            var data = MasterWhyChoose.Find(id);
            MasterWhyChooseViewModel whychoosemodel = new MasterWhyChooseViewModel();
            whychoosemodel.MasterWhyChooseId = data.MasterWhyChooseId;
            whychoosemodel.MasterWhyChooseIcon = data.MasterWhyChooseIcon;
            whychoosemodel.MasterWhyChooseTitle = data.MasterWhyChooseTitle;
            whychoosemodel.MasterWhyChooseDescription = data.MasterWhyChooseDescription;
            whychoosemodel.CreateUser = data.CreateUser;
            whychoosemodel.CreateDate = data.CreateDate;
            return View(whychoosemodel);
        }

        // POST: MasterWhyChooseController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterWhyChooseViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterWhyChoose
                {
                    MasterWhyChooseId = collection.MasterWhyChooseId,
                    MasterWhyChooseIcon = collection.MasterWhyChooseIcon,
                    MasterWhyChooseTitle = collection.MasterWhyChooseTitle,
                    MasterWhyChooseDescription = collection.MasterWhyChooseDescription,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterWhyChoose.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWhyChooseController/Delete
        public ActionResult Delete(int Delete)
        {
            MasterWhyChoose.Delete(Delete, new Models.MasterWhyChoose { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
