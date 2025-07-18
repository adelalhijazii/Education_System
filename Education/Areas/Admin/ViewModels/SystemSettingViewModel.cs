using Education.Models;
using System.ComponentModel.DataAnnotations;

namespace Education.Areas.Admin.ViewModels
{
    public class SystemSettingViewModel : BaseEntity
    {
        public int SystemSettingId { get; set; }

        public string SystemSettingLogoImageUrl { get; set; }

        [DataType(DataType.Text)]
        public string SystemSettingWelcomeNoteTitle { get; set; }

        [DataType(DataType.Text)]
        public string SystemSettingWelcomeNoteBreef { get; set; }

        [DataType(DataType.MultilineText)]
        public string SystemSettingWelcomeNoteDescription { get; set; }

        [DataType(DataType.ImageUrl)]
        public string SystemSettingWelcomeNoteImageUrl { get; set; }

        public string SystemSettingCopyright { get; set; }

        public IFormFile SystemSettingFile1 { get; set; }

        public IFormFile SystemSettingFile2 { get; set; }
    }
}
