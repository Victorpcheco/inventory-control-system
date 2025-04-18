
namespace InventoryControlSystem.Domain.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }   
        public int QuantidadeEmEstoque { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public DateTime DataCadastroProduto { get; set; } = DateTime.UtcNow;

        public Produto() { }

        public Produto(string nome, int quantidadeEmEstoque, decimal preco)
        {


            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O campo nome não pode ser nulo ou vazio!");

            if (quantidadeEmEstoque <= 0)
                throw new ArgumentException("A quantidade em estoque precisa ser superior a 0 para cadastro!");

            if (preco <= 0)
                throw new ArgumentException("O preço precisa ser superior a 0 para cadastro!");

            Nome = nome;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            Preco = preco;
            DataCadastroProduto = DateTime.UtcNow;

        }

    }
}
