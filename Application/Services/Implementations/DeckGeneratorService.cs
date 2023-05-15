using Application.Models;
using Application.Services.Interfaces;
using Domain.Deck;

namespace Application.Services.Implementations;

public class DeckGeneratorService : IDeckGeneratorService
{
    public Deck GenerateDeck(DeckType deckType, string deckName)
    {
        var cards = new List<Card>();
        var deckBorder = GetDeckBorder(deckType);
        int order = 0;
        for (int i = deckBorder.left; i < deckBorder.right; i++)
        {
            for (var j = 0; j < 4; j++)
            {
                cards.Add(new Card((CardValue)i, (CardSuit)j, order));
                order++;
            }
        }

        return new Deck(cards, deckName);
    }

    private (int left, int right) GetDeckBorder(DeckType deckType)
    {
        return deckType switch
        {
            DeckType.Standard => (2, 15),
            DeckType.Pocker => (6, 14),
            _ => throw new ArgumentOutOfRangeException(nameof(deckType), deckType, null)
        };
    }
}