namespace Domain.Deck;

public class Card : IOrderedEntity
{
    public Card(CardValue value, CardSuit suit, int order)
    {
        Value = value;
        Suit = suit;
        Order = order;
    }

    public int Order { get; private set; }
    public CardValue Value { get; init; }
    public CardSuit Suit { get; init; }

    public int SetOrder(int order)
    {
        Order = order;
        return order;
    }
}