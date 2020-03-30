using calc.Common.Infrastructure.Interfaces;
using Prism.Mvvm;

namespace calc.UI.Display.ViewModels
{
    public class DisplayViewModel : BindableBase
    {
        public IOutputService OutputService { get; }
     
        public DisplayViewModel(IOutputService outputServce)
        {
            OutputService = outputServce;
        }
    }
}
