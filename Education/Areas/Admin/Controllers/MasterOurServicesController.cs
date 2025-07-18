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
    public class MasterOurServicesController : Controller
    {
        public IRepository<MasterOurServices> MasterOurServices { get; }
        public UserManager<AppUser> UserManager { get; }

        public MasterOurServicesController(IRepository<MasterOurServices> _masterOurServices, UserManager<AppUser> _userManager)
        {
            MasterOurServices = _masterOurServices;
            UserManager = _userManager;
        }
        // GET: MasterOurServicesController
        public ActionResult Index()
        {
            var data = MasterOurServices.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterOurServices.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterOurServices.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterOurServicesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterOurServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterOurServicesViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterOurServices
                {
                    MasterOurServicesId = collection.MasterOurServicesId,
                    MasterOurServicesName = collection.MasterOurServicesName,
                    MasterOurServicesUrl = collection.MasterOurServicesUrl,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterOurServices.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOurServicesController/Edit
        public ActionResult Edit(int id)
        {
            var data = MasterOurServices.Find(id);
            MasterOurServicesViewModel ourservicesmodel = new MasterOurServicesViewModel();
            ourservicesmodel.MasterOurServicesId = data.MasterOurServicesId;
            ourservicesmodel.MasterOurServicesName = data.MasterOurServicesName;
            ourservicesmodel.MasterOurServicesUrl = data.MasterOurServicesUrl;
            ourservicesmodel.CreateUser = data.CreateUser;
            ourservicesmodel.CreateDate = data.CreateDate;
            return View(ourservicesmodel);
        }

        // POST: MasterOurServicesController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterOurServicesViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterOurServices
                {
                    MasterOurServicesId = collection.MasterOurServicesId,
                    MasterOurServicesName = collection.MasterOurServicesName,
                    MasterOurServicesUrl = collection.MasterOurServicesUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterOurServices.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOurServicesController/Delete
        public ActionResult Delete(int Delete)
        {
            MasterOurServices.Delete(Delete, new Models.MasterOurServices { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
