using calc.Common.Infrastructure.Interfaces;
using Prism.Mvvm;
using System;

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
            DisplayValue = string.Concat(_displayValue, obj);
        }
    }
}
