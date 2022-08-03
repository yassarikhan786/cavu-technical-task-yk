namespace Services.Db.Dtos
{
    /// <summary>
    /// Provides common values used across child DTOs
    /// </summary>
    internal class BaseDto
    {
        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
