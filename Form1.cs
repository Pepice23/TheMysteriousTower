using Microsoft.AspNetCore.Components.WebView.WindowsForms;

namespace TheMysteriousTower;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Text = "The Mysterious Tower";
        Width = 1280;
        Height = 720;
        StartPosition = FormStartPosition.CenterScreen;

        var blazor = new BlazorWebView()
        {
            Dock = DockStyle.Fill,
            HostPage = "wwwroot/index.html",
            Services = Startup.Services!,
            StartPath = "/"
        };

        blazor.RootComponents.Add<Main>("#app");
        Controls.Add(blazor);
    }
}
