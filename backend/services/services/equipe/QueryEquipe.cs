using services.gateways.repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace services.services.equipe
{
    public class QueryEquipe
    {
        private readonly EquipeRepository repository;

        public QueryEquipe(EquipeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<dynamic>> GetEquipesByFazendaId(Guid fazendaId)
        {
            return await repository.GetAll(true)
                .Where(c => c.Ativo && c.FazendaId == fazendaId)
                .Select(c => new
                {
                    c.Id,
                    c.Nome,
                }).ToListAsync<dynamic>();
        }
    }
}
