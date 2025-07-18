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
    public class MasterContactUsInformationController : Controller
    {
        public IRepository<MasterContactUsInformation> MasterContactUsInformation { get; }
        public UserManager<AppUser> UserManager { get; }

        public MasterContactUsInformationController(IRepository<MasterContactUsInformation> _masterContactUsInformation, UserManager<AppUser> _userManager)
        {
            MasterContactUsInformation = _masterContactUsInformation;
            UserManager = _userManager;
        }
        // GET: MasterContactUsInformationController
        public ActionResult Index()
        {
            var data = MasterContactUsInformation.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterContactUsInformation.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterContactUsInformation.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterContactUsInformationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterContactUsInformationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterContactUsInformationViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterContactUsInformation
                {
                    MasterContactUsInformationId = collection.MasterContactUsInformationId,
                    MasterContactUsInformationDescription = collection.MasterContactUsInformationDescription,
                    MasterContactUsInformationIcon = collection.MasterContactUsInformationIcon,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterContactUsInformation.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Edit
        public ActionResult Edit(int id)
        {
            var data = MasterContactUsInformation.Find(id);
            MasterContactUsInformationViewModel contactusmodel = new MasterContactUsInformationViewModel();
            contactusmodel.MasterContactUsInformationId = data.MasterContactUsInformationId;
            contactusmodel.MasterContactUsInformationDescription = data.MasterContactUsInformationDescription;
            contactusmodel.MasterContactUsInformationIcon = data.MasterContactUsInformationIcon;
            contactusmodel.CreateUser = data.CreateUser;
            contactusmodel.CreateDate = data.CreateDate;
            return View(contactusmodel);
        }

        // POST: MasterContactUsInformationController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterContactUsInformationViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterContactUsInformation
                {
                    MasterContactUsInformationId = collection.MasterContactUsInformationId,
                    MasterContactUsInformationDescription = collection.MasterContactUsInformationDescription,
                    MasterContactUsInformationIcon = collection.MasterContactUsInformationIcon,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterContactUsInformation.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Delete
        public ActionResult Delete(int Delete)
        {
            MasterContactUsInformation.Delete(Delete, new Models.MasterContactUsInformation { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
