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
    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> SystemSetting { get; }
        public UserManager<AppUser> UserManager { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Hosting { get; }

        public SystemSettingController(IRepository<SystemSetting> _systemSetting, UserManager<AppUser> _userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting)
        {
            SystemSetting = _systemSetting;
            UserManager = _userManager;
            Hosting = _hosting;
        }
        // GET: SystemSettingController
        public ActionResult Index()
        {
            var data = SystemSetting.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = SystemSetting.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            SystemSetting.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        // GET: SystemSettingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemSettingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SystemSettingViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (!ModelState.IsValid)
                {
                    return View();
                }
                string ImageName2 = "";
                
                if (collection.SystemSettingFile2 != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/SystemSetting");
                    FileInfo fi = new FileInfo(collection.SystemSettingFile2.FileName);
                    ImageName2 = "SystemSettingWelcomeNoteImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName2);
                    collection.SystemSettingFile2.CopyTo(new FileStream(FullPath, FileMode.Create));
                }

                SystemSetting obj = new SystemSetting
                {
                    SystemSettingId = collection.SystemSettingId,
                    SystemSettingLogoImageUrl = collection.SystemSettingLogoImageUrl,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDescription = collection.SystemSettingWelcomeNoteDescription,
                    SystemSettingWelcomeNoteImageUrl = ImageName2,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true

                };
                SystemSetting.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Edit
        public ActionResult Edit(int id)
        {
            var data = SystemSetting.Find(id);
            SystemSettingViewModel settingmodel = new SystemSettingViewModel();
            settingmodel.SystemSettingId = data.SystemSettingId;
            settingmodel.SystemSettingLogoImageUrl = data.SystemSettingLogoImageUrl;
            settingmodel.SystemSettingWelcomeNoteTitle = data.SystemSettingWelcomeNoteTitle;
            settingmodel.SystemSettingWelcomeNoteBreef = data.SystemSettingWelcomeNoteBreef;
            settingmodel.SystemSettingWelcomeNoteDescription = data.SystemSettingWelcomeNoteDescription;
            settingmodel.SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl;
            settingmodel.SystemSettingCopyright = data.SystemSettingCopyright;
            settingmodel.CreateUser = data.CreateUser;
            settingmodel.CreateDate = data.CreateDate;
            return View(settingmodel);
        }

        // POST: SystemSettingController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SystemSettingViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                string ImageName2 = "";

                if (collection.SystemSettingFile2 != null)
                {
                    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/SystemSetting");
                    FileInfo fi = new FileInfo(collection.SystemSettingFile2.FileName);
                    ImageName2 = "SystemSettingWelcomeNoteImageUrl" + Guid.NewGuid() + fi.Extension;

                    string FullPath = Path.Combine(PathImage, ImageName2);
                    collection.SystemSettingFile2.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var obj = new SystemSetting
                {
                    SystemSettingId = collection.SystemSettingId,
                    SystemSettingLogoImageUrl = collection.SystemSettingLogoImageUrl,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDescription = collection.SystemSettingWelcomeNoteDescription,
                    SystemSettingWelcomeNoteImageUrl = (ImageName2 != "") ? ImageName2 : collection.SystemSettingWelcomeNoteImageUrl,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                SystemSetting.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Delete
        public ActionResult Delete(int Delete)
        {
            SystemSetting.Delete(Delete, new Models.SystemSetting { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}



//EditPost
//if (collection.SystemSettingFile1 != null)
//{
//    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/SystemSetting");
//    FileInfo fi = new FileInfo(collection.SystemSettingFile1.FileName);
//    ImageName1 = "SystemSettingLogoImageUrl" + Guid.NewGuid() + fi.Extension;

//    string FullPath = Path.Combine(PathImage, ImageName1);
//    collection.SystemSettingFile1.CopyTo(new FileStream(FullPath, FileMode.Create));
//    obj.SystemSettingLogoImageUrl = ImageName1;
//}
//else
//{
//    var data = SystemSetting.Find(id);
//    obj.SystemSettingLogoImageUrl = data.SystemSettingLogoImageUrl;
//}

//if (collection.SystemSettingFile2 != null)
//{
//    string PathImage = Path.Combine(Hosting.WebRootPath, "Pictures/SystemSetting");
//    FileInfo fi = new FileInfo(collection.SystemSettingFile2.FileName);
//    ImageName2 = "SystemSettingWelcomeNoteImageUrl" + Guid.NewGuid() + fi.Extension;

//    string FullPath = Path.Combine(PathImage, ImageName2);
//    collection.SystemSettingFile2.CopyTo(new FileStream(FullPath, FileMode.Create));
//    obj.SystemSettingWelcomeNoteImageUrl = ImageName2;
//}
//else
//{
//    var data = SystemSetting.Find(id);
//    obj.SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl;
//}