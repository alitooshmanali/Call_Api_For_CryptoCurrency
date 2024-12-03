namespace Infrastructure.Helpers
{
    public static class ThirdPartyConstant
    {
        public static string CoinMarketCapProviderBaseUrl => "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest";

        public static string CoinMarketCapProviderQuoteUrl => "https://pro-api.coinmarketcap.com/v2/cryptocurrency/quotes/latest";

        public static string CoinMarketCapProviderSymbols => "USD,EUR,BRL,GBP,AUD";

        public static string CoinMarketCapApiKey => "0566a1c0-20b0-4ad9-bcdd-9f54936068fe";

        public static int CoinMarketCapTimeout => 30000;
    }
}
