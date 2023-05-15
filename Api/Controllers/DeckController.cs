using Application.Models;
using Application.Services.Mediatr.CreateDeck;
using Application.Services.Mediatr.Deck;
using Application.Services.Mediatr.GetDeck;
using Application.Services.Mediatr.ShuffleDeck;
using DeckService.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeckService.Controllers
{
    public class DeckController : ApiBaseController
    {
        private readonly ISender sender;

        public DeckController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpGet("{name}")]
        [ProducesResponseType(typeof (DeckInfo), 200)]
        [ProducesResponseType(typeof (DeckInfo), 400)]
        public async Task<DeckInfo?> GetByName([FromRoute] string name, CancellationToken ct)
        {
            var command = new GetDeckCommand(name);
            return await sender.Send(command, ct);
        }

        [HttpPost("{name}/shuffle/manual")]
        [ProducesResponseType(typeof (DeckInfo), 200)]
        [ProducesResponseType(typeof (DeckInfo), 404)]
        public async Task<DeckInfo?> ShuffleManually([FromBody] ManualShuffleRequest shuffleRequest, [FromRoute] string name, CancellationToken ct)
        {
            var command = new ShuffleDeckCommand<ManualShuffleCommand>(shuffleRequest.Command, name);
            return await sender.Send(command, ct);
        }

        [HttpPost("{name}/shuffle/fisher")]
        [ProducesResponseType(typeof (DeckInfo), 200)]
        [ProducesResponseType(typeof (DeckInfo), 400)]
        public async Task<DeckInfo?> ShuffleManually([FromBody] FisherShuffleRequest shuffleRequest, [FromRoute] string name, CancellationToken ct)
        {
            var command = new ShuffleDeckCommand<FisherShuffleCommand>(shuffleRequest.Command, name);
            return await sender.Send(command, ct);
        }

        [HttpPost("{name}")]
        [ProducesResponseType(typeof (DeckInfo), 200)]
        [ProducesResponseType(typeof (DeckInfo), 400)]
        public async Task<DeckInfo?> GetByName([FromBody] CreateDeckRequest createRequest, [FromRoute] string name, CancellationToken ct)
        {
            var command = new CreateDeckCommand(createRequest.Type, name);
            return await sender.Send(command, ct);
        }
    }
}