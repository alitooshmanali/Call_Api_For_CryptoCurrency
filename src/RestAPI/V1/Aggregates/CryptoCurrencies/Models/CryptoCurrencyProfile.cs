using Application.Aggregates.CryptoCurrencies.Queries;
using AutoMapper;

namespace RestAPI.V1.Aggregates.CryptoCurrencies.Models
{
    public class CryptoCurrencyProfile: Profile
    {
        public CryptoCurrencyProfile()
        {
            CreateMap<CryptoCurrencyQueryResult, CryptoCurrencyDtoResponse>();
        }
    }
}
