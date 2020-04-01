using calc.Common.Infrastructure.Enums;
using calc.Common.Infrastructure.Interfaces;
using calc.Common.Infrastructure.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace calc.UI.Toolbar.ViewModels
{
    public class ToolbarViewModel : BindableBase
    {
        private readonly IInputService inputService;

        public DelegateCommand ClearCommand => new DelegateCommand(() => inputService.RegisterInput(new Key(KeyType.MemoryKey, "C")));
        public ToolbarViewModel(IInputService inputService)
        {
            this.inputService = inputService;
        }
    }
}
