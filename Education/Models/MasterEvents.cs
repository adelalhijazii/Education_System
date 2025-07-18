using System.ComponentModel.DataAnnotations;

namespace Education.Models
{
    public class MasterEvents : BaseEntity
    {
        public int MasterEventsId { get; set; }

        [DataType(DataType.Text)]
        public string MasterEventsTitle { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime MasterEventsDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterEventsDescription { get; set; }

        [DataType(DataType.ImageUrl)]
        public string MasterEventsImageUrl { get; set; }
    }
}
