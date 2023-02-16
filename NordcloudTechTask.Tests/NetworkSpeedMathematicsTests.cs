namespace NordcloudTechTask.Tests
{
    public class NetworkSpeedMathematicsTests
    {
        List<NetworkStation> _networkStations;

        [OneTimeSetUp]
        public void Setup()
        {
            _networkStations = new List<NetworkStation>()
            {
                new NetworkStation(0, 0, 9),
                new NetworkStation(20, 20, 6),
                new NetworkStation(10, 0, 12),
                new NetworkStation(5, 5, 13),
                new NetworkStation(99, 25, 2)
            };
        }

        [Test]
        [Parallelizable]
        public void CalculateDistanceBetweenDeviceAndStationSameLocation()
        {
            NetworkStation networkStation = new NetworkStation(0, 0, 9);
            DeviceLocation deviceLocation = new DeviceLocation(0, 0);

            float distance = NetworkSpeedMathematics.GetDeviceDistanceFromNetworkStation(networkStation, deviceLocation);

            Assert.That(distance == 0);
        }

        [Test]
        [Parallelizable]
        public void CalculateDistanceBetweenDeviceAndStationDistanceOf5()
        {
            //Example calculated by hand here: https://www.geogebra.org/m/Q9dRvWsB
            NetworkStation networkStation = new NetworkStation(5, 2, 9);
            DeviceLocation deviceLocation = new DeviceLocation(1, 5);

            float distance = NetworkSpeedMathematics.GetDeviceDistanceFromNetworkStation(networkStation, deviceLocation);

            Assert.That(distance == 5);
        }

        [Test]
        [Parallelizable]
        public void CalculateSpeedSameLocationReachOf10()
        {
            //10 * 10 = 100
            NetworkStation networkStation = new NetworkStation(0, 0, 10);
            DeviceLocation deviceLocation = new DeviceLocation(0, 0);

            float speed = NetworkSpeedMathematics.GetSpeed(networkStation, deviceLocation);

            Assert.That(speed == 100);
        }

        [Test]
        [Parallelizable]
        public void CalculateSpeedOutOfReach()
        {
            NetworkStation networkStation = new NetworkStation(0, 0, 10);
            DeviceLocation deviceLocation = new DeviceLocation(100, 100);

            float speed = NetworkSpeedMathematics.GetSpeed(networkStation, deviceLocation);

            Assert.That(speed == 0);
        }

        [Test]
        [Parallelizable]
        public void CalculateSpeedSameLocationReachOf9()
        {
            //9 * 9 = 81
            NetworkStation networkStation = new NetworkStation(0, 0, 9);
            DeviceLocation deviceLocation = new DeviceLocation(0, 0);

            float speed = NetworkSpeedMathematics.GetSpeed(networkStation, deviceLocation);

            Assert.That(speed == 81);
        }

        [Test]
        [Parallelizable]
        public void GetSuitableStationDeviceHasSameLocationWithAStation()
        {
            DeviceLocation deviceLocation = new DeviceLocation(0, 0);

            var mostSuitableNetworkStationResult = NetworkSpeedMathematics.GetMostSuitableNetworkStation(_networkStations, deviceLocation);

            if (mostSuitableNetworkStationResult == null)
            {
                Console.WriteLine("Result was null. No suitable network station found.");
                Assert.Fail();
            }

            Assert.That(
                mostSuitableNetworkStationResult.Station.y == 0 &&
                mostSuitableNetworkStationResult.Station.x == 0 &&
                mostSuitableNetworkStationResult.speed == 81 &&
                mostSuitableNetworkStationResult.DeviceLocation.x == deviceLocation.x &&
                mostSuitableNetworkStationResult.DeviceLocation.y == deviceLocation.y
                );
        }

        [Test]
        [Parallelizable]
        public void GetSuitableStationDeviceHasLocationX18Y18()
        {
            DeviceLocation deviceLocation = new DeviceLocation(18, 18);

            var mostSuitableNetworkStationResult = NetworkSpeedMathematics.GetMostSuitableNetworkStation(_networkStations, deviceLocation);
            
            Assert.That(
                mostSuitableNetworkStationResult.Station.y == 20 &&
                mostSuitableNetworkStationResult.Station.x == 20 &&
                (int)mostSuitableNetworkStationResult.speed == 10 &&
                mostSuitableNetworkStationResult.DeviceLocation.x == deviceLocation.x &&
                mostSuitableNetworkStationResult.DeviceLocation.y == deviceLocation.y
                );
        }

        [Test]
        [Parallelizable]
        public void GetSuitableStationDeviceHasNegativeCoordinates()
        {
            DeviceLocation deviceLocation = new DeviceLocation(-1, -1);

            var mostSuitableNetworkStationResult = NetworkSpeedMathematics.GetMostSuitableNetworkStation(_networkStations, deviceLocation);

            Assert.That(
                mostSuitableNetworkStationResult.Station.y == 0 &&
                mostSuitableNetworkStationResult.Station.x == 0 &&
                (int)mostSuitableNetworkStationResult.speed == 57 &&
                mostSuitableNetworkStationResult.DeviceLocation.x == deviceLocation.x &&
                mostSuitableNetworkStationResult.DeviceLocation.y == deviceLocation.y
                );
        }

        [Test]
        [Parallelizable]
        public void GetSuitableStationNoSuitableLocationFound()
        {
            DeviceLocation deviceLocation = new DeviceLocation(100, 100);

            var mostSuitableNetworkStationResult = NetworkSpeedMathematics.GetMostSuitableNetworkStation(_networkStations, deviceLocation);

            Assert.That(
                mostSuitableNetworkStationResult.Station == null &&
                mostSuitableNetworkStationResult.DeviceLocation.x == deviceLocation.x &&
                mostSuitableNetworkStationResult.DeviceLocation.y == deviceLocation.y &&
                mostSuitableNetworkStationResult.speed == 0
                );
        }
    }
}