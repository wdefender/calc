using calc.Common.Infrastructure.Enums;
using calc.Common.Infrastructure.Interfaces;
using calc.Common.Infrastructure.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace calc.UI.Keys.ViewModels
{
    public class KeysViewModel : BindableBase
    {
        private readonly IInputService inputService;
        
        public ObservableCollection<Key> Keys { get; } = new ObservableCollection<Key>();

        public DelegateCommand<Key> RegisterKeyCommand => new DelegateCommand<Key>(_ => inputService.RegisterInput(_));
        
        public KeysViewModel(IInputService inputService)
        {
            this.inputService = inputService;
            InitKeys();
        }

        private void InitKeys()
        {
            Keys.Add(new Key(KeyType.NumericKey, "7"));
            Keys.Add(new Key(KeyType.NumericKey, "8"));
            Keys.Add(new Key(KeyType.NumericKey, "9"));
            Keys.Add(new Key(KeyType.OperatorKey, "/"));
            Keys.Add(new Key(KeyType.OperatorKey, "sqrt"));
            Keys.Add(new Key(KeyType.NumericKey, "4"));
            Keys.Add(new Key(KeyType.NumericKey, "5"));
            Keys.Add(new Key(KeyType.NumericKey, "6"));
            Keys.Add(new Key(KeyType.OperatorKey, "*"));
            Keys.Add(new Key(KeyType.OperatorKey, "%"));
            Keys.Add(new Key(KeyType.NumericKey, "1"));
            Keys.Add(new Key(KeyType.NumericKey, "2"));
            Keys.Add(new Key(KeyType.NumericKey, "3"));
            Keys.Add(new Key(KeyType.OperatorKey, "-"));
            Keys.Add(new Key(KeyType.OperatorKey, "1/x"));
            Keys.Add(new Key(KeyType.NumericKey, "0"));
            Keys.Add(new Key(KeyType.OperatorKey, "+/-"));
            Keys.Add(new Key(KeyType.NumericKey, ","));
            Keys.Add(new Key(KeyType.OperatorKey, "+"));
            Keys.Add(new Key(KeyType.OperatorKey, "="));
        }
    }
}
