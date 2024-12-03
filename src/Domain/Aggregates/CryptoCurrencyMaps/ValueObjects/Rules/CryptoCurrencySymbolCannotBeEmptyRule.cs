using Domain.Properties;

namespace Domain.Aggregates.CryptoCurrencyMaps.ValueObjects.Rules
{
    internal class CryptoCurrencySymbolCannotBeEmptyRule : IBusinessRule
    {
        private readonly string value;

        public CryptoCurrencySymbolCannotBeEmptyRule(string value)
        {
            this.value = value;
        }
        public string Message => DomainResources.CryptoCurrency_Symbol_CannotBeEmpty;

        public bool IsBroken() => string.IsNullOrWhiteSpace(value);
    }
}
