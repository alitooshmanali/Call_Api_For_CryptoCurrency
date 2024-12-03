
using Domain.Aggregates.CryptoCurrencyMaps.ValueObjects.Rules;

namespace Domain.Aggregates.CryptoCurrencyMaps.ValueObjects
{
    public class CryptoCurrencyName : ValueObject
    {
        private CryptoCurrencyName()
        {   
        }

        public string Value { get; private init; }


        public static CryptoCurrencyName Create(string value)
        {
            CheckRule(new CryptoCurrencyNameCannotBeEmptyRule(value));

            return new() { Value = value };
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
