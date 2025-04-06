using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using AutoUpdaterDotNET;

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

        // Set the URL to your update XML file
        AutoUpdater.Start("https://raw.githubusercontent.com/Pepice23/TheMysteriousTower/main/update.xml");

        // Optional: Set update check interval (in minutes)
        AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
        AutoUpdater.LetUserSelectRemindLater = true;
        AutoUpdater.RemindLaterTimeSpan = RemindLaterFormat.Days;
        AutoUpdater.RemindLaterAt = 2; // Remind after 2 days
    }

    private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
    {
        if (args.IsUpdateAvailable)
        {
            DialogResult dialogResult = MessageBox.Show(
                $@"There is a new version {args.CurrentVersion} available. You currently have version {args.InstalledVersion}. Do you want to update now?",
                @"Update Available",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (dialogResult.Equals(DialogResult.Yes))
            {
                try
                {
                    AutoUpdater.DownloadUpdate(args);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
