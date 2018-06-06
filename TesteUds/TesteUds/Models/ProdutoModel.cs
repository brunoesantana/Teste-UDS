using System.Collections.Generic;
using TesteUds.Business;
using TesteUds.Business.Dao;
using TesteUds.Business.Validacao;

namespace TesteUds.Models
{
    public class ProdutoModel
    {
        private readonly ProdutoDao _produtoDao;
        private readonly ValidacaoProduto _validacaoProduto;

        public List<ProdutoViewModel> Produtos { get; set; }
        public ProdutoFiltroViewModel Filtro { get; set; }

        public ProdutoModel()
        {
            _produtoDao = new ProdutoDao();
            _validacaoProduto = new ValidacaoProduto();
        }

        public ProdutoViewModel ObterProduto(int id)
        {
            var produto = _produtoDao.Get(id);

            return MapearProdutoViewModel(produto);
        }

        public void CarregarProdutos()
        {
            this.Produtos = new List<ProdutoViewModel>();
            var produtos = _produtoDao.GetAll();

            foreach (var produto in produtos)
                this.Produtos.Add(MapearProdutoViewModel(produto));
        }

        public void PesquisarProdutos(ProdutoFiltroViewModel filtro)
        {
            this.Produtos = new List<ProdutoViewModel>();
            var produtos = _produtoDao.GetList(MapearFiltroProduto(filtro));

            foreach (var produto in produtos)
                this.Produtos.Add(MapearProdutoViewModel(produto));
        }

        public void Inserir(ProdutoViewModel produtoVewModel)
        {
            var produto = MapearProduto(produtoVewModel);
            _validacaoProduto.Validar(produto);
            _produtoDao.Insert(produto);
        }

        public void Editar(ProdutoViewModel produtoVewModel)
        {
            var produto = MapearProduto(produtoVewModel);
            _validacaoProduto.Validar(produto);
            _produtoDao.Update(produto);
        }

        public void Excluir(int id)
        {
            var produto = _produtoDao.Get(id);
            _produtoDao.Delete(produto);
        }

        private ProdutoViewModel MapearProdutoViewModel(Produto produto)
        {
            return new ProdutoViewModel
            {
                Id = produto.Id,
                Codigo = produto.Codigo,
                Nome = produto.Nome,
                PrecoUnitario = produto.PrecoUnitario
            };
        }

        private Produto MapearProduto(ProdutoViewModel produtoVewModel)
        {
            return new Produto
            {
                Id = produtoVewModel.Id,
                Codigo = produtoVewModel.Codigo,
                Nome = produtoVewModel.Nome,
                PrecoUnitario = produtoVewModel.PrecoUnitario.Value
            };
        }

        private Produto MapearFiltroProduto(ProdutoFiltroViewModel filtro)
        {
            return new Produto
            {
                Codigo = filtro.Codigo,
                Nome = filtro.Nome,
                PrecoUnitario = filtro.PrecoUnitario
            };
        }
    }
}