
using Domain.Aggregates.CryptoCurrencyMaps.ValueObjects;

namespace Domain.Aggregates.CryptoCurrencyMaps.Events
{
    public class CryptoCurrencySymbolChangedEvent : DomainBaseEvent
    {
        public CryptoCurrencySymbolChangedEvent(CryptoCurrencyId id, CryptoCurrencySymbol oldValue, CryptoCurrencySymbol newValue)
            : base(id.Value)
        {
            OldValue = oldValue.Value;
            NewValue = newValue.Value;
        }

        public string OldValue { get; }

        public string NewValue { get; }
    }
}
