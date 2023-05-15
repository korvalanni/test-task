using Application.Models;
using Application.Services.Interfaces;
using Application.Services.Mediatr.ShuffleDeck;

namespace Application.Services.Implementations;

public class ShufflerFactory
{
    private readonly FisherShuffleService fisherShuffleService;
    private readonly ManualShuffleService manualShuffleService;

    public ShufflerFactory(FisherShuffleService fisherShuffleService, ManualShuffleService manualShuffleService)
    {
        this.fisherShuffleService = fisherShuffleService;
        this.manualShuffleService = manualShuffleService;
    }

    public IShuffleService<T>? GetShuffler<T>(T command)
        where T : IShuffleCommand
    {
        return command switch
        {
            FisherShuffleCommand _ => fisherShuffleService as IShuffleService<T>,
            ManualShuffleCommand _ => manualShuffleService as IShuffleService<T>,
            _ => throw new ArgumentException("Invalid shuffle command")
        };
    }
}