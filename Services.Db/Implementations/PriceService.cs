using Newtonsoft.Json;
using Services.Db.Dtos;
using Services.Db.Interfaces;

namespace Services.Db.Implementations
{
    internal class PriceService : IPriceService
    {
        private readonly List<PriceDto> _prices;

        public PriceService()
        {
            _prices = new()
            {
                new()
                {
                    BasePrice = 14.99,
                    DateFrom = new DateTime(2022, 1, 1),
                    DateTo = new DateTime(2022, 6, 20),
                },
                new()
                {
                    BasePrice = 14.99,
                    SummerPrice = 16.99,
                    DateFrom = new DateTime(2022, 6, 21),
                    DateTo = new DateTime(2022, 9, 21),
                }
            };
        }

        public string GetPrices(DateTime dateFrom, DateTime dateTo)
        {
            var matchedPrices = _prices.Where(x => x.DateFrom >= dateFrom && x.DateTo <= dateTo).ToList();
            return JsonConvert.SerializeObject(matchedPrices);
        }
    }
}
