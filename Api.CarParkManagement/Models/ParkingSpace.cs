namespace Api.CarParkManagement.Models
{
    /// <summary>
    /// Represents a Parking Space object where it is only available 
    /// if the current date is between DateFrom and DateTo.
    /// </summary>
    public class ParkingSpace
    {
        public bool IsAvailable { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
