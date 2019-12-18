using services.gateways.repositories;

namespace services.services.unidade
{
    public class QueryUnidade
    {
        private readonly UnidadeRepository repository;

        public QueryUnidade(UnidadeRepository repository)
        {
            this.repository = repository;
        }
    }
}
