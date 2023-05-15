using Domain;
using Domain.Deck;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Infrastructure;

public interface IDeckRepository
{
    Task<Deck?> Get(string requestDeckName);
    Task Add(Deck deck);
}