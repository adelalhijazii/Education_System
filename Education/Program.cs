using Education.Models.Repository;
using Education.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(services => services.EnableEndpointRouting = false);
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddDbContext<AppDbContext>(DbContext =>
{
    DbContext.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
});


builder.Services.AddScoped<IRepository<MasterAboutUs>, MasterAboutUsRepository>();
builder.Services.AddScoped<IRepository<MasterContactUsInformation>, MasterContactUsInformationRepository>();
builder.Services.AddScoped<IRepository<MasterCourses>, MasterCoursesRepository>();
builder.Services.AddScoped<IRepository<MasterEvents>, MasterEventsRepository>();
builder.Services.AddScoped<IRepository<MasterFeatures>, MasterFeaturesRepository>();
builder.Services.AddScoped<IRepository<MasterMenu>, MasterMenuRepository>();
builder.Services.AddScoped<IRepository<MasterOurServices>, MasterOurServicesRepository>();
builder.Services.AddScoped<IRepository<MasterPricing>, MasterPricingRepository>();
builder.Services.AddScoped<IRepository<MasterSlider>, MasterSliderRepository>();
builder.Services.AddScoped<IRepository<MasterSocialMedium>, MasterSocialMediumRepository>();
builder.Services.AddScoped<IRepository<MasterTrainers>, MasterTrainersRepository>();
builder.Services.AddScoped<IRepository<MasterUsefullLinks>, MasterUsefullLinksRepository>();
builder.Services.AddScoped<IRepository<MasterWhatPeopleSay>, MasterWhatPeopleSayRepository>();
builder.Services.AddScoped<IRepository<MasterWhyChoose>, MasterWhyChooseRepository>();
builder.Services.AddScoped<IRepository<SystemSetting>, SystemSettingRepository>();
builder.Services.AddScoped<IRepository<TransactionContactUs>, TransactionContactUsRepository>();
builder.Services.AddScoped<IRepository<TransactionNewsLetter>, TransactionNewsLetterRepository>();

builder.Services.Configure<IdentityOptions>(x => {
    x.Password.RequireDigit = false;
    x.Password.RequiredLength = 3;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireLowercase = false;
    x.Password.RequireUppercase = false;
    //x.Password.RequiredUniqueChars = 0;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Admin/Account/Signin";
});

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(app =>
{
    app.MapControllerRoute(
                        name: "areas",
                        pattern: "{area:exists}/{controller=Account}/{action=Signin}/{id?}"
                        );

    app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
            );
});
app.Run();
