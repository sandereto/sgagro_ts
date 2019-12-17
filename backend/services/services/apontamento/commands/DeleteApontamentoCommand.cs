using System;
using entities.rehagro;

namespace services.commands.cadastros
{
    public class DeleteApontamentoCommand : ApontamentoCommand
    {
        public DeleteApontamentoCommand(Guid id)
        {
            Id = id;
        }
    }
}
