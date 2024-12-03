using Domain.Tests.Aggregates.CryptoCurrencyMaps.Builders;

namespace Domain.Tests.Aggregates.CryptoCurrencyMaps.ValueObjects
{
    public class CryptoCurrencyRankTest
    {
        [Fact]
        public void TestCreate_WhenEverythingIsOk_PropertiesShouldHaveCorrectValues()
        {
            // arrange
            var rank = new Random().Next(1, 9999);

            // act
            var cryptoCurrencyRank = new CryptoCurrencyRankBuilder()
                .WithValue(rank)
                .Build();

            // assert 

            cryptoCurrencyRank.Value.Should().Be(rank);
        }

        [Fact]
        public void TestEquality_WhenEverythingIsOk_MustBeTrue()
        {
            int value = new Random().Next(1, 9999);

            var first = new CryptoCurrencyRankBuilder()
                .WithValue(value)
                .Build();
            var second = new CryptoCurrencyRankBuilder()
                .WithValue(value)
                .Build();

            first.Should().Be(second);
        }

    }
}
