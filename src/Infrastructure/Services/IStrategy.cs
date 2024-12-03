using Application.Aggregates.CryptoCurrencies.Queries;

namespace Infrastructure.Services
{
    public interface IStrategy
    {
        Task<List<CryptoCurrencyQueryResult>> GetListOfAllCryptoCurrency();

        Task<CryptoCurrencyQueryResult> GetPriceByCryptoCurrency(string cryptoCurrencyCode, CancellationToken cancellationToken = default!);
    }
}
