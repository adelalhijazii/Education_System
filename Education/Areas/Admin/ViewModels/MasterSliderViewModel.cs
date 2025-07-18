using Education.Models;
using System.ComponentModel.DataAnnotations;

namespace Education.Areas.Admin.ViewModels
{
    public class MasterSliderViewModel : BaseEntity
    {
        public int MasterSliderId { get; set; }

        [DataType(DataType.Text)]
        public string MasterSliderTitle { get; set; }

        [DataType(DataType.Text)]
        public string MasterSliderBreef { get; set; }

        public string MasterSliderUrl { get; set; }

        [DataType(DataType.ImageUrl)]
        public string MasterSliderImageUrl { get; set; }

        public IFormFile MasterSliderFile { get; set; }
    }
}
