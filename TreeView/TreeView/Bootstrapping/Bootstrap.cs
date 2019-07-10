using System.Windows;
using TreeView.Abstractions;
using TreeView.ViewModels;

namespace TreeView.Bootstrapping
{
    public class Bootstrap : IBootstrap
    {
        public Window Initialize(BootstrapParameters bootstrapParameters)
        {
            string title = (string)bootstrapParameters["title"];
            string version=(string)bootstrapParameters["version"];
            string author = (string)bootstrapParameters["Author"];
            string summaryHeader = title + " " + version + " " + author + " ";
            var viewModel = new ViewModel();
            var window = new MainWindow(summaryHeader, viewModel);
            window.Show();
            return window;
        }
    }

}
