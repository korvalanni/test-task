using Domain;

namespace Application.Services.Interfaces;

public interface IShuffleService<T>
{
    public List<IOrderedEntity> Shuffle(IReadOnlyCollection<IOrderedEntity> orderedEntities, T shuffleCommand);
}