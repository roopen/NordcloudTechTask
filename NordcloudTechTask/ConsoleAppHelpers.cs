using NordcloudTechTask.Domain;
using System;
using System.Collections.Generic;
namespace NordcloudTechTask
{
    public static class ConsoleAppHelpers
    {
        public static string ParseResultIntoPrintableString(MostSuitableNetworkStationResult result)
        {
            if (result == null)
                return null;

            if (result.Station == null)
                return $"No network station within reach for point {result.DeviceLocation.x}, {result.DeviceLocation.y}";
            else
                return $"Best network station for point {result.DeviceLocation.x}, {result.DeviceLocation.y} is {result.Station.x}, {result.Station.y} with speed {result.speed}";
        }

        public static List<NetworkStation> GetNetworkStations()
        {
            return new List<NetworkStation>()
            {
                new NetworkStation(0, 0, 9),
                new NetworkStation(20, 20, 6),
                new NetworkStation(10, 0, 12),
                new NetworkStation(5, 5, 13),
                new NetworkStation(99, 25, 2)
            };
        }

        public static List<DeviceLocation> GetDeviceLocations()
        {
            return new List<DeviceLocation>()
            {
                new DeviceLocation(0, 0),
                new DeviceLocation(100, 100),
                new DeviceLocation(15, 10),
                new DeviceLocation(18, 18),
                new DeviceLocation(13, 13),
                new DeviceLocation(25, 9)
            };
        }
    }
}
