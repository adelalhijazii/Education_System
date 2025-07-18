using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Education.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<MasterAboutUs> MasterAboutUs { get; set; }

        public DbSet<MasterContactUsInformation> MasterContactUsInformation { get; set; }

        public DbSet<MasterCourses> MasterCourses { get; set; }

        public DbSet<MasterEvents> MasterEvents { get; set; }

        public DbSet<MasterFeatures> MasterFeatures { get; set; }

        public DbSet<MasterMenu> MasterMenu { get; set; }

        public DbSet<MasterOurServices> MasterOurServices { get; set; }

        public DbSet<MasterPricing> MasterPricing { get; set; }

        public DbSet<MasterSlider> MasterSlider { get; set; }

        public DbSet<MasterSocialMedium> MasterSocialMedium { get; set; }

        public DbSet<MasterTrainers> MasterTrainers { get; set; }

        public DbSet<MasterUsefullLinks> MasterUsefullLinks { get; set; }

        public DbSet<MasterWhatPeopleSay> MasterWhatPeopleSay { get; set; }

        public DbSet<MasterWhyChoose> MasterWhyChoose { get; set; }

        public DbSet<SystemSetting> SystemSetting { get; set; }

        public DbSet<TransactionContactUs> TransactionContactUs { get; set; }

        public DbSet<TransactionNewsLetter> TransactionNewsLetter { get; set; }
    }
}
