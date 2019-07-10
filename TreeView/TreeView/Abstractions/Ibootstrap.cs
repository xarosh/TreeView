using System.Windows;
using TreeView.Bootstrapping;

namespace TreeView.Abstractions
{
    public interface IBootstrap
    {
        Window Initialize(BootstrapParameters bootstrapParameters);
    }
}
