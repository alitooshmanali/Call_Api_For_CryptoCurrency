using Domain.Aggregates.CryptoCurrencyMaps;

namespace Domain.Tests.Aggregates.CryptoCurrencyMaps.Builders
{
    public class CryptoCurrencyMapBuilder
    {
        private Guid _id;

        private string _name;

        private string _symbol;

        private int _rank;

        public CryptoCurrencyMapBuilder()
        {
            _id = Guid.NewGuid();
            _name = "Bitcoin";
            _symbol = "BTC";
            _rank = new Random().Next(1, 9999);
        }


        public CryptoCurrencyMapBuilder WithId(Guid value)
        {
            _id = value;

            return this;
        }

        public CryptoCurrencyMapBuilder WithName(string value)
        {
            _name = value;

            return this;
        }

        public CryptoCurrencyMapBuilder WithSymbol(string value)
        {
            _symbol = value;

            return this;
        }

        public CryptoCurrencyMapBuilder WithRank(int value)
        {
            _rank = value;

            return this;
        }

        public CryptoCurrencyMap Build()
        {
            var idProperty = new CryptoCurrencyIdBuilder().WithValue(_id).Build();
            var rankProperty = new CryptoCurrencyRankBuilder().WithValue(_rank).Build();
            var nameProperty = new CryptoCurrencyNameBuilder().WithValue(_name).Build();
            var symbolProperty = new CryptoCurrencySymbolBuilder().WithValue(_symbol).Build();

            return CryptoCurrencyMap.Create(idProperty, rankProperty, nameProperty, symbolProperty);
        }
    }
}
