using NordcloudTechTask;
using NordcloudTechTask.Domain;

Console.WriteLine("Network speed application has started.");

List<NetworkStation> networkStations = ConsoleAppHelpers.GetNetworkStations();
List<DeviceLocation> deviceLocations = ConsoleAppHelpers.GetDeviceLocations();

foreach (var deviceLocation in deviceLocations)
{
    var mostSuitableNetworkStationResult = NetworkSpeedMathematics.GetMostSuitableNetworkStation(networkStations, deviceLocation);

    string message = ConsoleAppHelpers.ParseResultIntoPrintableString(mostSuitableNetworkStationResult);

    Console.WriteLine(message);
}

Console.WriteLine("Finished. Press any key to quit.");
Console.ReadLine();