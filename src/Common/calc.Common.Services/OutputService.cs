using calc.Common.Infrastructure.Interfaces;
using Prism.Mvvm;

namespace calc.Common.Services
{
    public class OutputService : BindableBase, IOutputService
    {
        private string _displayValue;
        public string DisplayValue
        {
            get => _displayValue;
            set => SetProperty(ref _displayValue, value);
        }

        public void SendOutput(string obj)
        {
            DisplayValue = string.IsNullOrEmpty(obj) ? "" : obj;
        }
    }
}
