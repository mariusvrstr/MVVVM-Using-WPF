using System.Windows;
using MVVMExample.ViewModels;

// View Modal namespace

namespace MVVMExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new StudentData();
        }
    }
}
