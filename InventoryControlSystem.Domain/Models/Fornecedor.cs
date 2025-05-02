using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryControlSystem.Domain.Models
{
    public class Fornecedor
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string CpfCnpj { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public int EnderecoId { get; private set; }

        [ForeignKey("EnderecoId")]
        public Endereco Endereco { get; private set; }

        protected Fornecedor() { } // Necessário para o EF

        public Fornecedor(string nome, string cpfCnpj, string email, string telefone = null)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O campo nome não pode ser nulo ou vazio!");

            if (string.IsNullOrWhiteSpace(cpfCnpj))
                throw new ArgumentException("O campo CPF/CNPJ não pode ser nulo ou vazio!");

            if (cpfCnpj.Length < 11 || cpfCnpj.Length > 14)
                throw new ArgumentException("O CPF/CNPJ deve ter entre 11 e 14 caracteres!");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O campo email não pode ser nulo ou vazio!");

            if (!new EmailAddressAttribute().IsValid(email))
                throw new ArgumentException("Email inválido");

            Nome = nome;
            CpfCnpj = cpfCnpj;
            Email = email;
            Telefone = telefone;
        }

        public void AtualizarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O campo nome não pode ser nulo ou vazio!");

            Nome = nome;
        }

        public void AtualizarTelefone(string telefone)
        {
            Telefone = telefone; // Pode incluir validações, se necessário
        }

        public void AtualizarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O campo email não pode ser nulo ou vazio!");

            if (!new EmailAddressAttribute().IsValid(email))
                throw new ArgumentException("Email inválido");

            Email = email;
        }

        public void AtualizarEndereco(Endereco endereco)
        {
            if (endereco == null)
                throw new ArgumentException("O endereço não pode ser nulo!");

            Endereco = endereco;
        }

        public void AtualizarCpfCnpj(string cpfCnpj)
        {
            if (string.IsNullOrWhiteSpace(cpfCnpj))
                throw new ArgumentException("O campo CPF/CNPJ não pode ser nulo ou vazio!");
            if (cpfCnpj.Length < 11 || cpfCnpj.Length > 14)
                throw new ArgumentException("O CPF/CNPJ deve ter entre 11 e 14 caracteres!");

            CpfCnpj = cpfCnpj;
        }
    }
}