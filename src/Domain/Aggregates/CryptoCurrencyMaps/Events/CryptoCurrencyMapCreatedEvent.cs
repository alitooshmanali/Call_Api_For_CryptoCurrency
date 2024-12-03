
using Domain.Aggregates.CryptoCurrencyMaps.ValueObjects;

namespace Domain.Aggregates.CryptoCurrencyMaps.Events
{
    public class CryptoCurrencyMapCreatedEvent : DomainBaseEvent
    {
        public CryptoCurrencyMapCreatedEvent(CryptoCurrencyId id, CryptoCurrencyRank rank, CryptoCurrencyName name, CryptoCurrencySymbol symbol)
            : base(id.Value)
        {
            Rank = rank.Value;
            Name = name.Value;
            Symbol = symbol.Value;
        }

        public int Rank { get; }

        public string Name { get; }

        public string Symbol { get; }
    }
}
