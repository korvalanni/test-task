namespace Domain.Deck;

public class Deck
{
    public Deck(List<Card> cards, string name)
    {
        _cards = cards;
        Name = name;
    }

    public IReadOnlyCollection<Card> Cards => _cards;
    public string Name { get; set; }
    private List<Card> _cards { get; set; }

    public void SetCards(List<Card> cards)
    {
        _cards = cards;
    }
}