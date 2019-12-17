using System;
using System.Collections.Generic;
using System.Text;
using services.commands.cadastros;

namespace services.cadastros.validations
{
    public class CreateApontamentoValidation : ApontamentoValidation<CreateApontamentoCommand>
    {
        public CreateApontamentoValidation()
        {
            ValidateName();
        }
    }
}
