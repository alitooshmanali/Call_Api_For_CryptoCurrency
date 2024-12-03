using Domain.Aggregates.CryptoCurrencyMaps.ValueObjects;

namespace Domain.Tests.Aggregates.CryptoCurrencyMaps.Builders
{
    public class CryptoCurrencySymbolBuilder
    {
        private string _value;

        public CryptoCurrencySymbolBuilder()
        {
            _value = "CryptoCurrencySymbol";
        }

        public CryptoCurrencySymbolBuilder WithValue(string value)
        {
            _value = value;

            return this;
        }


        public CryptoCurrencySymbol Build() => CryptoCurrencySymbol.Create(_value);
    }
}
