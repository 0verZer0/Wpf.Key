using System.Windows;

namespace Zer0Key
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                var desktopWorkingArea = SystemParameters.WorkArea;
                Left = 10;
                Top = desktopWorkingArea.Bottom - ActualHeight - 50;
            };
        }
    }
}
