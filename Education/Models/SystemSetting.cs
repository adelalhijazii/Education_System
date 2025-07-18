using System.ComponentModel.DataAnnotations;

namespace Education.Models
{
    public class SystemSetting : BaseEntity
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
    }
}
