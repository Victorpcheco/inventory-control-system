using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InventoryControlSystem.Application.DTOS;

namespace InventoryControlSystem.Application.Validators
{
    public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
    {

        public LoginRequestDtoValidator()
        {
            RuleFor(x => x.Matricula)
               .NotEmpty().WithMessage("A matrícula é obrigatória.")
               .MinimumLength(6).WithMessage("A matrícula deve ter pelo menos 6 caracteres.");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$")
                .WithMessage("A senha deve conter pelo menos uma letra maiúscula, uma letra minúscula e um número.");

        }
    }
}
