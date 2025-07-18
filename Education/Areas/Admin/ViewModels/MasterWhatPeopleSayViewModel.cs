using Education.Models;
using System.ComponentModel.DataAnnotations;

namespace Education.Areas.Admin.ViewModels
{
    public class MasterWhatPeopleSayViewModel : BaseEntity
    {
        public int MasterWhatPeopleSayId { get; set; }

        [DataType(DataType.Text)]
        public string MasterWhatPeopleSayTitle { get; set; }

        [DataType(DataType.Text)]
        public string MasterWhatPeopleSayBreef { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterWhatPeopleSayDescription { get; set; }

        [DataType(DataType.ImageUrl)]
        public string MasterWhatPeopleSayImagesUrl { get; set; }

        public IFormFile MasterWhatPeopleSayFile { get; set; }
    }
}
