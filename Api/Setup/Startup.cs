using System.Reflection;
using System.Text.Json.Serialization;
using Application.Models;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using Application.Services.Mediatr.CreateDeck;
using Application.Services.Mediatr.Deck;
using Application.Services.Mediatr.ShuffleDeck;
using AutoMapper;
using DeckService.Controllers;
using Domain.Deck;
using FluentValidation;
using Infrastructure;
using MediatR;

namespace DeckService.Setup
{
    public class Startup
    {
        private readonly ConfigurationManager builderConfiguration;

        public Startup(ConfigurationManager builderConfiguration)
        {
            this.builderConfiguration = builderConfiguration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            AddServices(services);
            AddMediator(services);
            AddMapper(services);
            AddRouting(services);
        }

        private static void AddRouting(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient(typeof (IPipelineBehavior<,>), typeof (ValidationBehaviour<,>));
            services.AddControllers()
                .AddApplicationPart(typeof (DeckController).Assembly)
                .AddControllersAsServices()
                .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
        }

        private static void AddMapper(IServiceCollection services)
        {
            services.AddSingleton<IMapper>(
                new Mapper(
                    new MapperConfiguration(
                        cfg
                            =>
                        {
                            cfg.CreateMap<Deck, DeckInfo>()
                                .ForMember(
                                    d => d.CardInfos,
                                    opt => opt.MapFrom(src => src.Cards));
                            cfg.CreateMap<Card, CardInfo>();
                        })));
        }

        private static void AddMediator(IServiceCollection services)
        {
            services.AddMediatR(
                configuration
                    =>
                {
                    configuration.RegisterServicesFromAssemblies(typeof (CreateDeckHandler).GetTypeInfo().Assembly);
                }
            );
            services.AddValidatorsFromAssembly(typeof (CreateDeckHandler).GetTypeInfo().Assembly);
            services.AddSingleton<IRequestHandler<ShuffleDeckCommand<ManualShuffleCommand>, DeckInfo>, ShuffleDeckHandler<ManualShuffleCommand>>();
            services.AddSingleton<IRequestHandler<ShuffleDeckCommand<FisherShuffleCommand>, DeckInfo>, ShuffleDeckHandler<FisherShuffleCommand>>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddSingleton<FisherShuffleService>()
                .AddSingleton<ManualShuffleService>()
                .AddSingleton<ShufflerFactory>()
                .AddSingleton<IDeckGeneratorService, DeckGeneratorService>()
                .AddSingleton<IDeckRepository, DeckRepository>();
        }
    }
}