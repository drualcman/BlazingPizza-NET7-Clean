using BlazingPizza.BussinesObjects.ValueObjects;
using Microsoft.Extensions.Configuration;
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
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        services.AddBlazingPizzaFrontendServices(configuration.GetSection("BlazzingPizzaEndpoint").Get<EndpointsOptions>());
        Resources.Add("Services", services.BuildServiceProvider()); 
    }
}
