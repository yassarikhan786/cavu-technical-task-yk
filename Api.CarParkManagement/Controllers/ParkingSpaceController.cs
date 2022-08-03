using Api.CarParkManagement.Models;
using Api.CarParkManagement.Models.Query;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Db.Interfaces;

namespace Api.CarParkManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingSpaceController : ControllerBase
    {
        #region Private Fields

        private readonly IParkingSpaceService _packingSpaceService;

        #endregion Private Fields

        public ParkingSpaceController(IParkingSpaceService packingSpaceService)
        {
            _packingSpaceService = packingSpaceService;
        }

        [HttpGet]
        public ActionResult<List<ParkingSpace>> GetAvailableParkingSpaces(DateTime dateFrom, DateTime dateTo)
        {
            var result = _packingSpaceService.GetAvailableParkingServices(dateFrom, dateTo);

            if (string.IsNullOrEmpty(result))
            {
                return NotFound();
            }

            var availableParkingSpaces = JsonConvert.DeserializeObject<IEnumerable<ParkingSpace>>(result);

            return Ok(availableParkingSpaces);
        }
    }
}