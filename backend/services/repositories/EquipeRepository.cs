using System;
using entities;
using entities.rehagro;
using core.seedwork;

namespace services.gateways.repositories
{
    public class EquipeRepository : Repository<Equipe, Guid>
    {
        public EquipeRepository(EFApplicationContext context) : base(context)
        {

        }
    }
}
