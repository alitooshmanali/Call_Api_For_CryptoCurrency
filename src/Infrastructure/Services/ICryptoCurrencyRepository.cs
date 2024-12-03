using Application.Aggregates.CryptoCurrencies.Queries;

namespace Infrastructure.Services
{
    public interface ICryptoCurrencyRepository
    {
        Task<List<CryptoCurrencyQueryResult>> GetListOfCryptoCurrencies();

        Task<CryptoCurrencyQueryResult> GetByCryptoCurrencyCode(string cryptoCurencyCode, CancellationToken cancellationToken = default!);
    }
}
