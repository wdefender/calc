using System.Windows;
using System.Windows.Input;

namespace calc.DesktopClient.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.InputBindings.Add(new KeyBinding(() => Messagbox.Show(""),
            // new KeyGesture(Key.O, ModifierKeys.Control)));
        }
    }
}
