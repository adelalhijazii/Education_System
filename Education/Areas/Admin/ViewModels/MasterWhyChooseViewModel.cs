using Education.Models;
using System.ComponentModel.DataAnnotations;

namespace Education.Areas.Admin.ViewModels
{
    public class MasterWhyChooseViewModel : BaseEntity
    {
        public int MasterWhyChooseId { get; set; }

        public string MasterWhyChooseIcon { get; set; }

        [DataType(DataType.Text)]
        public string MasterWhyChooseTitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterWhyChooseDescription { get; set; }
    }
}
