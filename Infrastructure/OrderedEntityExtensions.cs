using Domain;

namespace Infrastructure;

public static class OrderedEntityExtensions
{
    public static void ChangeOrders(this IEnumerable<IOrderedEntity> shuffledEntities)
    {
        var i = 0;
        foreach (var entity in shuffledEntities)
        {
            entity.SetOrder(i);
            i++;
        }
    }
}