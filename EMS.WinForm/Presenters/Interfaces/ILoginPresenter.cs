using EMS.WinForm.Views.Interfaces;

namespace EMS.WinForm.Presenters.Interfaces
{
    public interface ILoginPresenter
    {
        ILoginView GetView();
        void ShowView();
        void Login();
    }
}
