using System.Collections.Concurrent;
using Domain.Deck;

namespace Infrastructure;

public class DeckRepository : IDeckRepository
{
    private readonly ConcurrentDictionary<string, Deck> decks = new();

    public DeckRepository()
    {
    }

    public Task<Deck?> Get(string requestDeckName)
    {
        return (decks.TryGetValue(requestDeckName, out var deck)
            ? Task.FromResult(deck)
#pragma warning disable CS8619
            : Task.FromResult((Deck?)null))!;
#pragma warning restore CS8619
    }

    public Task Add(Deck deck)
    {
        decks.TryAdd(deck.Name, deck);
        return Task.CompletedTask;
    }
}