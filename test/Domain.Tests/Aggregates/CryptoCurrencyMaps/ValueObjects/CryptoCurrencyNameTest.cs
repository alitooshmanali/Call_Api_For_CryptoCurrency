using Domain.Tests.Aggregates.CryptoCurrencyMaps.Builders;

namespace Domain.Tests.Aggregates.CryptoCurrencyMaps.ValueObjects
{
    public class CryptoCurrencyNameTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void TestCreate_WhenValueIsNullOrWhiteSpace_MustReturnNull(string value)
        {
            // arrang
            // act
            var action = new Action(() => new CryptoCurrencyNameBuilder()
                .WithValue(value)
                .Build());

            // assert
            action.Should().Throw<DomainException>()
                .WithMessage(DomainResources.CryptoCurrency_Name_CannotBeEmpty);
        }


        [Fact]
        public void TestEquality_WhenEverythingIsOk_MustBeTrue()
        {
            const string value = "Name";
            var first = new CryptoCurrencyNameBuilder()
                .WithValue(value)
                .Build();
            var second = new CryptoCurrencyNameBuilder()
                .WithValue(value)
                .Build();

            first.Should().Be(second);
        }

    }
}
