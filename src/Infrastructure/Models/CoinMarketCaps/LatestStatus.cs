namespace Infrastructure.Models.CoinMarketCaps
{
    public class LatestStatus
    {
        public DateTime TimeStamp { get; set; }

        public int ErrorCode { get; set; }

        public object ErrorMessage { get; set; }

        public int Elapsed { get; set; }

        public int CreditCount { get; set; }

        public object Notice { get; set; }

        public int TotalCount { get; set; }
    }
}
