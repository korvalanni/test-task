using Application.Services.Mediatr.CreateDeck;
using FluentValidation;

namespace Application.Services.Mediatr.GetDeck;

public class GetDeckValidator : AbstractValidator<GetDeckCommand>
{
    public GetDeckValidator(DeckExistValidator existValidator)
    {
        RuleFor(name => name.Name).SetValidator(existValidator);
    }
}