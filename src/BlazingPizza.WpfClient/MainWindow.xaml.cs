using System.Windows;

namespace BlazingPizza.WpfClient;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        RegisterServices();
    }

    void RegisterServices()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddWpfBlazorWebView();
        services.AddBlazingPizzaFrontendServices();
        Resources.Add("Services", services.BuildServiceProvider()); 
    }
}
