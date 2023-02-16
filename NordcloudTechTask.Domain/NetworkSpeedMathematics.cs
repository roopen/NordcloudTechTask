using System.Drawing;
using System.Numerics;

namespace NordcloudTechTask.Domain
{
    public static class NetworkSpeedMathematics
    {
        public static float GetSpeed(NetworkStation networkStation, DeviceLocation device)
        {
            float distance = GetDeviceDistanceFromNetworkStation(networkStation, device);

            if (distance > networkStation.reach) return 0; //Device is out of reach of the network station. Speed of 0 means unusable.

            //Conversion from double to float does no violence to our accuracy here. Massive distances would break the cast but they would be outside station range anyways.
            return (float)Math.Pow(networkStation.reach - distance, 2);
        }

        public static float GetDeviceDistanceFromNetworkStation(NetworkStation networkStation, DeviceLocation device)
        {
            //Since .NET Core doesn't have a built-in way to make calculations between 2-dimensional points, we'll represent the points as vectors.
            Vector2 stationAsVector = new Vector2(networkStation.x, networkStation.y);
            Vector2 deviceAsVector = new Vector2(device.x, device.y);
            return Vector2.Distance(stationAsVector, deviceAsVector);
        }

        /// <summary>
        /// Very naive algorithm for finding the suitable network station. Iterates through every station. The time complexity is O(n).
        /// </summary>
        /// <param name="networkStations">List of network stations to compare the device's location to.</param>
        /// <param name="device"></param>
        /// <returns>MostSuitableNetworkStationResult or null if none found.</returns>
        public static MostSuitableNetworkStationResult GetMostSuitableNetworkStation(IEnumerable<NetworkStation> networkStations, DeviceLocation device)
        {
            NetworkStation? MostSuitableNetworkStationLocation = null;
            float BestSpeed = 0;

            foreach (var station in networkStations)
            {
                var speed = GetSpeed(station, device);

                if (speed != 0)
                    if (speed > BestSpeed)
                    {
                        BestSpeed = speed;
                        MostSuitableNetworkStationLocation = station;
                    }
            }

            if (MostSuitableNetworkStationLocation == null) return new MostSuitableNetworkStationResult(null, device, 0);

            return new MostSuitableNetworkStationResult(MostSuitableNetworkStationLocation, device, BestSpeed);
        }
    }
}
