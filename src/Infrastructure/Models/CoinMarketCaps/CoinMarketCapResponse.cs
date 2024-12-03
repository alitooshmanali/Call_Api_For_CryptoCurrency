using System.Text.Json.Serialization;

namespace Infrastructure.Models.CoinMarketCaps
{
    public class CoinMarketCapResponse
    {
        public LatestStatus Status { get; set; }

        public List<LatestModel> Data { get; set; }
    }
}
