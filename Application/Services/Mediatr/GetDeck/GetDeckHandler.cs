using Application.Services.Mediatr.Deck;
using AutoMapper;
using Infrastructure;
using MediatR;

namespace Application.Services.Mediatr.GetDeck;

public class GetDeckHandler : IRequestHandler<GetDeckCommand, DeckInfo>
{
    private readonly IDeckRepository deckRepository;
    private readonly IMapper mapper;

    public GetDeckHandler(IDeckRepository deckRepository, IMapper mapper)
    {
        this.deckRepository = deckRepository;
        this.mapper = mapper;
    }

    public async Task<DeckInfo> Handle(GetDeckCommand request, CancellationToken cancellationToken)
    {
        var deck = await deckRepository.Get(request.Name);
        return mapper.Map<DeckInfo>(deck);
    }
}

public record GetDeckCommand(string Name) : IRequest<DeckInfo>;