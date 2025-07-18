using System.ComponentModel.DataAnnotations;

namespace Education.Models
{
    public class MasterContactUsInformation : BaseEntity
    {
        public int MasterContactUsInformationId { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterContactUsInformationDescription { get; set; }

        public string MasterContactUsInformationIcon { get; set; }
    }
}
