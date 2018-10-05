using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Services;
using EMS.Persistance.Context;
using EMS.Persistance.Repositories;
using EMS.WebCore.Interfaces;
using EMS.WebCore.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.WebCore
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
            services.AddDbContext<EmployeeContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("EmployeeConnection")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = new PathString("/Account/Login");
                    option.AccessDeniedPath = new PathString("/Account/AccessDenied");
                });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAuthorityService, AuthorityService>();
            services.AddScoped<IAccountAuthorityService, AccountAuthorityService>();

            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<IJobPositionService, JobPositiobService>();
            services.AddScoped<IJobFunctionService, JobFunctionService>();
            services.AddScoped<IShiftService, ShiftService>();
            services.AddScoped<IEmployeeLevelService, EmployeeLevelService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeListService, EmployeeListService>();
            services.AddScoped<IEmployeeStateService, EmployeeStateService>();
            services.AddScoped<IEmployeeAddressService, EmployeeAddressService>();
            services.AddScoped<IEmployeeImageService, EmployeeImageService>();
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<IBusStationService, BusStationService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ISkillGroupService, SkillGroupService>();
            services.AddScoped<ISkillTypeService, SkillTypeService>();

            services.AddScoped<IAuthenService, AuthenService>();
            services.AddScoped<IEmployeeDetailService, EmployeeDetailService>();
            services.AddScoped<IEducationDegreeService, EducationDegreeService>();
            services.AddScoped<IEducationMajorService, EducationMajorService>();

            services.AddScoped<IEmployeeViewModelService, EmployeeViewModelService>();
            services.AddScoped<IProfileViewModelService, ProfileViewModelService>();
            services.AddScoped<IAttendanceViewModelService, AttendanceViewModelService>();
            services.AddScoped<IDashboardViewModelService, DashboardViewModelService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            CreateDefaultUserAndRoles(services).Wait();
        }

        private async Task CreateDefaultUserAndRoles(IServiceProvider serviceProvider)
        {
            var authService = serviceProvider.GetRequiredService<IAuthenService>();

            var username = "administrator";
            var password = "admin-1234";
            string[] roleNames = { "Administrator", "Member" };

            // Create role and seeding them to database
            foreach (var roleName in roleNames)
            {
                var roleExists = await authService.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    await authService.CreateRoleAsync(roleName);
                }
            }

            // Create a super user who could maintain application
            var accountExists = await authService.AccountExistsAsync(username);
            if (!accountExists)
            {
                // Create admin account
                var account = await authService.CreateAccountAsync(username, password);

                // Assign role to admin account
                await authService.AddUserRoleAsync(account, "Administrator");
            }
        }
    }
}
