using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TesteUds.Business.Dao
{
    public class ProdutoDao
    {
        private readonly Entities _context;

        public ProdutoDao()
        {
            _context = new Entities();
        }

        public Produto Get(int id)
        {
            return _context.Produtos.SingleOrDefault(p => p.Id == id);
        }

        public IList<Produto> GetList(Produto produto)
        {
            var produtos = _context.Produtos.AsQueryable<Produto>();

            if (!string.IsNullOrWhiteSpace(produto.Codigo))
                produtos = produtos.Where(p => p.Codigo == produto.Codigo);

            if (!string.IsNullOrWhiteSpace(produto.Nome))
                produtos = produtos.Where(p => p.Nome.Contains(produto.Nome));

            if (produto.PrecoUnitario > 0)
                produtos = produtos.Where(p => p.PrecoUnitario == produto.PrecoUnitario);

            return produtos.ToList();
        }

        public bool Exist(Produto produto)
        {
            return _context.Produtos.Any(p => p.Id != produto.Id && (p.Codigo == produto.Codigo || p.Nome == produto.Nome));
        }

        public IList<Produto> GetAll()
        {
            return _context.Produtos.ToList();
        }

        public void Insert(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Update(Produto produto)
        {
            var entry = _context.Entry(produto);

            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Unchanged;
                _context.Produtos.Attach(produto);
            }

            entry.State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void Delete(Produto produto)
        {
            _context.Produtos.Attach(produto);

            _context.Produtos.Remove(produto);

            _context.SaveChanges();
        }
    }
}
