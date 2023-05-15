using Application.Models;
using Application.Services.Mediatr.CreateDeck;
using FluentValidation;

namespace Application.Services.Mediatr.ShuffleDeck;

public class ManualShuffleDeckValidator : AbstractValidator<ShuffleDeckCommand<ManualShuffleCommand>>
{
    public ManualShuffleDeckValidator(DeckExistValidator existValidator)
    {
        RuleFor(command => command.DeckName).SetValidator(existValidator);
    }
}