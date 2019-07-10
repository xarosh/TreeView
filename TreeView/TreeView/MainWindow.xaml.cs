using System.Windows;
using TreeView.ViewModels;
namespace TreeView
{

    public partial class MainWindow : Window
    {
        public MainWindow(string title, ViewModel viewModel)
        {
            Title = title;
            DataContext = viewModel;
            InitializeComponent();
        }

    }
}
