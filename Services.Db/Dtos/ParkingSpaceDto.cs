namespace Services.Db.Dtos
{
    internal class ParkingSpaceDto
    {
        public bool IsAvailable { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
