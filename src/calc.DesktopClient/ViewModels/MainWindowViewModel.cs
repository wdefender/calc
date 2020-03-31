using calc.Common.Infrastructure.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;

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

        private readonly IInputService inputService;
        private readonly IKeyService keyService;

        public DelegateCommand<string> KeyCommand => new DelegateCommand<string>((_) => inputService.RegisterInput(keyService.GetKeyFromValue(_))); 

        public MainWindowViewModel(IKeyService keyService, IInputService inputService)
        {
            this.keyService = keyService;
            this.inputService = inputService;
        }
    }
}
