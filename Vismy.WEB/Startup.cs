using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Vismy.Application.Interfaces;
using Vismy.Application.Services;
using Vismy.Core.Interfaces;
using Vismy.Core.Models.Implementations;
using Vismy.Core.Models.Joins;
using Vismy.Core.Models.Statuses;
using Vismy.Infrastructure.Context;
using Vismy.Infrastructure.Repositories;

namespace Vismy.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureApplicationCookie(p =>
            {
                p.LoginPath = "/Account/Login";
            });

            services.AddControllersWithViews();
            services.AddAutoMapper(Assembly.Load("Vismy.WEB"), Assembly.Load("Vismy.Infrastructure"));

            services.AddDbContext<VismyContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    a => a.MigrationsAssembly("Vismy.Infrastructure"));
            });
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<AspNetUser, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<VismyContext>();

            services.AddRazorPages();


            //services.AddTransient<UserManager<AspNetUser>>();
            //services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRepository<Post>, Repository<Post>>();
            services.AddScoped<IRepository<Tag>, Repository<Tag>>();
            services.AddScoped<IRepository<PostTag>, Repository<PostTag>>();
            services.AddScoped<IRepository<PostStatus>, Repository<PostStatus>>();
            services.AddScoped<IRepository<Report>, Repository<Report>>();
            services.AddScoped<IRepository<AspNetUser>, Repository<AspNetUser>> ();
            services.AddScoped<IRepository<UserUser>, Repository<UserUser>>();
            services.AddScoped<IRepository<UserPost>, Repository<UserPost>>();
            services.AddScoped<IRepository<UserPostStatus>, Repository<UserPostStatus>>();
            services.AddScoped<IRepository<UserReportAuthor>, Repository<UserReportAuthor>>();
            services.AddScoped<UserManager<AspNetUser>>();
            services.AddScoped<SignInManager<AspNetUser>>();
            services.AddScoped<RoleManager<IdentityRole>>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
