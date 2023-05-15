using Application.Services.Mediatr.Deck;
using AutoMapper;
using Domain.Deck;
using FluentAssertions;

namespace UnitTests;

public class MapperTests
{
    private Mapper mapper;

    [SetUp]
    public void Setup()
    {
        mapper = new Mapper(
            new MapperConfiguration(
                cfg
                    =>
                {
                    cfg.CreateMap<Deck, DeckInfo>()
                        .ForMember(
                            d => d.CardInfos,
                            opt => opt.MapFrom(src => src.Cards));
                    cfg.CreateMap<Card, CardInfo>();
                }));
    }

    [Test]
    public void Should_MapCard_To_CardInfo()
    {
        var card = new Card(CardValue.Ace, CardSuit.Clubs, 0);
        var cardInfo = mapper.Map<CardInfo>(card);
        cardInfo.Suit.Should().Be(CardSuit.Clubs);
        cardInfo.Value.Should().Be(CardValue.Ace);
    }

    [Test]
    public void Should_MapDeck_To_DeckInfo()
    {
        var deck = new Deck(new List<Card>() { new Card(CardValue.Ace, CardSuit.Clubs, 0) }, "test");
        var deckInfo = mapper.Map<DeckInfo>(deck);
        deckInfo.CardInfos.Count.Should().Be(1);
        deckInfo.Name.Should().Be("test");
    }
}