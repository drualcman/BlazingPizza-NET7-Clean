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

        services.AddSingleton<IConfiguration>(configuration);
        services.AddBlazingPizzaBackendServices(configuration.GetConnectionString("BlazingPizzaDb"),
                                                configuration["ImageBaseUrl"]);   
        services.AddBlazingPizzaDesktopServices();
        Resources.Add("Services", services.BuildServiceProvider());
    }
}
