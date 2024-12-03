using Domain.Aggregates.CryptoCurrencyMaps.ValueObjects;

namespace Domain.Tests.Aggregates.CryptoCurrencyMaps.Builders
{
    public class CryptoCurrencyRankBuilder
    {
        private int _value;

        public CryptoCurrencyRankBuilder()
        {
            _value = new Random().Next(1, 9999);
        }

        public CryptoCurrencyRankBuilder WithValue(int value)
        {
            _value = value;

            return this;
        }

        public CryptoCurrencyRank Build() => CryptoCurrencyRank.Create(_value);
    }
}
