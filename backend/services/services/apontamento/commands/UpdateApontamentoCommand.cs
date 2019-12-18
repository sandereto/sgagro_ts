using System;
using System.Collections.Generic;
using System.Text;

namespace services.commands.cadastros
{
    public class UpdateApontamentoCommand : ApontamentoCommand
    {
        public UpdateApontamentoCommand(Guid id, string nome, string cnpj)
        {
            Id = id;
            Nome = nome;
            Cnpj = cnpj;
        }
    }
}
