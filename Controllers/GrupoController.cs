using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAgenda.Models;

namespace ProjetoAgenda.Controllers
{
    public class GrupoController : Controller
    {
        private readonly ArmazenamentoWebContext _context; 

        public GrupoController(ArmazenamentoWebContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Grupo.OrderBy(x => x.Nome).AsNoTracking().ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Cadastrar(int? id)
        {
            if (id.HasValue)
            {
                var grupo = await _context.Grupo.FindAsync(id);
                if (grupo == null)
                {
                    return NotFound();
                }
                return View(grupo);
            }
            return View(new GrupoModel());
        }

        private bool GrupoExiste(int id)
        {
            return _context.Grupo.Any(x => x.IdGrupo == id);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(int? id,[FromForm] GrupoModel grupo)
        {
            if (ModelState.IsValid)
            {
                if (id.HasValue)
                {
                    if(GrupoExiste(id.Value))
                    {
                        _context.Update(grupo);
                        if(await _context.SaveChangesAsync()>0)
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Grupo alterado com Sucesso.");
                        }
                        else
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Erro na alteração do Grupo.", TipoMensagem.Erro);
                        }
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Grupo não encontrado.", TipoMensagem.Erro);
                    }
                }
                else
                {
                    _context.Add(grupo);
                    if (await _context.SaveChangesAsync() >0)
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Grupo Cadastrado!");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Erro ao cadastrar Grupo.", TipoMensagem.Erro);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(grupo);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            if (!id.HasValue)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Grupo não informado.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
            var grupo = await _context.Grupo.FindAsync(id);
            if (grupo == null)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Grupo não encontrado.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
            return View(grupo);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            var grupo = await _context.Grupo.FindAsync(id);
            if (grupo != null)
            {
                _context.Grupo.Remove(grupo);
                if (await _context.SaveChangesAsync() > 0)
                    TempData["mensagem"] = MensagemModel.Serializar("Grupo excluído com sucesso.");
                else
                    TempData["mensagem"] = MensagemModel.Serializar("Não foi possível excluir o Grupo.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Grupo não encontrado.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}