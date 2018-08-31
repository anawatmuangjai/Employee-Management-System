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
                    option.LoginPath = "/Account/Login";
                });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IEmployeePasswordService, EmployeePasswordService>();
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
            services.AddScoped<IBusStationService, BusStationService>();
            services.AddScoped<IAttendanceService, AttendanceService>();

            services.AddScoped<IEmployeeRegisterService, EmployeeRegisterService>();
            services.AddScoped<IEmployeeDetailService, EmployeeDetailService>();

            services.AddScoped<IEmployeeViewModelService, EmployeeViewModelService>();
            services.AddScoped<IProfileViewModelService, ProfileViewModelService>();
            services.AddScoped<IAttendanceViewModelService, AttendanceViewModelService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
        }
    }
}
