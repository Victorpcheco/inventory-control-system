

using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryControlSystem.Domain.Models
{
    public class Fornecedor
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Telefone { get; set; }    
        public string Email { get; set; }
        public int EnderecoId { get; set; }

        [ForeignKey("EnderecoId")]
        public Endereco Endereco { get; set; }
        

        //public ICollection<Produto> Produtos { get; set; }

        public Fornecedor(string nome, string cpfCnpj, string email)
        {


            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O campo nome não pode ser nulo ou vazio!");

            if (string.IsNullOrWhiteSpace(cpfCnpj)) 
                throw new ArgumentException("O campo CPF/CNPJ não pode ser nulo ou vazio!");

            if (cpfCnpj.Length < 11 || cpfCnpj.Length > 14)
                throw new ArgumentException("O CPF/CNPJ deve ter entre 11 e 14 caracteres!");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O campo email, não pode ser nulo ou vazio!");

            if (!email.Contains("@") || !email.Contains("."))
                throw new ArgumentException("Email inválido");

            Nome = nome;
            CpfCnpj = cpfCnpj;
            Email = email; 

        }
      
    }
}
