using Domain.Aggregates.CryptoCurrencyMaps.Events;
using Domain.Tests.Aggregates.CryptoCurrencyMaps.Builders;
using Domain.Tests.Helper;

namespace Domain.Tests.Aggregates.CryptoCurrencyMaps
{
    public class CryptoCurrencyMapTest
    {
        [Fact]
        public void TestChangeRank_WhenEverythingIsOk_ValueMustBeSet()
        {
            // arrange
            int oldRank = new Random().Next(1, 9999);
            int newRank = new Random().Next(1, 9999);
            var cryptoCurrencyId = Guid.NewGuid();
            var cryptoCurrencyMap = new CryptoCurrencyMapBuilder()
                .WithId(cryptoCurrencyId)
                .WithRank(oldRank)
                .Build();

            cryptoCurrencyMap.ClearEvents();

            // act
            cryptoCurrencyMap.ChangeRank(new CryptoCurrencyRankBuilder().WithValue(newRank).Build());


            // assert
            var rankChangedEvent = cryptoCurrencyMap.AssertPublishedDomainEvent<CryptoCurrencyRankChangedEvent>();

            rankChangedEvent.AggregateId.Should().Be(cryptoCurrencyId);
            rankChangedEvent.OldValue.Should().Be(oldRank);
            rankChangedEvent.NewValue.Should().Be(newRank);

            cryptoCurrencyMap.Rank.Value.Should().Be(newRank);
        }

        [Fact]
        public void TestChangeRank_WhenValueIsSame_NothingMustBeHappened()
        {
            // arange
            int rank = new Random().Next(1, 9999);
            var cryptoCurrencyMap = new CryptoCurrencyMapBuilder()                
                .WithRank(rank)
                .Build();

            cryptoCurrencyMap.ClearEvents();
            cryptoCurrencyMap.ChangeRank(new CryptoCurrencyRankBuilder().WithValue(rank).Build());

            cryptoCurrencyMap.DomainEvents.Should().BeEmpty();
        }

        [Fact]
        public void TestChangeName_WhenEverythingIsOk_ValueMustBeSet()
        {
            // arrange
            const string oldName = "CryptoCurrencyName";
            const string newName = "UpdateCryptoCurrencyName";
            var cryptoCurrencyId = Guid.NewGuid();
            var cryptoCurrencyMap = new CryptoCurrencyMapBuilder()
                .WithId(cryptoCurrencyId)
                .WithName(oldName)
                .Build();

            cryptoCurrencyMap.ClearEvents();

            // act
            cryptoCurrencyMap.ChangeName(new CryptoCurrencyNameBuilder().WithValue(newName).Build());


            // assert
            var nameChangedEvent = cryptoCurrencyMap.AssertPublishedDomainEvent<CryptoCurrencyNameChangedEvent>();

            nameChangedEvent.AggregateId.Should().Be(cryptoCurrencyId);
            nameChangedEvent.OldValue.Should().Be(oldName);
            nameChangedEvent.NewValue.Should().Be(newName);

            cryptoCurrencyMap.Name.Value.Should().Be(newName);
        }

        [Fact]
        public void TestChangeName_WhenValueIsSame_NothingMustBeHappened()
        {
            // arange
            const string name = "CryptoCurrencyName";
            var cryptoCurrencyMap = new CryptoCurrencyMapBuilder()
                .WithName(name)
                .Build();

            cryptoCurrencyMap.ClearEvents();
            cryptoCurrencyMap.ChangeName(new CryptoCurrencyNameBuilder().WithValue(name).Build());

            cryptoCurrencyMap.DomainEvents.Should().BeEmpty();
        }

        [Fact]
        public void TestChangeSymbol_WhenEverythingIsOk_ValueMustBeSet()
        {
            // arrange
            const string oldSymbol = "CryptoCurrencySymbol";
            const string newSymbol = "UpdateCryptoCurrencySymbol";
            var cryptoCurrencyId = Guid.NewGuid();
            var cryptoCurrencyMap = new CryptoCurrencyMapBuilder()
                .WithId(cryptoCurrencyId)
                .WithSymbol(oldSymbol)
                .Build();

            cryptoCurrencyMap.ClearEvents();

            // act
            cryptoCurrencyMap.ChangeSymbol(new CryptoCurrencySymbolBuilder().WithValue(newSymbol).Build());


            // assert
            var symbolChangedEvent = cryptoCurrencyMap.AssertPublishedDomainEvent<CryptoCurrencySymbolChangedEvent>();

            symbolChangedEvent.AggregateId.Should().Be(cryptoCurrencyId);
            symbolChangedEvent.OldValue.Should().Be(oldSymbol);
            symbolChangedEvent.NewValue.Should().Be(newSymbol);

            cryptoCurrencyMap.Symbol.Value.Should().Be(newSymbol);
        }

        [Fact]
        public void TestChangeSymbol_WhenValueIsSame_NothingMustBeHappened()
        {
            // arange
            const string symbol = "CryptoCurrencySymbol";
            var cryptoCurrencyMap = new CryptoCurrencyMapBuilder()
                .WithSymbol(symbol)
                .Build();

            cryptoCurrencyMap.ClearEvents();
            cryptoCurrencyMap.ChangeSymbol(new CryptoCurrencySymbolBuilder().WithValue(symbol).Build());

            cryptoCurrencyMap.DomainEvents.Should().BeEmpty();
        }

        [Fact]
        public void TestCreate_WhenEverythingIsOk_PropertiesShouldHaveCorrectValues()
        {
            const string name = "Bitcoin";
            const string symbol = "BTC";
            var cryptoCurrencyId = Guid.NewGuid();
            var rank = new Random().Next(1, 9999);

            var cryptoCurrencyMap = new CryptoCurrencyMapBuilder()
                .WithId(cryptoCurrencyId)
                .WithRank(rank)
                .WithName(name)
                .WithSymbol(symbol)
                .Build();

            var createdEvent = cryptoCurrencyMap.AssertPublishedDomainEvent<CryptoCurrencyMapCreatedEvent>();

            createdEvent.AggregateId.Should().Be(cryptoCurrencyId);
            createdEvent.Rank.Should().Be(rank);
            createdEvent.Name.Should().Be(name);
            createdEvent.Symbol.Should().Be(symbol);

            cryptoCurrencyMap.Id.Value.Should().Be(cryptoCurrencyId);
            cryptoCurrencyMap.Rank.Value.Should().Be(rank);
            cryptoCurrencyMap.Name.Value.Should().Be(name);
            cryptoCurrencyMap.Symbol.Value.Should().Be(symbol);
        }

        [Fact]
        public void TestDelete_WhenEverythingIsOk_MustBeMarkedAsDeleted()
        {
            var cryptoCurrencyMap = new CryptoCurrencyMapBuilder().Build();

            cryptoCurrencyMap.ClearEvents();
            cryptoCurrencyMap.Delete();

            var deletedEvent = cryptoCurrencyMap.AssertPublishedDomainEvent<CryptoCurrencyMapDeletedEvent>();

            deletedEvent.AggregateId.Should().Be(cryptoCurrencyMap.Id.Value);

            cryptoCurrencyMap.CanBeDeleted().Should().BeTrue();
            cryptoCurrencyMap.DomainEvents.Should().HaveCount(1);
        }

        [Fact]
        public void TestDelete_WhenAlreadyDeleted_ThrowsException()
        {
            var cryptoCurrencyMap = new CryptoCurrencyMapBuilder().Build();

            cryptoCurrencyMap.Delete();

            var action = new Action(() => cryptoCurrencyMap.Delete());

            action.Should().Throw<InvalidOperationException>();
        }

    }
}
