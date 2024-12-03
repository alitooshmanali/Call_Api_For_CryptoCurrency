using Domain.Aggregates.CryptoCurrencyMaps.Events;
using Domain.Aggregates.CryptoCurrencyMaps.ValueObjects;

namespace Domain.Aggregates.CryptoCurrencyMaps
{
    public class CryptoCurrencyMap : Entity, IAggregateRoot
    {
        private CryptoCurrencyMap()  {}

        public CryptoCurrencyId Id { get; private set; }

        public CryptoCurrencyRank Rank { get; private set; }

        public CryptoCurrencyName Name { get; private set; }

        public CryptoCurrencySymbol Symbol { get; private set; }


        public static CryptoCurrencyMap Create(CryptoCurrencyId id,
            CryptoCurrencyRank rank,
            CryptoCurrencyName name,
            CryptoCurrencySymbol symbol)
        { 
            var map = new CryptoCurrencyMap
            {
                Id = id,
                Rank = rank,
                Name = name,
                Symbol = symbol
            };

            map.AddEvent(new CryptoCurrencyMapCreatedEvent(id, rank, name, symbol));

            return map;
        }

        public void ChangeRank(CryptoCurrencyRank value)
        {
            if (Rank == value)
                return;

            AddEvent(new CryptoCurrencyRankChangedEvent(Id, Rank, value));

            Rank = value;
        }

        public void ChangeName(CryptoCurrencyName value)
        {
            if (Name == value)
                return;

            AddEvent(new CryptoCurrencyNameChangedEvent(Id, Name, value));

            Name = value;
        }

        public void ChangeSymbol(CryptoCurrencySymbol value)
        {
            if (Symbol == value)
                return;

            AddEvent(new CryptoCurrencySymbolChangedEvent(Id, Symbol, value));

            Symbol = value;
        }

        public void Delete()
        {
            if (CanBeDeleted())
                throw new InvalidOperationException();

            AddEvent(new CryptoCurrencyMapDeletedEvent(Id));

            MarkedAsDeleted();
        }

    }
}
