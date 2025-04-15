
using System.Text.RegularExpressions;
using InventoryControlSystem.Domain.Enums;

namespace InventoryControlSystem.Domain.Models
{
    public class Usuario
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;


        public Usuario(string nome, string matricula, string senha)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("O campo nome não pode ser nulo ou vazio!");

            if (string.IsNullOrWhiteSpace(matricula) || matricula.Length < 6)
                throw new ArgumentException("Matrícula deve ter no mínimo 6 caracteres");

            if (!Regex.IsMatch(senha, @"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$"))
                throw new ArgumentException("A senha deve conter ao menos 6 caracteres, uma letra maiúscula, um número e um caractere especial");

            Nome = nome;
            Matricula = matricula;
            Senha = senha;
            DataCadastro = DateTime.UtcNow;

        }

    }
}
