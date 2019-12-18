using System;
using entities;
using entities.rehagro;
using core.seedwork;

namespace services.gateways.repositories
{
    public class ApontamentoRepository : Repository<Apontamento, Guid>
    {
        public ApontamentoRepository(EFApplicationContext context) : base(context)
        {

        }
    }
}
