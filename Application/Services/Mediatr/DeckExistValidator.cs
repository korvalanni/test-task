using FluentValidation;
using Infrastructure;

namespace Application.Services.Mediatr;

public class DeckExistValidator : AbstractValidator<string>
{
    public DeckExistValidator(IDeckRepository repository)
    {
        RuleFor(name => name)
            .MustAsync(
                async (name, ct) =>
                {
                    var deck = await repository.Get(name);
                    return deck is not null;
                })
            .WithMessage("Колода с данным именем не существует");
    }
}