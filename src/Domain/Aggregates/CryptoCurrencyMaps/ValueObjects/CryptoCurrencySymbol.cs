
using Domain.Aggregates.CryptoCurrencyMaps.ValueObjects.Rules;

namespace Domain.Aggregates.CryptoCurrencyMaps.ValueObjects
{
    public class CryptoCurrencySymbol : ValueObject
    {
        private CryptoCurrencySymbol()
        {   
        }

        public string Value { get; private init; }

        public static CryptoCurrencySymbol Create(string value)
        {
            CheckRule(new CryptoCurrencySymbolCannotBeEmptyRule(value));

            return new() { Value = value };
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
