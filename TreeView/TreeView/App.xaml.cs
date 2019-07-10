using System.Windows;
using TreeView.Bootstrapping;

namespace TreeView
{
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            Bootstrap bootstrap = new Bootstrap();
            BootstrapParameters bootstrapParameters = new BootstrapParameters();
            bootstrapParameters["title"] = "TestApplication";
            bootstrapParameters["version"] = "1.0.0";
            bootstrapParameters["Author"] = "Menshov Vladislav";
            Window window = bootstrap.Initialize(bootstrapParameters);
            
            window.Show();
        }

    }
}
