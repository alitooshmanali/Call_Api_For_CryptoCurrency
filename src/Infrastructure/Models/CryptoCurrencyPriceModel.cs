namespace Infrastructure.Models
{
    public class CryptoCurrencyPriceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public double Price { get; set; }
    }
}
