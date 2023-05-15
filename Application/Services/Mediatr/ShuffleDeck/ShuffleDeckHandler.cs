using Application.Models;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using Application.Services.Mediatr.Deck;
using AutoMapper;
using Domain.Deck;
using Infrastructure;
using MediatR;

namespace Application.Services.Mediatr.ShuffleDeck;

public class ShuffleDeckHandler<T> : IRequestHandler<ShuffleDeckCommand<T>, DeckInfo>
    where T : IShuffleCommand
{
    private readonly IDeckRepository deckRepository;
    private readonly IMapper mapper;
    private readonly ShufflerFactory shufflerFactory;

    public ShuffleDeckHandler(ShufflerFactory shufflerFactory, IDeckRepository deckRepository, IMapper mapper)
    {
        this.shufflerFactory = shufflerFactory;
        this.deckRepository = deckRepository;
        this.mapper = mapper;
    }

    public async Task<DeckInfo> Handle(ShuffleDeckCommand<T> request, CancellationToken cancellationToken)
    {
        var shuffler = shufflerFactory.GetShuffler(request.Command);
        if (shuffler == null)
        {
            throw new ArgumentException("Invalid shuffle command");
        }

        var deck = await deckRepository.Get(request.DeckName);
        var cards = shuffler.Shuffle(deck!.Cards, request.Command)
            .Select(c => c as Card)
            .ToList();
        deck.SetCards(cards!);
        await deckRepository.Add(deck);
        return mapper.Map<DeckInfo>(deck);
    }
}

public record ShuffleDeckCommand<T>(T Command, string DeckName) : IRequest<DeckInfo>
    where T : IShuffleCommand;