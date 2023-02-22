namespace BlazingPizza.WinFormsClient;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        RegisterServices();
    }


    void RegisterServices()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddWindowsFormsBlazorWebView();

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        services.AddSingleton<IConfiguration>(configuration);

        //Options Pathern
        EndpointsOptions endpoints = configuration.GetSection(EndpointsOptions.SectionKey).Get<EndpointsOptions>();
        services.Configure<EndpointsOptions>(options => options = endpoints);            
        SpecialsOptions specials = configuration.GetSection(SpecialsOptions.SectionKey).Get<SpecialsOptions>();
        services.Configure<SpecialsOptions>(options => options = specials);

        services.AddBlazingPizzaBackendServices(configuration.GetConnectionString("BlazingPizzaDb"));
        services.AddBlazingPizzaFrontendServices(Options.Create(endpoints));
        blazorWebView1.HostPage = "wwwroot\\index.html";
        blazorWebView1.RootComponents.Add<App>("#app");
        blazorWebView1.Services = services.BuildServiceProvider();
    }
}