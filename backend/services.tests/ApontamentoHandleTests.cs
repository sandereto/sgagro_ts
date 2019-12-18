using System;
using System.Collections.Generic;
using System.Text;
using gateways.repositories;
using Moq;
using Xunit;
using entities;
using entities.rehagro;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using services.gateways.repositories;

namespace services.tests
{
    public class ApontamentoHandleTests
    {
        private static EFApplicationContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<EFApplicationContext>()
                              .UseInMemoryDatabase(Guid.NewGuid().ToString())
                              .Options;
            var context = new EFApplicationContext(options);

            var beerCategory = new Apontamento { };
            var wineCategory = new Apontamento { };
            context.ApontamentoSet.Add(beerCategory);
            context.ApontamentoSet.Add(wineCategory);
            context.SaveChanges();

            return context;
        }

        [Fact]
        public void TESTE_INICIAL_MOCK_REPOSITORY()
        {
            var pmeId = Guid.NewGuid();

            var repository = new ApontamentoRepository(GetContextWithData());

            //var teste = repository.Get(pmeId);

            var all = repository.GetAll().ToList();
        }
    }
}
