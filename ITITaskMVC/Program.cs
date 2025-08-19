using ITITaskMVC.BLL.Services.CourseServices;
using ITITaskMVC.BLL.Services.InstructorService;
using ITITaskMVC.Configurations;
using ITITaskMVC.DAL.Data;
using ITITaskMVC.DAL.Repositories.CourseRepository;
using ITITaskMVC.DAL.Repositories.InstructorRepository;
using ITITaskMVC.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace ITITaskMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("constr"))
                );

            builder.Services.AddScoped<ICourseRepo, CourseRepo>();
			builder.Services.AddScoped<IcourseService, CourseService>();

			builder.Services.AddScoped<IInstructorRepo, InstructorRepo>();
			builder.Services.AddScoped<IInstructorService, InstructorService>();

            builder.Services.Configure<CourseSettings>(builder.Configuration.GetSection(nameof(CourseSettings)));

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

			//app.UseCategoryLogging();


			app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
