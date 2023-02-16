namespace NordcloudTechTask.Tests
{
    public class ConsoleAppTests
    {
        [Test]
        [Parallelizable]
        public void GetNetworkStationsReturnsSomething()
        {
            List<NetworkStation> stations = ConsoleAppHelpers.GetNetworkStations();

            Assert.That(stations != null && stations.Count > 0);
        }

        [Test]
        [Parallelizable]
        public void GetDeviceLocationsReturnsSomething()
        {
            List<DeviceLocation> deviceLocations = ConsoleAppHelpers.GetDeviceLocations();

            Assert.That(deviceLocations != null && deviceLocations.Count > 0);
        }

        [Test]
        [Parallelizable]
        public void PrintResultNullDoesntCrash()
        {
            var message = ConsoleAppHelpers.ParseResultIntoPrintableString(null);

            Assert.That(string.IsNullOrEmpty(message));
        }

        [Test]
        [Parallelizable]
        public void PrintResultStationFound()
        {
            DeviceLocation deviceLocation = new DeviceLocation(0, 0);
            NetworkStation networkStation = new NetworkStation(0, 0, 10);
            MostSuitableNetworkStationResult result = new MostSuitableNetworkStationResult(networkStation, deviceLocation, 100);
            var message = ConsoleAppHelpers.ParseResultIntoPrintableString(result);

            Assert.That(
                message == $"Best network station for point {deviceLocation.x}, {deviceLocation.y} is {networkStation.x}, {networkStation.y} with speed {result.speed}"
            );
        }

        [Test]
        [Parallelizable]
        public void PrintResultStationNotFound()
        {
            DeviceLocation deviceLocation = new DeviceLocation(-100, 100);
            MostSuitableNetworkStationResult result = new MostSuitableNetworkStationResult(null, deviceLocation, 0);
            var message = ConsoleAppHelpers.ParseResultIntoPrintableString(result);

            Assert.That(message == $"No network station within reach for point {deviceLocation.x}, {deviceLocation.y}");
        }
    }
}
