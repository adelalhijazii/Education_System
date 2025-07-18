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
    public class MasterCoursesController : Controller
    {
        public IRepository<MasterCourses> MasterCourses { get; }
        public UserManager<AppUser> UserManager { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Hosting { get; }

        public MasterCoursesController(IRepository<MasterCourses> _masterCourses, UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting)
        {
            MasterCourses = _masterCourses;
            UserManager = _userManager;
            Hosting = _hosting;
        }
        // GET: MasterCoursesController
        public ActionResult Index()
        {
            var data = MasterCourses.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterCourses.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterCourses.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterCoursesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterCoursesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterCoursesViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (!ModelState.IsValid)
                {
                    return View();
                }
                string ImageName = "";
                if (collection.MasterCoursesFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterCourses");
                    FileInfo fi = new FileInfo(collection.MasterCoursesFile.FileName);
                    ImageName = "MasterCoursesImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterCoursesFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                MasterCourses obj = new MasterCourses
                {
                    MasterCoursesId = collection.MasterCoursesId,
                    MasterCoursesTitle = collection.MasterCoursesTitle,
                    MasterCoursesPrice = collection.MasterCoursesPrice,
                    MasterCoursesBreef = collection.MasterCoursesBreef,
                    MasterCoursesDescription = collection.MasterCoursesDescription,
                    MasterCoursesImageUrl = ImageName,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterCourses.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCoursesController/Edit
        public ActionResult Edit(int id)
        {
            var data = MasterCourses.Find(id);
            MasterCoursesViewModel coursesmodel = new MasterCoursesViewModel();
            coursesmodel.MasterCoursesId = data.MasterCoursesId;
            coursesmodel.MasterCoursesTitle = data.MasterCoursesTitle;
            coursesmodel.MasterCoursesPrice = data.MasterCoursesPrice;
            coursesmodel.MasterCoursesBreef = data.MasterCoursesBreef;
            coursesmodel.MasterCoursesDescription = data.MasterCoursesDescription;
            coursesmodel.MasterCoursesImageUrl = data.MasterCoursesImageUrl;
            coursesmodel.CreateUser = data.CreateUser;
            coursesmodel.CreateDate = data.CreateDate;
            return View(coursesmodel);
        }

        // POST: MasterCoursesController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterCoursesViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageName = "";
                if (collection.MasterCoursesFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterCourses");
                    FileInfo fi = new FileInfo(collection.MasterCoursesFile.FileName);
                    ImageName = "MasterCoursesImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterCoursesFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var obj = new MasterCourses
                {
                    MasterCoursesId = collection.MasterCoursesId,
                    MasterCoursesTitle = collection.MasterCoursesTitle,
                    MasterCoursesPrice = collection.MasterCoursesPrice,
                    MasterCoursesBreef = collection.MasterCoursesBreef,
                    MasterCoursesDescription = collection.MasterCoursesDescription,
                    MasterCoursesImageUrl = (ImageName != "") ? ImageName : collection.MasterCoursesImageUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterCourses.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCoursesController/Delete
        public ActionResult Delete(int Delete)
        {
            MasterCourses.Delete(Delete, new Models.MasterCourses { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
