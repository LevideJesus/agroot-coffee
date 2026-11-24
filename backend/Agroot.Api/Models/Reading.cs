namespace Agroot.Api.Models;

public class Reading
{
    public int Id { get; set; }
    
    public required string DeviceId { get; set; }

    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;

    public double AirTemp { get; set; }

    public double AirHumidity { get; set; }

    public double SoilTemp { get; set; }

    public int SoilMoisture { get; set; }

    public double PlantSignalMv { get; set; }
}
