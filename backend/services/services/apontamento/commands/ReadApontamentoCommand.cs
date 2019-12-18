using entities;
using MediatR;
using core.seedwork;
using entities.rehagro;

namespace services.commands.cadastros
{
    public class ReadApontamentoCommand : BasePaginateSpecification<Apontamento>, IRequest<Response>
    {
        /// <summary>
        /// Nosso número
        /// </summary>
        public string NossoNumero { get; set; }

        /// <summary>
        /// Número do título
        /// </summary>
        public string Numero { get; set; }
        
        public ReadApontamentoCommand()
        {

        }

        public override void Build()
        {
            //if (!string.IsNullOrEmpty(NossoNumero))
            //{
            //    Criterias.Add(c => c.NossoNumero.Contains(NossoNumero));
            //}

            //AddInclude(c => c.Especie);
        }
    }
}
