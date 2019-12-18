using Autofac;
using services.gateways.repositories;
using hateoas.infrastructure;
using services.repositories;
using core.events;
using services.ommandHandlers;
using MediatR;
using events.cadastros;
using services.commands.cadastros;
using core.seedwork;
using core.bus;
using services.services.equipe;

namespace services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            // Infra
            containerBuilder.RegisterType<InMemoryBus>().As<IMediatorHandler>();

            containerBuilder.RegisterType<HateoasOptionsService>().As<IHateoasOptionsService>();
         
            
            //Repositories
            containerBuilder.RegisterType<ApontamentoRepository>().SingleInstance();
            containerBuilder.RegisterType<EquipeRepository>().SingleInstance();
            containerBuilder.RegisterType<StoredEventRepository>().SingleInstance();
            containerBuilder.RegisterType<EventStoreRepository>().As<IEventStore>().SingleInstance();

            //Queries
            containerBuilder.RegisterType<QueryEquipe>().SingleInstance();

            //Events
            containerBuilder.RegisterType<ApontamentoEventHandler>().As<INotificationHandler<ApontamentoCreatedEvent>>();
            containerBuilder.RegisterType<ApontamentoEventHandler>().As<INotificationHandler<ApontamentoUpdatedEvent>>();
            containerBuilder.RegisterType<ApontamentoEventHandler>().As<INotificationHandler<ApontamentoDeletedEvent>>();

            // Commands
            containerBuilder.RegisterType<HandlerApontamento>().As<IRequestHandler<ReadApontamentoCommand, Response>>();
            containerBuilder.RegisterType<HandlerApontamento>().As<IRequestHandler<CreateApontamentoCommand, Response>>();
            containerBuilder.RegisterType<HandlerApontamento>().As<IRequestHandler<UpdateApontamentoCommand, Response>>();
            containerBuilder.RegisterType<HandlerApontamento>().As<IRequestHandler<DeleteApontamentoCommand, Response>>();
        }
    }
}
