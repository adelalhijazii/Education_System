using Education.Models;

namespace Education.ViewModels
{
    public class HomeViewModel
    {
        public MasterAboutUs AboutUs { get; set; }

        public MasterContactUsInformation ContactUsInformation1 { get; set; }

        public MasterContactUsInformation ContactUsInformation2 { get; set; }

        public MasterContactUsInformation ContactUsInformation3 { get; set; }

        public IList<MasterCourses> ListCourses { get; set; }

        public MasterCourses Courses { get; set; }

        public IList<MasterEvents> ListEvents { get; set; }

        public IList<MasterFeatures> ListFeatures { get; set; }

        public IList<MasterMenu> ListMenu { get; set; }

        public IList<MasterOurServices> ListOurServices { get; set; }

        public IList<MasterPricing> ListPricing { get; set; }

        public MasterSlider Slider { get; set; }

        public IList<MasterSocialMedium> ListSocialMedium { get; set; }

        public IList<MasterTrainers> ListTrainers { get; set; }

        public MasterTrainers Trainers { get; set; }

        public IList<MasterUsefullLinks> ListUsefullLinks { get; set; }

        public IList<MasterWhatPeopleSay> ListWhatPeopleSay { get; set; }

        public IList<MasterWhyChoose> ListWhyChoose { get; set; }

        public SystemSetting Setting { get; set; }

        public TransactionContactUs ContactUs { get; set; }

        public TransactionNewsLetter NewsLetter { get; set; }
    }
}
