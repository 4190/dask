using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Dask.Data;
using Dask.Data.EfCore;
using Dask.Models;
using Dask.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.IO;

namespace Dask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public Dictionary<string, string> configDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("startupConfig.json"));

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            //  services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //      .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            //      services.AddAutoMapper(typeof(Startup));
            services.AddScoped<EfCoreSurveysRepository>();
            services.AddScoped<IManageSurveysService, ManageSurveysService>();


            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = Convert.ToBoolean(configDictionary["passwordRequireDigit"]);
                options.Password.RequireLowercase = Convert.ToBoolean(configDictionary["passwordRequireLowercase"]);
                options.Password.RequireNonAlphanumeric = Convert.ToBoolean(configDictionary["passwordRequireNonAlphanumeric"]);
                options.Password.RequireUppercase = Convert.ToBoolean(configDictionary["passwordRequireUppercase"]);
                options.Password.RequiredLength = int.Parse(configDictionary["passwordRequiredLength"]);
                options.Password.RequiredUniqueChars = int.Parse(configDictionary["passwordRequiredUniqueChars"]);

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(Convert.ToDouble(configDictionary["defaultLockoutTimeSpan"]));
                options.Lockout.MaxFailedAccessAttempts = int.Parse(configDictionary["maxFailedAccessAttempts"]);
                options.Lockout.AllowedForNewUsers = Convert.ToBoolean(configDictionary["lockoutAllowedForNewUsers"]);

                // User settings.
                options.User.AllowedUserNameCharacters = configDictionary["allowedUserNameCharacters"];
                options.User.RequireUniqueEmail = Convert.ToBoolean(configDictionary["requireUniqueEmail"]);
            });
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
            CreateRoles(services).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            var userRoleCheck = await RoleManager.RoleExistsAsync("User");
            if (!roleCheck)
            {
                //here in this line we are creating admin role and seed it to the database
                 await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!userRoleCheck)
            {
                await RoleManager.CreateAsync(new IdentityRole("User"));

            }

            await CreateAdminAccountIfDoesntExist(serviceProvider);


        }

        private async Task CreateAdminAccountIfDoesntExist(IServiceProvider serviceProvider)
        {
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();


            if (await UserManager.FindByNameAsync(configDictionary["adminUserName"]) != null)
            {
                ApplicationUser user = await UserManager.FindByNameAsync(configDictionary["adminUserName"]);
                await UserManager.AddToRoleAsync(user, configDictionary["adminRoleName"]);
            }
            else
            {
                ApplicationUser adminUser = new ApplicationUser()
                {
                    UserName = configDictionary["adminUserName"],
                    Email = configDictionary["adminUserEmail"]
                };
                await UserManager.CreateAsync(adminUser, configDictionary["adminPassword"]);
                await UserManager.AddToRoleAsync(adminUser, configDictionary["adminRoleName"]);
            }
        }
    }
}
