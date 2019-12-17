using System;
using System.Threading;
using System.Threading.Tasks;
using services.commands.cadastros;
using core.bus;
using MediatR;
using entities.rehagro;
using core.seedwork;
using services.gateways.repositories;
using events.cadastros;

namespace services.ommandHandlers
{
    public class HandlerApontamento : CommandHandler,
        IRequestHandler<ReadApontamentoCommand, Response>,
        IRequestHandler<CreateApontamentoCommand, Response>,
        IRequestHandler<UpdateApontamentoCommand, Response>,
        IRequestHandler<DeleteApontamentoCommand, Response>
    {
        private readonly ApontamentoRepository repository;
        private readonly IMediatorHandler Bus;

        public HandlerApontamento(IMediatorHandler bus, ApontamentoRepository repository)
        {
           Bus = bus;
           this.repository = repository;
        }

        public async Task<Response> Handle(ReadApontamentoCommand message, CancellationToken cancellationToken)
        {
            var paginate = repository.Paginate(message);
            
            return await Task.FromResult(new Response(paginate));
        }

        public async Task<Response> Handle(CreateApontamentoCommand message, CancellationToken cancellationToken)
        {
            return await  ExecuteAsync(async () => {

                var entidade = new Apontamento();

                await repository.CreateAsync(entidade);

                if (await repository.CommitAsync())
                {
                    await Bus.RaiseEvent(new ApontamentoCreatedEvent(entidade.Id));
                }

                return await Task.FromResult(new Response());

            });
        }

        public async Task<Response> Handle(UpdateApontamentoCommand message, CancellationToken cancellationToken)
        {
            var entidade = new Apontamento();

            repository.Update(entidade);

            if (await repository.CommitAsync())
            {
                await Bus.RaiseEvent(new ApontamentoUpdatedEvent(entidade.Id));
            }

            return await Task.FromResult(new Response());
        }

        public async Task<Response> Handle(DeleteApontamentoCommand message, CancellationToken cancellationToken)
        {
            repository.Delete(message.Id);

            if (await repository.CommitAsync())
            {
                await Bus.RaiseEvent(new ApontamentoDeletedEvent(message.Id));
            }

            return await Task.FromResult(new Response());
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
