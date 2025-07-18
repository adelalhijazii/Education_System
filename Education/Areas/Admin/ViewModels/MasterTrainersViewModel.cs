using Education.Models;
using System.ComponentModel.DataAnnotations;

namespace Education.Areas.Admin.ViewModels
{
    public class MasterTrainersViewModel : BaseEntity
    {
        public int MasterTrainersId { get; set; }

        [DataType(DataType.Text)]
        public string MasterTrainersTitle { get; set; }

        [DataType(DataType.Text)]
        public string MasterTrainersBreef { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterTrainersDescription { get; set; }

        public string MasterTrainersIcon { get; set; }

        [DataType(DataType.Url)]
        public string MasterTrainersIconUrl { get; set; }

        [DataType(DataType.ImageUrl)]
        public string MasterTrainersImageUrl { get; set; }

        public IFormFile MasterTrainersFile { get; set; }
    }
}
