using Education.Models;
using System.ComponentModel.DataAnnotations;

namespace Education.Areas.Admin.ViewModels
{
    public class MasterUsefullLinksViewModel : BaseEntity
    {
        public int MasterUsefullLinksId { get; set; }

        [DataType(DataType.Text)]
        public string MasterUsefullLinksName { get; set; }

        public string MasterUsefullLinksUrl { get; set; }
    }
}
