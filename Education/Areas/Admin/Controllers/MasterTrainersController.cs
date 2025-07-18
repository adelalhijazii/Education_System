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
    public class MasterTrainersController : Controller
    {
        public IRepository<MasterTrainers> MasterTrainers { get; }
        public UserManager<AppUser> UserManager { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Hosting { get; }

        public MasterTrainersController(IRepository<MasterTrainers> _masterTrainers, UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting)
        {
            MasterTrainers = _masterTrainers;
            UserManager = _userManager;
            Hosting = _hosting;
        }
        // GET: MasterTrainersController
        public ActionResult Index()
        {
            var data = MasterTrainers.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterTrainers.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterTrainers.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterTrainersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterTrainersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterTrainersViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (!ModelState.IsValid)
                {
                    return View();
                }
                string ImageName = "";
                if (collection.MasterTrainersFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterTrainers");
                    FileInfo fi = new FileInfo(collection.MasterTrainersFile.FileName);
                    ImageName = "MasterTrainersImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterTrainersFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                MasterTrainers obj = new MasterTrainers
                {
                    MasterTrainersId = collection.MasterTrainersId,
                    MasterTrainersTitle = collection.MasterTrainersTitle,
                    MasterTrainersBreef = collection.MasterTrainersBreef,
                    MasterTrainersDescription = collection.MasterTrainersDescription,
                    MasterTrainersImageUrl = ImageName,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterTrainers.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterTrainersController/Edit
        public ActionResult Edit(int id)
        {
            var data = MasterTrainers.Find(id);
            MasterTrainersViewModel trainersmodel = new MasterTrainersViewModel();
            trainersmodel.MasterTrainersId = data.MasterTrainersId;
            trainersmodel.MasterTrainersTitle = data.MasterTrainersTitle;
            trainersmodel.MasterTrainersBreef = data.MasterTrainersBreef;
            trainersmodel.MasterTrainersDescription = data.MasterTrainersDescription;
            trainersmodel.MasterTrainersImageUrl = data.MasterTrainersImageUrl;
            trainersmodel.CreateUser = data.CreateUser;
            trainersmodel.CreateDate = data.CreateDate;
            return View(trainersmodel);
        }

        // POST: MasterTrainersController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterTrainersViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageName = "";
                if (collection.MasterTrainersFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterTrainers");
                    FileInfo fi = new FileInfo(collection.MasterTrainersFile.FileName);
                    ImageName = "MasterTrainersImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterTrainersFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var obj = new MasterTrainers
                {
                    MasterTrainersId = collection.MasterTrainersId,
                    MasterTrainersTitle = collection.MasterTrainersTitle,
                    MasterTrainersBreef = collection.MasterTrainersBreef,
                    MasterTrainersDescription = collection.MasterTrainersDescription,
                    MasterTrainersImageUrl = (ImageName != "") ? ImageName : collection.MasterTrainersImageUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterTrainers.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterTrainersController/Delete
        public ActionResult Delete(int Delete)
        {
            MasterTrainers.Delete(Delete, new Models.MasterTrainers { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
