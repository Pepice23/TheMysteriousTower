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

        try
        {
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
        catch (DllNotFoundException)
        {
            MessageBox.Show(
                "Microsoft Edge WebView2 Runtime is not installed. The application will now open the download page.\n\n" +
                "Please install the runtime and restart the application.",
                "WebView2 Runtime Missing",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://developer.microsoft.com/en-us/microsoft-edge/webview2/",
                UseShellExecute = true
            });

            Application.Exit();
            return;
        }
    }
}
