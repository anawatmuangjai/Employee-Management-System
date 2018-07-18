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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.IoCContainer
{
    public class IoCConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<EmployeeContext>().ToSelf().InSingletonScope();
            Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InSingletonScope();
            Bind(typeof(IAsyncRepository<>)).To(typeof(Repository<>)).InSingletonScope();

            Bind<IDepartmentService>().To<DepartmentService>().InSingletonScope();
            Bind<ISectionService>().To<SectionService>().InSingletonScope();
            Bind<IShiftService>().To<ShiftService>().InSingletonScope();
            Bind<IJobService>().To<JobService>().InSingletonScope();
            Bind<IEmployeeService>().To<EmployeeService>().InSingletonScope();
            Bind<IEmployeeDetailService>().To<EmployeeDetailService>().InSingletonScope();
            Bind<IEmployeeStateService>().To<EmployeeStateService>().InSingletonScope();
            Bind<IEmployeeLevelService>().To<EmployeeLevelService>().InSingletonScope();

            Bind<ILoginView>().To<LoginView>().InSingletonScope();
            Bind<IMainView>().To<MainView>().InSingletonScope();
            Bind<IEmployeeView>().To<RegistrationView>().InSingletonScope();
            Bind<IDepartmentView>().To<DepartmentView>().InSingletonScope();
            Bind<ISectionView>().To<SectionView>().InSingletonScope();
            Bind<IShiftView>().To<ShiftView>().InSingletonScope();
            Bind<IJobTitleView>().To<JobTitleView>().InSingletonScope();
            Bind<IJobFunctionView>().To<JobFunctionView>().InSingletonScope();
            Bind<IEmployeeLevelView>().To<EmployeeLevelView>().InSingletonScope();

            Bind<ILoginPresenter>().To<LoginPresenter>().InSingletonScope();
            Bind<IMainPresenter>().To<MainPresenter>().InSingletonScope();
            Bind<IEmployeePresenter>().To<EmployeePresenter>().InSingletonScope();
            Bind<IDepartmentPresenter>().To<DepartmentPresenter>().InSingletonScope();
            Bind<ISectionPresenter>().To<SectionPresenter>().InSingletonScope();
            Bind<IShiftPresenter>().To<ShiftPresenter>().InSingletonScope();
            Bind<IJobTitlePresenter>().To<JobTitlePresenter>().InSingletonScope();
            Bind<IJobFunctionPresenter>().To<JobFunctionPresenter>().InSingletonScope();
            Bind<IEmployeeLevelPresenter>().To<EmployeeLevelPresenter>().InSingletonScope();
        }
    }
}
