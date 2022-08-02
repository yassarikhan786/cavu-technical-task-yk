namespace Services.Db.Interfaces
{
    /// <summary>
    /// This represents the data access layer and will return
    /// ParkingSpace objects in a JSON format.
    /// </summary>
    public interface IParkingSpaceService
    {
        string GetAvailableParkingServices(DateTime dateFrom, DateTime dateTo);
    }
}
