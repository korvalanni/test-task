using JetBrains.Annotations;

namespace Application.Services.Mediatr.Deck;

public record DeckInfo
{
    [UsedImplicitly]
    public DeckInfo()
    {
    }

    public List<CardInfo> CardInfos { get; init; } = null!;
    public string Name { get; init; } = null!;
}