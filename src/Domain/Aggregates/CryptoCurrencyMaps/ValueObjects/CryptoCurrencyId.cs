
namespace Domain.Aggregates.CryptoCurrencyMaps.ValueObjects
{
    public class CryptoCurrencyId : ValueObject
    {
        private CryptoCurrencyId()
        {   
        }

        public Guid Value { get; private init; }

        public static CryptoCurrencyId Create(Guid value)
        {
            return new() { Value = value };
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
