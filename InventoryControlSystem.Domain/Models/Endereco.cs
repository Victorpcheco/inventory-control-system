
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace InventoryControlSystem.Domain.Models
{
    public class Endereco
    {

        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }




        public Endereco(string logradouro, int numero, string bairro, string cidade, string estado, string cep, string complemento)
        {
            if (string.IsNullOrWhiteSpace(logradouro))
                throw new ArgumentException("O logradouro não pode ser nulo ou vazio.", nameof(logradouro));
            if (string.IsNullOrWhiteSpace(bairro))
                throw new ArgumentException("O bairro não pode ser nulo ou vazio.", nameof(bairro));
            if (string.IsNullOrWhiteSpace(cidade))
                throw new ArgumentException("A cidade não pode ser nula ou vazia.", nameof(cidade));
            if (string.IsNullOrWhiteSpace(estado) || estado.Length != 2 || !Regex.IsMatch(estado, "^[A-Z]{2}$"))
                throw new ArgumentException("O estado deve conter exatamente 2 letras maiúsculas, como 'SP' ou 'RJ'.", nameof(estado));
            if (string.IsNullOrWhiteSpace(cep) || !Regex.IsMatch(cep, @"^\d{5}-\d{3}$"))
                throw new ArgumentException("O CEP deve estar no formato 'XXXXX-XXX'.", nameof(cep));

            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Complemento = complemento;
        }

    }
}
