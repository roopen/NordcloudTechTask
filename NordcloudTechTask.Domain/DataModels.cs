namespace NordcloudTechTask.Domain
{
    public record DeviceLocation(int x, int y);
    public record NetworkStation(int x, int y, int reach);
    public record MostSuitableNetworkStationResult(NetworkStation Station, DeviceLocation DeviceLocation, float speed);
}