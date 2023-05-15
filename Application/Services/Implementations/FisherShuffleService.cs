using Application.Models;
using Application.Services.Interfaces;
using Domain;
using Infrastructure;

namespace Application.Services.Implementations;

public class FisherShuffleService : IShuffleService<FisherShuffleCommand>
{
    public List<IOrderedEntity> Shuffle(IReadOnlyCollection<IOrderedEntity> orderedEntities, FisherShuffleCommand shuffleCommand)
    {
        var random = new Random();
        var shuffledEntities = orderedEntities.OrderBy(x => random.Next()).ToList();
        shuffledEntities.ChangeOrders();
        return shuffledEntities;
    }
}