using Infrastructure.Services;
using MediatR;

namespace Application.Aggregates.CryptoCurrencies.Queries.GetByCryptoCurrencyCode
{
    public class GetByCryptoCurrencyCodeQueryHandler : IRequestHandler<GetByCryptoCurrencyCodeQuery, CryptoCurrencyQueryResult>
    {
        private readonly ICryptoCurrencyRepository cryptoCurrencyRepository;

        public GetByCryptoCurrencyCodeQueryHandler(ICryptoCurrencyRepository cryptoCurrencyRepository)
        {
            this.cryptoCurrencyRepository = cryptoCurrencyRepository;
        }

        public async Task<CryptoCurrencyQueryResult> Handle(GetByCryptoCurrencyCodeQuery request, CancellationToken cancellationToken)
        => await cryptoCurrencyRepository.GetByCryptoCurrencyCode(request.CryptoCurrencyCode, cancellationToken);
    }
}
