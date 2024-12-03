using Domain.Aggregates.CryptoCurrencyMaps.ValueObjects;

namespace Domain.Tests.Aggregates.CryptoCurrencyMaps.Builders
{
    public class CryptoCurrencyIdBuilder
    {
        private Guid _value;

        public CryptoCurrencyIdBuilder()
        {
            _value = Guid.NewGuid();
        }

        public CryptoCurrencyIdBuilder WithValue(Guid value)
        {
            _value = value;

            return this;
        }


        public CryptoCurrencyId Build() => CryptoCurrencyId.Create(_value);
    }
}
