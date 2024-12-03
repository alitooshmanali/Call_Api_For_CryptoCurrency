using MediatR;

namespace Application.Aggregates.CryptoCurrencies.Queries.GetCollections
{
    public class GetCryptoCurrencyCollectionQuery: IRequest<BaseCollectionResult<CryptoCurrencyQueryResult>>
    {
    }
}
