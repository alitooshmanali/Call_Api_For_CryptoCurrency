using Domain.Properties;

namespace Domain.Aggregates.CryptoCurrencyMaps.ValueObjects.Rules
{
    internal class CryptoCurrencyNameCannotBeEmptyRule : IBusinessRule
    {
        private readonly string value;

        public CryptoCurrencyNameCannotBeEmptyRule(string value)
        {
            this.value = value;
        }

        public string Message => DomainResources.CryptoCurrency_Name_CannotBeEmpty;

        public bool IsBroken() => string.IsNullOrWhiteSpace(value);
    }
}
