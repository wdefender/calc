using calc.Common.Infrastructure.Interfaces;
using calc.Common.Infrastructure.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;

namespace calc.UI.Keys.ViewModels
{
    public class KeysViewModel : BindableBase
    {
        private readonly IInputService inputService;
        
        public IList<Key> Keys { get; } 

        public DelegateCommand<Key> RegisterKeyCommand => new DelegateCommand<Key>(_ => inputService.RegisterInput(_));
        
        public KeysViewModel(IKeyService keyService, IInputService inputService)
        {
            this.inputService = inputService;
            Keys = new List<Key>(keyService.GetKeys());
        }
    }
}
