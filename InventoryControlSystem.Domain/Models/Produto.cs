using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryControlSystem.Domain.Models
{
    public class Produto
    {
        public int Id { get; private set; }

        [Required, StringLength(100)]
        public string Nome { get; private set; }

        [Required, StringLength(255)]
        public string Descricao { get; private set; }

        [Range(0, int.MaxValue)]
        public int QuantidadeEmEstoque { get; private set; }

        [Range(0.01, double.MaxValue)]
        public decimal Preco { get; private set; }

        public int CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }

        public int FornecedorId { get; private set; }
        public Fornecedor Fornecedor { get; private set; }

        public DateTime DataCadastroProduto { get; private set; } = DateTime.UtcNow;

        protected Produto() { }

        public Produto(string nome, string descricao, int quantidadeEmEstoque, decimal preco, int categoriaId, int fornecedorId)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O campo nome não pode ser nulo ou vazio!");
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("O campo descrição não pode ser nulo ou vazio!");
            if (quantidadeEmEstoque < 0)
                throw new ArgumentException("A quantidade em estoque não pode ser negativa!");
            if (preco <= 0)
                throw new ArgumentException("O preço precisa ser superior a 0 para cadastro!");
            if (categoriaId <= 0)
                throw new ArgumentException("Categoria inválida!");
            if (fornecedorId <= 0)
                throw new ArgumentException("Fornecedor inválido!");

            Nome = nome;
            Descricao = descricao;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            Preco = preco;
            CategoriaId = categoriaId;
            FornecedorId = fornecedorId;
            DataCadastroProduto = DateTime.UtcNow;
        }

        public void AtualizarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode ser vazio ou nulo.", nameof(nome));
            Nome = nome;
        }

        public void AtualizarDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("Descrição não pode ser vazia ou nula.", nameof(descricao));
            Descricao = descricao;
        }

        public void AtualizarEstoque(int quantidade)
        {
            if (quantidade < 0)
                throw new ArgumentException("Quantidade em estoque não pode ser negativa.", nameof(quantidade));
            QuantidadeEmEstoque = quantidade;
        }

        public void AtualizarPreco(decimal preco)
        {
            if (preco <= 0)
                throw new ArgumentException("Preço deve ser maior que zero.", nameof(preco));
            Preco = preco;
        }

        public void AtualizarCategoria(int categoriaId)
        {
            if (categoriaId <= 0)
                throw new ArgumentException("CategoriaId deve ser maior que zero.", nameof(categoriaId));
            CategoriaId = categoriaId;
        }

        public void AtualizarFornecedor(int fornecedorId)
        {
            if (fornecedorId <= 0)
                throw new ArgumentException("FornecedorId deve ser maior que zero.", nameof(fornecedorId));
            FornecedorId = fornecedorId;
        }
    }
}