using Domain.Aggregates.CryptoCurrencyMaps.ValueObjects;

namespace Domain.Tests.Aggregates.CryptoCurrencyMaps.Builders
{
    public class CryptoCurrencyNameBuilder
    {
        private string _value;

        public CryptoCurrencyNameBuilder()
        {
            _value = "CryptoCurrencyName";
        }

        public CryptoCurrencyNameBuilder WithValue(string value)
        {
            _value = value;

            return this;
        }


        public CryptoCurrencyName Build() => CryptoCurrencyName.Create(_value);
    }
}
