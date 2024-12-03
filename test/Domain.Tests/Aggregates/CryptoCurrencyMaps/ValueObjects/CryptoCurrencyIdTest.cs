using Domain.Tests.Aggregates.CryptoCurrencyMaps.Builders;

namespace Domain.Tests.Aggregates.CryptoCurrencyMaps.ValueObjects
{
    public class CryptoCurrencyIdTest
    {
        [Fact]
        public void TestCreate_WhenEverythingIsOk_PropertiesShouldHaveCorrectValues()
        {
            // arrange
            var id = Guid.NewGuid();

            // act
            var cryptoCurrencyId = new CryptoCurrencyIdBuilder()
                .WithValue(id)
                .Build();

            // assert 

            cryptoCurrencyId.Value.Should().Be(id);
        }

        [Theory]
        [InlineData("37ABBF87-A96D-4593-A0C4-23FEC62D6559", true)]
        [InlineData("CD8BE2BC-982D-4258-9A2F-3AE3D967AA76", false)]
        public void TestEquality_WhenEverythingIsOk_ResultMustBeExpected(string value, bool result)
        {
            // arrange
            var first = new CryptoCurrencyIdBuilder()
                .WithValue(Guid.Parse("37ABBF87-A96D-4593-A0C4-23FEC62D6559"))
                .Build();

            var second = new CryptoCurrencyIdBuilder()
                .WithValue(Guid.Parse(value))
                .Build();

            first.Equals(second).Should().Be(result);
        }

    }
}
