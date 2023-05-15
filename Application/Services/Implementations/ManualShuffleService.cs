using Application.Models;
using Application.Services.Interfaces;
using Domain;
using Infrastructure;

namespace Application.Services.Implementations;

public class ManualShuffleService : IShuffleService<ManualShuffleCommand>
{
    public List<IOrderedEntity> Shuffle(IReadOnlyCollection<IOrderedEntity> orderedEntities, ManualShuffleCommand shuffleCommand)
    {
        var count = orderedEntities.Count;
        var result = new List<IOrderedEntity>(orderedEntities);
        foreach (var layout in shuffleCommand.EntityLayout)
        {
            var breakDown = layout%count;
            var left = result.Take(breakDown).ToList();
            var right = result.Skip(breakDown).ToList();
            result = right.Concat(left).ToList();
        }

        result.ChangeOrders();
        return result;
    }
}