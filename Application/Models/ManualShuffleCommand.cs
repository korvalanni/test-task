namespace Application.Models;

public class ManualShuffleCommand : IShuffleCommand
{
    public List<int> EntityLayout { get; set; } = null!;
}