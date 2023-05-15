using Application.Models;

namespace DeckService.Requests;

public record CreateDeckRequest(DeckType Type);