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
    public class MasterFeaturesController : Controller
    {
        public IRepository<MasterFeatures> MasterFeatures { get; }
        public UserManager<AppUser> UserManager { get; }

        public MasterFeaturesController(IRepository<MasterFeatures> _masterFeatures, UserManager<AppUser> _userManager)
        {
            MasterFeatures = _masterFeatures;
            UserManager = _userManager;
        }
        // GET: MasterFeaturesController
        public ActionResult Index()
        {
            var data = MasterFeatures.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterFeatures.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterFeatures.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterFeaturesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterFeaturesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterFeaturesViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterFeatures
                {
                    MasterFeaturesId = collection.MasterFeaturesId,
                    MasterFeaturesIcon = collection.MasterFeaturesIcon,
                    MasterFeaturesTitle = collection.MasterFeaturesTitle,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterFeatures.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterFeaturesController/Edit
        public ActionResult Edit(int id)
        {
            var data = MasterFeatures.Find(id);
            MasterFeaturesViewModel featuresmodel = new MasterFeaturesViewModel();
            featuresmodel.MasterFeaturesId = data.MasterFeaturesId;
            featuresmodel.MasterFeaturesIcon = data.MasterFeaturesIcon;
            featuresmodel.MasterFeaturesTitle = data.MasterFeaturesTitle;
            featuresmodel.CreateUser = data.CreateUser;
            featuresmodel.CreateDate = data.CreateDate;
            return View(featuresmodel);
        }

        // POST: MasterFeaturesController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterFeaturesViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterFeatures
                {
                    MasterFeaturesId = collection.MasterFeaturesId,
                    MasterFeaturesIcon = collection.MasterFeaturesIcon,
                    MasterFeaturesTitle = collection.MasterFeaturesTitle,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterFeatures.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterFeaturesController/Delete
        public ActionResult Delete(int Delete)
        {
            MasterFeatures.Delete(Delete, new Models.MasterFeatures { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
