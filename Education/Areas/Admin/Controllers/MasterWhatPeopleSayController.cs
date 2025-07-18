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
    public class MasterWhatPeopleSayController : Controller
    {
        public IRepository<MasterWhatPeopleSay> MasterWhatPeopleSay { get; }
        public UserManager<AppUser> UserManager { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Hosting { get; }

        public MasterWhatPeopleSayController(IRepository<MasterWhatPeopleSay> _masterWhatPeopleSay, UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting)
        {
            MasterWhatPeopleSay = _masterWhatPeopleSay;
            UserManager = _userManager;
            Hosting = _hosting;
        }
        // GET: MasterWhatPeopleSayController
        public ActionResult Index()
        {
            var data = MasterWhatPeopleSay.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterWhatPeopleSay.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterWhatPeopleSay.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterWhatPeopleSayController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterWhatPeopleSayController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterWhatPeopleSayViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (!ModelState.IsValid)
                {
                    return View();
                }
                string ImageName = "";
                if (collection.MasterWhatPeopleSayFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterWhatPeopleSay");
                    FileInfo fi = new FileInfo(collection.MasterWhatPeopleSayFile.FileName);
                    ImageName = "MasterWhatPeopleSayImagesUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterWhatPeopleSayFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                MasterWhatPeopleSay obj = new MasterWhatPeopleSay
                {
                    MasterWhatPeopleSayId = collection.MasterWhatPeopleSayId,
                    MasterWhatPeopleSayTitle = collection.MasterWhatPeopleSayTitle,
                    MasterWhatPeopleSayBreef = collection.MasterWhatPeopleSayBreef,
                    MasterWhatPeopleSayDescription = collection.MasterWhatPeopleSayDescription,
                    MasterWhatPeopleSayImagesUrl = ImageName,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterWhatPeopleSay.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWhatPeopleSayController/Edit
        public ActionResult Edit(int id)
        {
            var data = MasterWhatPeopleSay.Find(id);
            MasterWhatPeopleSayViewModel whatpeoplesaymodel = new MasterWhatPeopleSayViewModel();
            whatpeoplesaymodel.MasterWhatPeopleSayId = data.MasterWhatPeopleSayId;
            whatpeoplesaymodel.MasterWhatPeopleSayTitle = data.MasterWhatPeopleSayTitle;
            whatpeoplesaymodel.MasterWhatPeopleSayBreef = data.MasterWhatPeopleSayBreef;
            whatpeoplesaymodel.MasterWhatPeopleSayDescription = data.MasterWhatPeopleSayDescription;
            whatpeoplesaymodel.MasterWhatPeopleSayImagesUrl = data.MasterWhatPeopleSayImagesUrl;
            whatpeoplesaymodel.CreateUser = data.CreateUser;
            whatpeoplesaymodel.CreateDate = data.CreateDate;
            return View(whatpeoplesaymodel);
        }

        // POST: MasterWhatPeopleSayController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterWhatPeopleSayViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageName = "";
                if (collection.MasterWhatPeopleSayFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterWhatPeopleSay");
                    FileInfo fi = new FileInfo(collection.MasterWhatPeopleSayFile.FileName);
                    ImageName = "MasterWhatPeopleSayImagesUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterWhatPeopleSayFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var obj = new MasterWhatPeopleSay
                {
                    MasterWhatPeopleSayId = collection.MasterWhatPeopleSayId,
                    MasterWhatPeopleSayTitle = collection.MasterWhatPeopleSayTitle,
                    MasterWhatPeopleSayBreef = collection.MasterWhatPeopleSayBreef,
                    MasterWhatPeopleSayDescription = collection.MasterWhatPeopleSayDescription,
                    MasterWhatPeopleSayImagesUrl = (ImageName != "") ? ImageName : collection.MasterWhatPeopleSayImagesUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterWhatPeopleSay.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWhatPeopleSayController/Delete
        public ActionResult Delete(int Delete)
        {
            MasterWhatPeopleSay.Delete(Delete, new Models.MasterWhatPeopleSay { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
