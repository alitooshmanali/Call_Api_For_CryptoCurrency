using Application.Aggregates.CryptoCurrencies.Queries;
using Infrastructure.Services;
using Infrastructure.Strategies;

namespace Infrastructure
{
    public class CryptoCurrencyRepository : ICryptoCurrencyRepository
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CryptoCurrencyRepository(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Based on the strategy pattern, this section can determine which path to use. If the first path does not work, the second path will be called.
        /// </summary>
        /// <param name="cryptoCurencyCode"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>CryptoCurrencyQueryResult</returns>

        public async Task<CryptoCurrencyQueryResult> GetByCryptoCurrencyCode(string cryptoCurencyCode, CancellationToken cancellationToken = default)
        {
            var strategyContext = new StrategyContext(new CoinMarketCapStrategy(httpClientFactory));

            return await strategyContext.GetPriceByCryptoCurrencyCode(StrategyTypes.CoinMarketCap, cryptoCurencyCode);
        }

        /// <summary>
        /// Based on the strategy pattern, this section can determine which path to use. If the first path does not work, the second path will be called.
        /// </summary>
        /// <returns>List<CryptoCurrencyQueryResult></returns>
        public async Task<List<CryptoCurrencyQueryResult>> GetListOfCryptoCurrencies()
        {
            var strategyContext = new StrategyContext(new CoinMarketCapStrategy(httpClientFactory));

            return await strategyContext.GetCryptoCurrenciesPrice(StrategyTypes.CoinMarketCap);
        }
    }
}
