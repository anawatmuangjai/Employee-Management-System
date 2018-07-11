using EMS.WinForm.Presenters;

namespace EMS.WinForm.Views.Interfaces
{
    public interface ILoginView
    {
        string Username { get; set; }
        string Password { get; set; }
        string Message { get; set; }
        LoginPresenter Presenter { set; }
        void ShowView();
        void ShowMainView();
    }
}
