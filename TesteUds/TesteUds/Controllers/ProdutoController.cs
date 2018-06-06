using System;
using System.Web.Mvc;
using TesteUds.Models;

namespace TesteUds.Controllers
{
    public class ProdutoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new ProdutoModel();
            model.CarregarProdutos();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ProdutoFiltroViewModel filtro)
        {
            var model = new ProdutoModel();
            model.PesquisarProdutos(filtro);
            model.Filtro = filtro;

            return View(model);
        }

        [HttpGet]
        public ActionResult Novo()
        {
            var viewModel = new ProdutoViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new ProdutoModel();
                    model.Inserir(viewModel);

                    TempData["Mensagem"] = "Produto incluído com sucesso.";

                    return RedirectToAction("Index");
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError("", exception.Message);
                }
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var model = new ProdutoModel();
            var viewModel = model.ObterProduto(id);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new ProdutoModel();
                    model.Editar(viewModel);

                    TempData["Mensagem"] = "Produto alterado com sucesso.";

                    return RedirectToAction("Index");
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError("", exception.Message);
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public void Remover(int id)
        {
            var model = new ProdutoModel();

            model.Excluir(id);
        }
    }
}