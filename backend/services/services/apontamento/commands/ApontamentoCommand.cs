using System;
using core.commands;

namespace services.commands.cadastros
{
    public abstract class ApontamentoCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Cnpj { get; set; }

        public string Nome { get; set; }
    }
}
