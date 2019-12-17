using System;
using System.Collections.Generic;
using System.Text;
using core.commands;

namespace services.commands.cadastros
{
    public class CreateApontamentoCommand : ApontamentoCommand
    {
        public CreateApontamentoCommand(string nome, string cnpj)
        {
            Nome = nome;
            Cnpj = cnpj;
        }
    }
}
