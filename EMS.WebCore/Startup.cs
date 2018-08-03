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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IEmployeePasswordService, EmployeePasswordService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IJobFunctionService, JobFunctionService>();
            services.AddScoped<IShiftService, ShiftService>();
            services.AddScoped<IEmployeeLevelService, EmployeeLevelService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeListService, EmployeeListService>();
            services.AddScoped<IBusStationService, BusStationService>();

            services.AddScoped<IEmployeeRegisterService, EmployeeRegisterService>();

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
