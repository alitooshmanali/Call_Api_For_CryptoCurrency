using Domain.Tests.Aggregates.CryptoCurrencyMaps.Builders;

namespace Domain.Tests.Aggregates.CryptoCurrencyMaps.ValueObjects
{
    public class CryptoCurrencySymbolTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void TestCreate_WhenValueIsNullOrWhiteSpace_MustReturnNull(string value)
        {
            // arrang
            // act
            var action = new Action(() => new CryptoCurrencySymbolBuilder()
                .WithValue(value)
                .Build());

            // assert
            action.Should().Throw<DomainException>()
                .WithMessage(DomainResources.CryptoCurrency_Symbol_CannotBeEmpty);
        }


        [Fact]
        public void TestEquality_WhenEverythingIsOk_MustBeTrue()
        {
            const string value = "NMC";
            var first = new CryptoCurrencySymbolBuilder()
                .WithValue(value)
                .Build();
            var second = new CryptoCurrencySymbolBuilder()
                .WithValue(value)
                .Build();

            first.Should().Be(second);
        }
    }
}
