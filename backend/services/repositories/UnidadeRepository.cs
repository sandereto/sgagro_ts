using System;
using entities;
using entities.rehagro;
using core.seedwork;

namespace services.gateways.repositories
{
    public class UnidadeRepository : Repository<Unidade, Guid>
    {
        public UnidadeRepository(EFApplicationContext context) : base(context)
        {

        }
    }
}
