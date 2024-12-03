using Application.Aggregates.CryptoCurrencies.Queries;
using Infrastructure.Services;

namespace Infrastructure.Strategies
{
    public class StrategyContext
    {
        private readonly IStrategy strategy;

        public StrategyContext(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public async Task<List<CryptoCurrencyQueryResult>> GetCryptoCurrenciesPrice(StrategyTypes type)
        {
            // TODO : can added several thried party to get data
            return await strategy.GetListOfAllCryptoCurrency();
        }

        public async Task<CryptoCurrencyQueryResult> GetPriceByCryptoCurrencyCode(StrategyTypes type, string cryptoCurrencyCode)
        {
            // TODO : can added several thried party to get data
            return await strategy.GetPriceByCryptoCurrency(cryptoCurrencyCode);
        }

    }
}
