using Education.Models;
using System.ComponentModel.DataAnnotations;

namespace Education.Areas.Admin.ViewModels
{
    public class MasterContactUsInformationViewModel : BaseEntity
    {
        public int MasterContactUsInformationId { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterContactUsInformationDescription { get; set; }

        public string MasterContactUsInformationIcon { get; set; }
    }
}
