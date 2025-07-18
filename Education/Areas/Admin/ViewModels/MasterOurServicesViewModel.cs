using Education.Models;
using System.ComponentModel.DataAnnotations;

namespace Education.Areas.Admin.ViewModels
{
    public class MasterOurServicesViewModel : BaseEntity
    {
        public int MasterOurServicesId { get; set; }

        [DataType(DataType.Text)]
        public string MasterOurServicesName { get; set; }

        public string MasterOurServicesUrl { get; set; }
    }
}
