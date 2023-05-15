using Application.Models;
using Domain.Deck;

namespace Application.Services.Interfaces;

public interface IDeckGeneratorService
{
    Deck GenerateDeck(DeckType deckType, string deckName);
}