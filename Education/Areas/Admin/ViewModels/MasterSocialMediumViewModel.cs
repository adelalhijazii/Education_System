using Education.Models;
using System.ComponentModel.DataAnnotations;

namespace Education.Areas.Admin.ViewModels
{
    public class MasterSocialMediumViewModel : BaseEntity
    {
        public int MasterSocialMediumId { get; set; }

        public string MasterSocialMediumIcon { get; set; }

        [DataType(DataType.Url)]
        public string MasterSocialMediumUrl { get; set; }
    }
}
