using System;
using System.Collections.Generic;
using System.Text;
using hateoas.infrastructure;
using entities.rehagro;

namespace services
{
    public class HateoasOptionsService : IHateoasOptionsService
    {
        public HateoasOptions GetHateoas()
        {
            var hateoas = new HateoasOptions();

            //Rotas Apontamento
            hateoas.AddLink<Apontamento>("get-person", p => new { id = p.Id })
            .AddLink<List<Apontamento>>("create-person")
            .AddLink<Apontamento>("update-person", p => new { id = p.Id })
            .AddLink<Apontamento>("delete-person", p => new { id = p.Id });

            return hateoas;
        }
    }
}
