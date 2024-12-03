
using Domain.Aggregates.CryptoCurrencyMaps.ValueObjects;

namespace Domain.Aggregates.CryptoCurrencyMaps.Events
{
    public class CryptoCurrencyMapDeletedEvent : DomainBaseEvent
    {
        public CryptoCurrencyMapDeletedEvent(CryptoCurrencyId id) 
            : base(id.Value)
        {
        }
    }
}
