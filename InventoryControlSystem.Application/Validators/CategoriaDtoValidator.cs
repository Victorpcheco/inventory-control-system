using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryControlSystem.Application.DTOS;

namespace InventoryControlSystem.Application.Validators
{
    public class CategoriaDtoValidator : AbstractValidator<CategoriaDto>
    {

        public CategoriaDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome da categoria é obrigatório.")
                .MinimumLength(3).WithMessage("O nome da categoria deve ter pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("O nome da categoria deve ter no máximo 50 caracteres.");
        }

    }
}
