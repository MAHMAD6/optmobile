namespace OptMobile.Retailer.Services;

public class AppVersionService
{
    public string AppVersion { get; private set; }
    public string AppBuild { get; private set; }

    public AppVersionService()
    {
        // Retrieve version information
        AppVersion = VersionTracking.CurrentVersion;
        AppBuild = VersionTracking.CurrentBuild;
    }
}
