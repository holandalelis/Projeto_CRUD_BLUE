using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoAgenda.Models;

namespace ProjetoAgenda.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ArmazenamentoWebContext _context; 

        public UsuarioController(ArmazenamentoWebContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.OrderBy(x => x.Nome).Include(x => x.Grupo).AsNoTracking().ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Cadastrar(int? id)
        {
            var Grupo = _context.Grupo.OrderBy(x => x.Nome).AsNoTracking().ToList();
            var grupoSelectList = new SelectList(Grupo, nameof(GrupoModel.IdGrupo), nameof(GrupoModel.Nome));
            ViewBag.Grupo = grupoSelectList;
            if (id.HasValue)
            {
                var usuario = await _context.Usuario.FindAsync(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return View(usuario);
            }
            return View(new UsuarioModel());
        }

        private bool UsuarioExiste(int id)
        {
            return _context.Usuario.Any(x => x.IdUsuario == id);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(int? id,[FromForm] UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                if (id.HasValue)
                {
                    if(UsuarioExiste(id.Value))
                    {
                        _context.Update(usuario);
                        if(await _context.SaveChangesAsync()>0)
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Usuario alterado com Sucesso.");
                        }
                        else
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Erro na altera????o do Usuario.", TipoMensagem.Erro);
                        }
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Usuario n??o encontrado.", TipoMensagem.Erro);
                    }
                }
                else
                {
                    _context.Add(usuario);
                    if (await _context.SaveChangesAsync() >0)
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Usuario Cadastrado!");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Erro ao cadastrar Usuario.", TipoMensagem.Erro);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(usuario);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            if (!id.HasValue)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Usuario n??o informado.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Usuario n??o encontrado.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                if (await _context.SaveChangesAsync() > 0)
                    TempData["mensagem"] = MensagemModel.Serializar("Usuario exclu??do com sucesso.");
                else
                    TempData["mensagem"] = MensagemModel.Serializar("N??o foi poss??vel excluir o Usuario.", TipoMensagem.Erro);
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Usuario n??o encontrado.", TipoMensagem.Erro);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}