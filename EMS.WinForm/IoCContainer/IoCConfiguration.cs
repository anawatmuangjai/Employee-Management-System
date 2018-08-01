using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Services;
using EMS.Domain.Entities;
using EMS.Persistance.Context;
using EMS.Persistance.Repositories;
using EMS.WinForm.Presenters;
using EMS.WinForm.Presenters.Interfaces;
using EMS.WinForm.Views;
using EMS.WinForm.Views.Interfaces;
using EMS.WinForm.Views.UserControls;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.IoCContainer
{
    public class IoCConfiguration : NinjectModule
    {
        public override void Load()
        {
            //Bind<EmployeeContext>().ToSelf()
            //    .InSingletonScope()
            //    .WithConstructorArgument("EmployeeConnection",
            //    ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString);

            Bind<EmployeeContext>().ToSelf().InSingletonScope();
            Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InSingletonScope();
            Bind(typeof(IAsyncRepository<>)).To(typeof(Repository<>)).InSingletonScope();
            Bind<IEmployeeRepository>().To<EmployeeRepository>().InSingletonScope();

            Bind<IDepartmentService>().To<DepartmentService>().InSingletonScope();
            Bind<ISectionService>().To<SectionService>().InSingletonScope();
            Bind<IShiftService>().To<ShiftService>().InSingletonScope();
            Bind<IJobService>().To<JobService>().InSingletonScope();
            Bind<IJobFunctionService>().To<JobFunctionService>().InSingletonScope();
            Bind<IEmployeeService>().To<EmployeeService>().InSingletonScope();
            Bind<IEmployeeAddressService>().To<EmployeeAddressService>().InSingletonScope();
            Bind<IEmployeeStateService>().To<EmployeeStateService>().InSingletonScope();
            Bind<IEmployeePasswordService>().To<EmployeePasswordService>().InSingletonScope();
            Bind<IEmployeeImageService>().To<EmployeeImageService>().InSingletonScope();
            Bind<IEmployeeLevelService>().To<EmployeeLevelService>().InSingletonScope();
            Bind<IEmployeeListService>().To<EmployeeListService>().InSingletonScope();
            Bind<IBusStationService>().To<BusStationService>().InSingletonScope();
            Bind<IEducationDegreeService>().To<EducationDegreeService>().InSingletonScope();
            Bind<IEducationMajorService>().To<EducationMajorService>().InSingletonScope();


            Bind<ILoginView>().To<LoginView>().InSingletonScope();
            Bind<IMainView>().To<MainView>().InSingletonScope();
            Bind<IEmployeeView>().To<RegistrationView>().InSingletonScope();
            Bind<IDepartmentView>().To<DepartmentView>().InSingletonScope();
            Bind<ISectionView>().To<SectionView>().InSingletonScope();
            Bind<IShiftView>().To<ShiftView>().InSingletonScope();
            Bind<IJobTitleView>().To<JobTitleView>().InSingletonScope();
            Bind<IJobFunctionView>().To<JobFunctionView>().InSingletonScope();
            Bind<IEmployeeLevelView>().To<EmployeeLevelView>().InSingletonScope();
            Bind<IEmployeeListView>().To<EmployeeListView>().InSingletonScope();
            Bind<IBusStationView>().To<BusStationView>().InSingletonScope();
            Bind<IEducationDegreeView>().To<EducationDegreeView>().InSingletonScope();
            Bind<IEducationMajorView>().To<EducationMajorView>().InSingletonScope();

            Bind<ILoginPresenter>().To<LoginPresenter>().InSingletonScope();
            Bind<IMainPresenter>().To<MainPresenter>().InSingletonScope();
            Bind<IEmployeePresenter>().To<EmployeePresenter>().InSingletonScope();
            Bind<IDepartmentPresenter>().To<DepartmentPresenter>().InSingletonScope();
            Bind<ISectionPresenter>().To<SectionPresenter>().InSingletonScope();
            Bind<IShiftPresenter>().To<ShiftPresenter>().InSingletonScope();
            Bind<IJobTitlePresenter>().To<JobTitlePresenter>().InSingletonScope();
            Bind<IJobFunctionPresenter>().To<JobFunctionPresenter>().InSingletonScope();
            Bind<IEmployeeLevelPresenter>().To<EmployeeLevelPresenter>().InSingletonScope();
            Bind<IEmployeeListPresenter>().To<EmployeeListPresenter>().InSingletonScope();
            Bind<IBusStationPresenter>().To<BusStationPresenter>().InSingletonScope();

            Bind<EducationDegreePresenter>().ToSelf().InTransientScope();
            Bind<EducationMajorPresenter>().ToSelf().InTransientScope();
        }
    }
}
