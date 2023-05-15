using Application.Models;
using Application.Services.Interfaces;
using Application.Services.Mediatr.Deck;
using AutoMapper;
using Infrastructure;
using MediatR;

namespace Application.Services.Mediatr.CreateDeck;

public class CreateDeckHandler : IRequestHandler<CreateDeckCommand, DeckInfo>
{
    private readonly IDeckGeneratorService deckGeneratorService;
    private readonly IDeckRepository deckRepository;
    private readonly IMapper mapper;

    public CreateDeckHandler(IDeckGeneratorService deckGeneratorService, IDeckRepository deckRepository, IMapper mapper)
    {
        this.deckGeneratorService = deckGeneratorService;
        this.deckRepository = deckRepository;
        this.mapper = mapper;
    }

    public async Task<DeckInfo> Handle(CreateDeckCommand request, CancellationToken cancellationToken)
    {
        var deck = deckGeneratorService.GenerateDeck(request.DeckType, request.DeckName);
        await deckRepository.Add(deck);
        return mapper.Map<DeckInfo>(deck);
    }
}

public record CreateDeckCommand(DeckType DeckType, string DeckName) : IRequest<DeckInfo>;