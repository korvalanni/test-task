namespace Domain;

public interface IOrderedEntity
{
    public int Order { get; }
    public int SetOrder(int order);
}