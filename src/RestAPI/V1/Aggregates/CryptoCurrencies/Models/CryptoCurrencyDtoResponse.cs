namespace RestAPI.V1.Aggregates.CryptoCurrencies.Models
{
    public class CryptoCurrencyDtoResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public double Price { get; set; }

        public double USD { get; set; }

        public double GBP { get; set; }

        public double EUR { get; set; }

        public double BRL { get; set; }

        public double AUD { get; set; }
    }
}
