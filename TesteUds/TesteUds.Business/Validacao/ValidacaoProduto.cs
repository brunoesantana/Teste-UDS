using System;
using TesteUds.Business.Dao;

namespace TesteUds.Business.Validacao
{
    public class ValidacaoProduto
    {
        private readonly ProdutoDao _produtoDao;

        public ValidacaoProduto()
        {
            _produtoDao = new ProdutoDao();
        }

        public void Validar(Produto produto)
        {
            if (string.IsNullOrWhiteSpace(produto.Codigo))
                throw new Exception("O código é obrigatório");

            if (string.IsNullOrWhiteSpace(produto.Nome))
                throw new Exception("O nome é obrigatório");

            if (produto.PrecoUnitario <= 0 || produto.PrecoUnitario > 9999999.99M)
                throw new Exception("O preço unitário deve estar entre R$ 0,01 e R$ 9999999,99.");

            if (_produtoDao.Exist(produto))
                throw new Exception("Já existe um produto cadastradao com esse código ou nome.");
        }
    }
}
