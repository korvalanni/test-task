using Application.Models;
using FluentValidation;

namespace Application.Services.Mediatr.ShuffleDeck;

public class FisherShuffleDeckValidator : AbstractValidator<ShuffleDeckCommand<FisherShuffleCommand>>
{
    public FisherShuffleDeckValidator(DeckExistValidator existValidator)
    {
        RuleFor(command => command.DeckName).SetValidator(existValidator);
    }
}