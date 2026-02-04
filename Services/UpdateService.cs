using System.Threading.Tasks;
using Velopack;
using System;

namespace AvaloniaTetris.Services
{
    public class UpdateService
    {
        public static async Task CheckForUpdates()
        {
            try
            {
                var mgr = new UpdateManager("https://the.url.of/your/releases");
                
                // check for new version
                var newVersion = await mgr.CheckForUpdatesAsync();
                if (newVersion == null)
                    return; // no update available

                // download new version
                await mgr.DownloadUpdatesAsync(newVersion);

                // install new version and restart app
                mgr.ApplyUpdatesAndRestart(newVersion);
            }
            catch (Exception)
            {
                // Handle or log error
            }
        }
    }
}
