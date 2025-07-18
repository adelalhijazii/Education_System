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
    public class MasterSliderController : Controller
    {
        public IRepository<MasterSlider> MasterSlider { get; }
        public UserManager<AppUser> UserManager { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Hosting { get; }

        public MasterSliderController(IRepository<MasterSlider> _masterSlider, UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting)
        {
            MasterSlider = _masterSlider;
            UserManager = _userManager;
            Hosting = _hosting;
        }
        // GET: MasterSliderController
        public ActionResult Index()
        {
            var data = MasterSlider.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterSlider.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterSlider.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterSliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterSliderViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (!ModelState.IsValid)
                {
                    return View();
                }
                string ImageName = "";
                if (collection.MasterSliderFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterSlider");
                    FileInfo fi = new FileInfo(collection.MasterSliderFile.FileName);
                    ImageName = "MasterSliderImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterSliderFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                MasterSlider obj = new MasterSlider
                {
                    MasterSliderId = collection.MasterSliderId,
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderUrl = collection.MasterSliderUrl,
                    MasterSliderImageUrl = ImageName,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterSlider.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSliderController/Edit
        public ActionResult Edit(int id)
        {
            var data = MasterSlider.Find(id);
            MasterSliderViewModel slidermodel = new MasterSliderViewModel();
            slidermodel.MasterSliderId = data.MasterSliderId;
            slidermodel.MasterSliderTitle = data.MasterSliderTitle;
            slidermodel.MasterSliderBreef = data.MasterSliderBreef;
            slidermodel.MasterSliderUrl = data.MasterSliderUrl;
            slidermodel.MasterSliderImageUrl = data.MasterSliderImageUrl;
            slidermodel.CreateUser = data.CreateUser;
            slidermodel.CreateDate = data.CreateDate;
            return View(slidermodel);
        }

        // POST: MasterSliderController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterSliderViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageName = "";
                if (collection.MasterSliderFile != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/MasterSlider");
                    FileInfo fi = new FileInfo(collection.MasterSliderFile.FileName);
                    ImageName = "MasterSliderImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName);
                    collection.MasterSliderFile.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var obj = new MasterSlider
                {
                    MasterSliderId = collection.MasterSliderId,
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderUrl = collection.MasterSliderUrl,
                    MasterSliderImageUrl = (ImageName != "") ? ImageName : collection.MasterSliderImageUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterSlider.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSliderController/Delete
        public ActionResult Delete(int Delete)
        {
            MasterSlider.Delete(Delete, new Models.MasterSlider { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
