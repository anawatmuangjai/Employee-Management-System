using EMS.Core.Interfaces;
using EMS.Infrastructure.Repository;
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
            Bind<IEmployeeRepository>().To<EmployeeRepository>().InSingletonScope();

            Bind<ILoginView>().To<LoginView>().InSingletonScope();
            Bind<IMainView>().To<MainView>().InSingletonScope();
            Bind<IRegistrationView>().To<RegistrationView>().InSingletonScope();
            Bind<IDepartmentView>().To<DepartmentView>().InSingletonScope();
            Bind<ISectionView>().To<SectionView>().InSingletonScope();
            Bind<IShiftView>().To<ShiftView>().InSingletonScope();
            Bind<IJobTitleView>().To<JobTitleView>().InSingletonScope();
            Bind<IJobFunctionView>().To<JobFunctionView>().InSingletonScope();
            
            Bind<ILoginPresenter>().To<LoginPresenter>().InSingletonScope();
            Bind<IMainPresenter>().To<MainPresenter>().InSingletonScope();
            Bind<IRegistrationPresenter>().To<RegistrationPresenter>().InSingletonScope();
            Bind<IDepartmentPresenter>().To<DepartmentPresenter>().InSingletonScope();
            Bind<ISectionPresenter>().To<SectionPresenter>().InSingletonScope();
            Bind<IShiftPresenter>().To<ShiftPresenter>().InSingletonScope();
            Bind<IJobTitlePresenter>().To<JobTitlePresenter>().InSingletonScope();
            Bind<IJobFunctionPresenter>().To<JobFunctionPresenter>().InSingletonScope();
        }
    }
}
