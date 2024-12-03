namespace Infrastructure.Models.CoinMarketCaps
{
    public class LatestPlatform
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public string Slug { get; set; }

        public string TokenAddress { get; set; }
    }
}
