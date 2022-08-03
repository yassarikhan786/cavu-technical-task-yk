namespace Services.Db.Interfaces
{
    internal interface IPriceService
    {
        string GetPrices(DateTime dateFrom, DateTime dateTo);
    }
}
