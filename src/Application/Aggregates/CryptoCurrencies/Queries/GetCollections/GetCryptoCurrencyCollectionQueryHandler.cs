using Infrastructure.Services;
using MediatR;

namespace Application.Aggregates.CryptoCurrencies.Queries.GetCollections
{
    public class GetCryptoCurrencyCollectionQueryHandler : IRequestHandler<GetCryptoCurrencyCollectionQuery, BaseCollectionResult<CryptoCurrencyQueryResult>>
    {
        private readonly ICryptoCurrencyRepository cryptoCurrencyRepository;

        public GetCryptoCurrencyCollectionQueryHandler(ICryptoCurrencyRepository cryptoCurrencyRepository)
        {
            this.cryptoCurrencyRepository = cryptoCurrencyRepository;
        }

        public async Task<BaseCollectionResult<CryptoCurrencyQueryResult>> Handle(GetCryptoCurrencyCollectionQuery request, CancellationToken cancellationToken)
        {
            var source = await cryptoCurrencyRepository.GetListOfCryptoCurrencies();

            return new BaseCollectionResult<CryptoCurrencyQueryResult>
            {
                Result = source,
                TotalCount = source.Count()
            };
        }
    }
}
