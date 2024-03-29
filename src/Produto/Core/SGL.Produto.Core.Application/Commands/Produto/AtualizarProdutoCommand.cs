﻿using SGL.Produto.Core.Application.Commands.Produto.Validation;
using SGL.Resource.Messagens;

namespace SGL.Produto.Core.Application.Commands.Produto
{
    public class AtualizarProdutoCommand : CommandHandler
    {
        public Guid Id { get; private set; }
        public Guid FornecedorId { get; private set; }
        public int CategoriaId { get; private set; }
        public string? Descricao { get; private set; }
        public decimal PrecoCompra { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public decimal MargemLucro { get; private set; }
        public int Estoque { get; private set; }
        public bool Situacao { get; private set; }

        public AtualizarProdutoCommand() { }

        public AtualizarProdutoCommand(
            Guid id,
            Guid fornecedorId,
            int categoriaId,
            string? descricao,
            decimal precoCompra,
            decimal precoVenda,
            decimal margemLucro,
            int estoque,
            bool situacao)
        {
            Id = id;
            FornecedorId = fornecedorId;
            CategoriaId = categoriaId;
            Descricao = descricao;
            PrecoCompra = precoCompra;
            PrecoVenda = precoVenda;
            MargemLucro = margemLucro;
            Estoque = estoque;
            Situacao = situacao;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarProdutoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
