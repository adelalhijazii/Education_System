using System.ComponentModel.DataAnnotations;

namespace Education.Models
{
    public class MasterCourses : BaseEntity
    {
        public int MasterCoursesId { get; set; }

        [DataType(DataType.Text)]
        public string MasterCoursesTitle { get; set; }

        public int MasterCoursesPrice { get; set; }

        [DataType(DataType.Text)]
        public string MasterCoursesBreef { get; set; }

        [DataType(DataType.MultilineText)]
        public string MasterCoursesDescription { get; set; }

        [DataType(DataType.ImageUrl)]
        public string MasterCoursesImageUrl { get; set; }

        public string MasterCoursesUrl { get; set; }
    }
}
