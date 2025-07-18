﻿using Education.Areas.Admin.ViewModels;
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
    public class MasterSocialMediumController : Controller
    {
        public IRepository<MasterSocialMedium> MasterSocialMedium { get; }
        public UserManager<AppUser> UserManager { get; }

        public MasterSocialMediumController(IRepository<MasterSocialMedium> _masterSocialMedium, UserManager<AppUser> _userManager)
        {
            MasterSocialMedium = _masterSocialMedium;
            UserManager = _userManager;
        }
        // GET: MasterSocialMediumController
        public ActionResult Index()
        {
            var data = MasterSocialMedium.View();
            return View(data);
        }

        public ActionResult Active(int id)
        {
            var data = MasterSocialMedium.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterSocialMedium.Active(id, data);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterSocialMediumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSocialMediumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterSocialMediumViewModel collection)
        {
            try
            {
                var user =await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterSocialMedium
                {
                    MasterSocialMediumId = collection.MasterSocialMediumId,
                    MasterSocialMediumIcon = collection.MasterSocialMediumIcon,
                    MasterSocialMediumUrl = collection.MasterSocialMediumUrl,
                    CreateUser = user.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                MasterSocialMedium.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediumController/Edit
        public ActionResult Edit(int id)
        {
            var data = MasterSocialMedium.Find(id);
            MasterSocialMediumViewModel socialmediummodel = new MasterSocialMediumViewModel();
            socialmediummodel.MasterSocialMediumId = data.MasterSocialMediumId;
            socialmediummodel.MasterSocialMediumIcon = data.MasterSocialMediumIcon;
            socialmediummodel.MasterSocialMediumUrl = data.MasterSocialMediumUrl;
            socialmediummodel.CreateUser = data.CreateUser;
            socialmediummodel.CreateDate = data.CreateDate;
            return View(socialmediummodel);
        }

        // POST: MasterSocialMediumController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterSocialMediumViewModel collection)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(User.Identity.Name);
                var data = new MasterSocialMedium
                {
                    MasterSocialMediumId = collection.MasterSocialMediumId,
                    MasterSocialMediumIcon = collection.MasterSocialMediumIcon,
                    MasterSocialMediumUrl = collection.MasterSocialMediumUrl,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditUser = user.Id,
                    EditDate = DateTime.Now,
                    IsActive = true
                };
                MasterSocialMedium.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediumController/Delete
        public ActionResult Delete(int Delete)
        {
            MasterSocialMedium.Delete(Delete, new Models.MasterSocialMedium { EditUser = User.Identity.Name, EditDate = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }
    }
}
