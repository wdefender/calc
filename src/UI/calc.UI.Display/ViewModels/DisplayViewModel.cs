using calc.Common.Infrastructure.Interfaces;
using Prism.Mvvm;
using System.Collections.Generic;

namespace calc.UI.Display.ViewModels
{
    public class DisplayViewModel : BindableBase
    {
        public IOutputService OutputService { get; }
     
        public DisplayViewModel(IOutputService outputServce)
        {
            OutputService = outputServce;

            foreach (System.Drawing.FontFamily font in System.Drawing.FontFamily.Families)
            {
                Fonts.Add(font.Name);
            }
        }

        public List<string> Fonts { get; }  = new List<string>();


}
}
