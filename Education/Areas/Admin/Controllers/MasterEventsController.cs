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
    public class MasterEventsController : Controller
    {
        public IRepository<MasterEvents> MasterEvents { get; }
        public UserManager<AppUser> UserManager { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Hosting { get; }

        public MasterEventsController(IRepository<MasterEvents> _masterEvents, UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting)
        {
            MasterEvents = _masterEvents;
            UserManager = _userManager;
            Hosting = _hosting;
        }
        // GET: MasterEventsController
        public ActionResult Index()
        {
            var data = MasterEvents.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterEvents.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterEvents.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterEventsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterEventsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterEventsViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (!ModelState.IsValid)
                {
                    return View();
                }
                string ImageName = "";
                if (collection.MasterEventsFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterEvents");
                    FileInfo fi = new FileInfo(collection.MasterEventsFile.FileName);
                    ImageName = "MasterEventsImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterEventsFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                MasterEvents obj = new MasterEvents
                {
                    MasterEventsId = collection.MasterEventsId,
                    MasterEventsTitle = collection.MasterEventsTitle,
                    MasterEventsDate = collection.MasterEventsDate,
                    MasterEventsDescription = collection.MasterEventsDescription,
                    MasterEventsImageUrl = ImageName,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterEvents.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterEventsController/Edit
        public ActionResult Edit(int id)
        {
            var data = MasterEvents.Find(id);
            MasterEventsViewModel eventsmodel = new MasterEventsViewModel();
            eventsmodel.MasterEventsId = data.MasterEventsId;
            eventsmodel.MasterEventsTitle = data.MasterEventsTitle;
            eventsmodel.MasterEventsDate = data.MasterEventsDate;
            eventsmodel.MasterEventsDescription = data.MasterEventsDescription;
            eventsmodel.MasterEventsImageUrl = data.MasterEventsImageUrl;
            eventsmodel.CreateUser = data.CreateUser;
            eventsmodel.CreateDate = data.CreateDate;
            return View(eventsmodel);
        }

        // POST: MasterEventsController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterEventsViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageName = "";
                if (collection.MasterEventsFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterEvents");
                    FileInfo fi = new FileInfo(collection.MasterEventsFile.FileName);
                    ImageName = "MasterEventsImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterEventsFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var obj = new MasterEvents
                {
                    MasterEventsId = collection.MasterEventsId,
                    MasterEventsTitle = collection.MasterEventsTitle,
                    MasterEventsDate = collection.MasterEventsDate,
                    MasterEventsDescription = collection.MasterEventsDescription,
                    MasterEventsImageUrl = (ImageName != "") ? ImageName : collection.MasterEventsImageUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterEvents.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterEventsController/Delete
        public ActionResult Delete(int Delete)
        {
            MasterEvents.Delete(Delete, new Models.MasterEvents { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
