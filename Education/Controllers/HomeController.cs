using Education.Models;
using Education.Models.Repository;
using Education.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Education.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IRepository<MasterAboutUs> _masterAboutUs, IRepository<MasterContactUsInformation> _masterContactUsInformation,
            IRepository<MasterCourses> _masterCourses, IRepository<MasterEvents> _masterEvents, IRepository<MasterFeatures> _masterFeatures,
            IRepository<MasterMenu> _masterMenu, IRepository<MasterOurServices> _masterOurServices, IRepository<MasterPricing> _masterPricing,
            IRepository<MasterSlider> _masterSlider, IRepository<MasterSocialMedium> _masterSocialMedium,IRepository<MasterTrainers> _masterTrainers,
            IRepository<MasterUsefullLinks> _masterUsefullLinks, IRepository<MasterWhatPeopleSay> _masterWhatPeopleSay, IRepository<MasterWhyChoose> _masterWhyChoose,
            IRepository<SystemSetting> _systemSetting, IRepository<TransactionContactUs> _transactionContactUs, IRepository<TransactionNewsLetter> _transactionNewsLetter)
        {
            MasterAboutUs = _masterAboutUs;
            MasterContactUsInformation = _masterContactUsInformation;
            MasterCourses = _masterCourses;
            MasterEvents = _masterEvents;
            MasterFeatures = _masterFeatures;
            MasterMenu = _masterMenu;
            MasterOurServices = _masterOurServices;
            MasterPricing = _masterPricing;
            MasterSlider = _masterSlider;
            MasterSocialMedium = _masterSocialMedium;
            MasterTrainers = _masterTrainers;
            MasterUsefullLinks = _masterUsefullLinks;
            MasterWhatPeopleSay = _masterWhatPeopleSay;
            MasterWhyChoose = _masterWhyChoose;
            SystemSetting = _systemSetting;
            TransactionContactUs = _transactionContactUs;
            TransactionNewsLetter = _transactionNewsLetter;
        }

        public IRepository<MasterAboutUs> MasterAboutUs { get; }
        public IRepository<MasterContactUsInformation> MasterContactUsInformation { get; }
        public IRepository<MasterCourses> MasterCourses { get; }
        public IRepository<MasterEvents> MasterEvents { get; }
        public IRepository<MasterFeatures> MasterFeatures { get; }
        public IRepository<MasterMenu> MasterMenu { get; }
        public IRepository<MasterOurServices> MasterOurServices { get; }
        public IRepository<MasterPricing> MasterPricing { get; }
        public IRepository<MasterSlider> MasterSlider { get; }
        public IRepository<MasterSocialMedium> MasterSocialMedium { get; }
        public IRepository<MasterTrainers> MasterTrainers { get; }
        public IRepository<MasterUsefullLinks> MasterUsefullLinks { get; }
        public IRepository<MasterWhatPeopleSay> MasterWhatPeopleSay { get; }
        public IRepository<MasterWhyChoose> MasterWhyChoose { get; }
        public IRepository<SystemSetting> SystemSetting { get; }
        public IRepository<TransactionContactUs> TransactionContactUs { get; }
        public IRepository<TransactionNewsLetter> TransactionNewsLetter { get; }

        public IActionResult Index()
        {
            HomeViewModel obj = new HomeViewModel();
            obj.AboutUs = MasterAboutUs.Find(1);
            obj.ListCourses = MasterCourses.ViewFromClient().ToList();
            obj.ListFeatures = MasterFeatures.ViewFromClient().ToList();
            obj.ListMenu = MasterMenu.ViewFromClient().ToList();
            obj.ListOurServices = MasterOurServices.ViewFromClient().ToList();
            obj.Slider = MasterSlider.Find(1);
            obj.ListSocialMedium = MasterSocialMedium.ViewFromClient().ToList();
            obj.ListTrainers = MasterTrainers.ViewFromClient().ToList();
            obj.ListUsefullLinks = MasterUsefullLinks.ViewFromClient().ToList();
            obj.ListWhyChoose = MasterWhyChoose.ViewFromClient().ToList();
            obj.Setting = SystemSetting.Find(1);
            return View(obj);
        }

        public IActionResult About()
        {
            HomeViewModel obj = new HomeViewModel();
            obj.AboutUs = MasterAboutUs.Find(1);
            obj.ListMenu = MasterMenu.ViewFromClient().ToList();
            obj.ListOurServices = MasterOurServices.ViewFromClient().ToList();
            obj.ListSocialMedium = MasterSocialMedium.ViewFromClient().ToList();
            obj.ListTrainers = MasterTrainers.ViewFromClient().ToList();
            obj.ListUsefullLinks = MasterUsefullLinks.ViewFromClient().ToList();
            obj.ListWhatPeopleSay = MasterWhatPeopleSay.ViewFromClient().ToList();
            obj.Setting = SystemSetting.Find(1);
            return View(obj);
        }

        public IActionResult Courses()
        {
            HomeViewModel obj = new HomeViewModel();
            obj.AboutUs = MasterAboutUs.Find(1);
            obj.ListCourses = MasterCourses.ViewFromClient();
            obj.ListMenu = MasterMenu.ViewFromClient().ToList();
            obj.ListOurServices = MasterOurServices.ViewFromClient().ToList();
            obj.ListSocialMedium = MasterSocialMedium.ViewFromClient().ToList();
            obj.ListUsefullLinks = MasterUsefullLinks.ViewFromClient().ToList();
            obj.Setting = SystemSetting.Find(1);
            return View(obj);
        }

        public IActionResult CourseDetails(int IdDetails)
        {
            HomeViewModel obj = new HomeViewModel();
            obj.AboutUs = MasterAboutUs.Find(1);
            obj.ListCourses = MasterCourses.ViewFromClient().ToList();
            obj.Courses = MasterCourses.Find(IdDetails);
            obj.ListMenu = MasterMenu.ViewFromClient().ToList();
            obj.ListOurServices = MasterOurServices.ViewFromClient().ToList();
            obj.ListSocialMedium = MasterSocialMedium.ViewFromClient().ToList();
            obj.ListTrainers = MasterTrainers.ViewFromClient().ToList();
            obj.ListUsefullLinks = MasterUsefullLinks.ViewFromClient().ToList();
            obj.Setting = SystemSetting.Find(1);
            return View(obj);
        }

        public IActionResult Trainers()
        {
            HomeViewModel obj = new HomeViewModel();
            obj.AboutUs = MasterAboutUs.Find(1);
            obj.ListMenu = MasterMenu.ViewFromClient().ToList();
            obj.ListOurServices = MasterOurServices.ViewFromClient().ToList();
            obj.ListSocialMedium = MasterSocialMedium.ViewFromClient().ToList();
            obj.ListTrainers = MasterTrainers.ViewFromClient().ToList();
            obj.ListUsefullLinks = MasterUsefullLinks.ViewFromClient().ToList();
            obj.Setting = SystemSetting.Find(1);
            return View(obj);
        }

        public IActionResult Events()
        {
            HomeViewModel obj = new HomeViewModel();
            obj.AboutUs = MasterAboutUs.Find(1);
            obj.ListEvents = MasterEvents.ViewFromClient().ToList();
            obj.ListMenu = MasterMenu.ViewFromClient().ToList();
            obj.ListOurServices = MasterOurServices.ViewFromClient().ToList();
            obj.ListSocialMedium = MasterSocialMedium.ViewFromClient().ToList();
            obj.ListUsefullLinks = MasterUsefullLinks.ViewFromClient().ToList();
            obj.Setting = SystemSetting.Find(1);
            return View(obj);
        }

        public IActionResult Pricing()
        {
            HomeViewModel obj = new HomeViewModel();
            obj.AboutUs = MasterAboutUs.Find(1);
            obj.ListMenu = MasterMenu.ViewFromClient().ToList();
            obj.ListOurServices = MasterOurServices.ViewFromClient().ToList();
            obj.ListPricing = MasterPricing.ViewFromClient().ToList();
            obj.ListSocialMedium = MasterSocialMedium.ViewFromClient().ToList();
            obj.ListUsefullLinks = MasterUsefullLinks.ViewFromClient().ToList();
            obj.Setting = SystemSetting.Find(1);
            return View(obj);
        }

        public IActionResult Contact()
        {
            HomeViewModel obj = new HomeViewModel();
            obj.AboutUs = MasterAboutUs.Find(1);
            obj.ContactUsInformation1 = MasterContactUsInformation.Find(2);
            obj.ContactUsInformation2 = MasterContactUsInformation.Find(3);
            obj.ContactUsInformation3 = MasterContactUsInformation.Find(4);
            obj.ListMenu = MasterMenu.ViewFromClient().ToList();
            obj.ListOurServices = MasterOurServices.ViewFromClient().ToList();
            obj.ListSocialMedium = MasterSocialMedium.ViewFromClient().ToList();
            obj.ListUsefullLinks = MasterUsefullLinks.ViewFromClient().ToList();
            obj.Setting = SystemSetting.Find(1);
            return View(obj);
        }

        [HttpPost]
        public IActionResult ContactUs(HomeViewModel data)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.message = "Failed";
                return RedirectToAction("ContactUs", "Home");
            }

            TransactionContactUs.Add(data.ContactUs);
            return RedirectToAction("Contact", "Home");
        }

        [HttpPost]
        public IActionResult NewsLetter(HomeViewModel data)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.message = "Failed";
                return RedirectToAction("Index", "Home");
            }

            TransactionNewsLetter.Add(data.NewsLetter);
            return RedirectToAction("Index", "Home");
        }
    }
}
