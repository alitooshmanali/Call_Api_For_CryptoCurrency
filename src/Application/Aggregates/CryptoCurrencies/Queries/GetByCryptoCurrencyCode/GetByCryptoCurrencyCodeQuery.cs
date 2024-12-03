using MediatR;

namespace Application.Aggregates.CryptoCurrencies.Queries.GetByCryptoCurrencyCode
{
    public class GetByCryptoCurrencyCodeQuery : IRequest<CryptoCurrencyQueryResult>
    {
        public string CryptoCurrencyCode { get; set; }
    }
}
