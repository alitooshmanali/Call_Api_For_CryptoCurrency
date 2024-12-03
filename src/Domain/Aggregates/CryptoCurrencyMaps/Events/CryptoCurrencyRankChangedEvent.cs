
using Domain.Aggregates.CryptoCurrencyMaps.ValueObjects;

namespace Domain.Aggregates.CryptoCurrencyMaps.Events
{
    public class CryptoCurrencyRankChangedEvent : DomainBaseEvent
    {
        public CryptoCurrencyRankChangedEvent(CryptoCurrencyId id, CryptoCurrencyRank oldValue, CryptoCurrencyRank newValue)
            : base(id.Value)
        {
            OldValue = oldValue.Value;
            NewValue = newValue.Value;
        }

        public int OldValue { get; }

        public int NewValue { get; }
    }
}
