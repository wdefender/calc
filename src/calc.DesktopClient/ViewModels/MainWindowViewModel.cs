using Prism.Mvvm;

namespace calc.DesktopClient.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Calcualtor ";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
