using System.ComponentModel.DataAnnotations;

namespace Education.Models
{
    public class MasterWhyChoose : BaseEntity
    {
        public int MasterWhyChooseId { get; set; }

        public string MasterWhyChooseIcon { get; set; }

        [DataType(DataType.Text)]
        public string MasterWhyChooseTitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterWhyChooseDescription { get; set; }
    }
}
