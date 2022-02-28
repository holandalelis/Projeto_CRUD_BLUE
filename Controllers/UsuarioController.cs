using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsandoViews.Models;

namespace UsandoViews.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuariosContext _context;

        public UsuarioController(UsuariosContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.OrderBy(x => x.Nome).AsNoTracking().ToListAsync());
        }
        /*[HttpGet]
        public async Task<IActionResult> Cadastrar(int? id)
        {
            if (id.HasValue)
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
            return View(new Usuario());
        }

        private bool UsuarioExiste(int id)
        {
            return _context.Users.Any(x => x.IdUsuario == id);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(int? id, [FromForm] Usuario user)
        {
            if (ModelState.IsValid)
            {
                if (id.HasValue)
                {
                    if (UsuarioExiste(id.Value))
                    {
                        _context.Users.Update(user);
                        if (await _context.SaveChangesAsync() > 0)
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Usuário alterado com sucesso.");
                        }
                        else
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Erro ao alterar Usuário.", TipoMensagem.Erro);
                        }
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Usuário não encontrado.", TipoMensagem.Erro);
                    }
                }
                else
                {
                    _context.Users.Add(user);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Usuário cadastrado com sucesso.");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Erro ao cadastrar Usuário.", TipoMensagem.Erro);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(user);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            if (!id.HasValue)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Usuário não informado.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Categoria não encontrada.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                if (await _context.SaveChangesAsync() > 0)
                    TempData["mensagem"] = MensagemModel.Serializar("Usuário excluído com sucesso.");
                else
                    TempData["mensagem"] = MensagemModel.Serializar("Não foi possível excluir o Usuário.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Usuário não encontrado.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
        }*/
    }
}