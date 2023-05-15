using FluentValidation;
using Infrastructure;

namespace Application.Services.Mediatr.CreateDeck;

public class CreateDeckValidator : AbstractValidator<CreateDeckCommand>
{
    public CreateDeckValidator(IDeckRepository repository)
    {
        RuleFor(command => command.DeckName)
            .MustAsync(
                async (name, ct) =>
                {
                    var deck = await repository.Get(name);
                    return deck is null;
                })
            .WithMessage("Колода с данным именем уже существует");
    }
}