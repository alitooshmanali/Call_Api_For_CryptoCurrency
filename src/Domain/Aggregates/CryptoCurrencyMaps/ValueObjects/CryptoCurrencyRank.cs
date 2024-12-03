
namespace Domain.Aggregates.CryptoCurrencyMaps.ValueObjects
{
    public class CryptoCurrencyRank : ValueObject
    {
        private CryptoCurrencyRank()
        {            
        }

        public int Value { get; private init; }

        public static CryptoCurrencyRank Create(int value)
        {
            return new() { Value = value };
        }


        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
