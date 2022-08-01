
using SynologyDotNet.FileStation.Models;

namespace SynologyDotNet.FileStation.IntegrationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var fileStationClient = new FileStationClient();
            using var client = new SynoClient(new Uri("https://your.synology.me:5001"));
            await client.AddAsync(fileStationClient).ConfigureAwait(false);
            await client.LoginAsync("username", "password").ConfigureAwait(false);

            // Execute requests

            await client.LogoutAsync();
        }
    }
}