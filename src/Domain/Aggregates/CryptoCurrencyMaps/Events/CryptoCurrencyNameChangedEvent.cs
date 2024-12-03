using Domain.Aggregates.CryptoCurrencyMaps.ValueObjects;

namespace Domain.Aggregates.CryptoCurrencyMaps.Events
{
    public class CryptoCurrencyNameChangedEvent : DomainBaseEvent
    {
        public CryptoCurrencyNameChangedEvent(CryptoCurrencyId id, CryptoCurrencyName oldValue, CryptoCurrencyName newValue)
            : base(id.Value)
        {
            OldValue = oldValue.Value;
            NewValue = newValue.Value;
        }

        public string OldValue { get; }

        public string NewValue { get; }
    }
}
