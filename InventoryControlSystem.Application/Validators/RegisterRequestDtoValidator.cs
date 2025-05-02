using FluentValidation;
using InventoryControlSystem.Application.DTOS;

namespace InventoryControlSystem.Application.Validators
{
    public class RegisterRequestDtoValidator :AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo nome é obrigatório");

            RuleFor(x => x.Matricula)
                .NotEmpty().WithMessage("Matrícula é obrigatória.")
                .Length(6).WithMessage("A matrícula precisa ter 6 caracteres!");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("Senha é obrigatória.")
                .Matches(@"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$")
                .WithMessage("A senha deve conter ao menos 6 caracteres, uma letra maiúscula, um número e um caractere especial.");

            RuleFor(x => x.TipoUsuario)
                .IsInEnum().WithMessage("Tipo de usuário inválido.");
        }
    }
}
