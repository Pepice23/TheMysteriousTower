using AutoUpdaterDotNET;

namespace TheMysteriousTower;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Configure and check for updates before initializing the application
        try
        {
            AutoUpdater.AppTitle = "The Mysterious Tower";
            AutoUpdater.AppCastURL = "https://raw.githubusercontent.com/Pepice23/TheMysteriousTower/main/update.xml";
            AutoUpdater.Mandatory = false;
            AutoUpdater.UpdateMode = Mode.Normal;
            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.ShowRemindLaterButton = true;
            AutoUpdater.RemindLaterTimeSpan = RemindLaterFormat.Days;
            AutoUpdater.RemindLaterAt = 2;

            // Run update check synchronously before app starts
            AutoUpdater.Synchronous = true;
            AutoUpdater.Start();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error checking for updates: {ex.Message}", "Update Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Continue with normal application startup
        Startup.Init();
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}
