using Microsoft.AspNetCore.Mvc;
using UsandoViews.Models;

namespace UsandoViews.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Opão de configuração de Subtitulo da págia via action da página
            //ViewBag.Subtitulo = "Página Principal";
            ViewBag.QtdeUsuarios = Usuario.Listagem.Count();
            return View();
        }

        //Parametro id da url é opcional, por isso deve ser do tipo anulável -?-
        //Quando não é passado na rota, esse parametro vai entrar como valor nulo
        [HttpGet]
        public IActionResult Cadastrar(int? id)
        {
            var usuario = new Usuario();
            if (id.HasValue && Usuario.Listagem.Any(u => u.IdUsuario == id))
            {
                usuario = Usuario.Listagem.Single(u => u.IdUsuario == id);
                return View(usuario);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            Usuario.Salvar(usuario);
            return RedirectToAction("Usuarios");
        }

        public IActionResult Usuarios()
        {
            return View(Usuario.Listagem);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            var usuario = new Usuario();
            if (id.HasValue && Usuario.Listagem.Any(u => u.IdUsuario == id))
            {
                usuario = Usuario.Listagem.Single(u => u.IdUsuario == id);
                return View(usuario);
            }
            return RedirectToAction("Usuarios");
        }

        [HttpPost]
        public IActionResult Excluir(Usuario usuario)
        {
            //Usando ViewBag ao reprocessar página - perde o valor passado
            //ViewBag.Excluiu = Usuario.Excluir(usuario.IdUsuario);

            //Não perde o valor ao reprocessar página - fica armazenado em cookies - tempo de vida é de uma requisição
            TempData["Excluiu"] = Usuario.Excluir(usuario.IdUsuario);

            return RedirectToAction("Usuarios");
        }
    }
}