using Newtonsoft.Json;
using Services.Db.Dtos;
using Services.Db.Interfaces;

namespace Services.Db.Implementations
{
    public class ParkingSpaceService : IParkingSpaceService
    {
        private readonly List<ParkingSpaceDto> _parkingSpaces;

        public ParkingSpaceService()
        {
            // Set up dummy Parking Space data. In reality this would all exist within some sort of database
            _parkingSpaces = new()
            {
                new()
                {
                    IsAvailable = false
                },
                new()
                {
                    IsAvailable = true,
                    DateFrom = DateTime.Now.AddDays(1).Date,
                    DateTo = DateTime.Now.AddDays(7).Date
                },
                new()
                {
                    IsAvailable = true,
                    DateFrom = DateTime.Now.AddDays(11).Date,
                    DateTo = DateTime.Now.AddDays(17).Date
                }
            };
        }

        public string GetAvailableParkingServices(DateTime dateFrom, DateTime dateTo)
        {
            var availableParkingSpaces = _parkingSpaces.Where(x => x.IsAvailable && x.DateFrom >= dateFrom && x.DateTo <= dateTo).ToList();
            return JsonConvert.SerializeObject(availableParkingSpaces);
        }
    }
}
