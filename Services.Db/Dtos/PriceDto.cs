namespace Services.Db.Dtos
{
    internal class PriceDto : BaseDto
    {
        private double _basePrice;

        public double BasePrice 
        {
            get
            {
                if (SummerPrice > 0)
                {
                    return SummerPrice;
                }
                return _basePrice;
            }
            set 
            { 
                _basePrice = value; 
            }
        }

        public double SummerPrice 
        { 
            private get;
            set; 
        }
    }
}
