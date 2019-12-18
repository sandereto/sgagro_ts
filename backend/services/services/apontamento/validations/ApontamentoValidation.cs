using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using services.commands.cadastros;

namespace services.cadastros.validations
{
    public abstract class ApontamentoValidation<T> : AbstractValidator<T> where T : ApontamentoCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }
    }
}
