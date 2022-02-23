using System.Collections.Generic;
using System.Linq;

namespace UsandoViews.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        private static List<Usuario> listagem = new List<Usuario>();
        public static IQueryable<Usuario> Listagem
        { 
            get
            {
                return listagem.AsQueryable();
            }
        }

        static Usuario()
        {
            Usuario.listagem.Add(
                new Usuario {IdUsuario = 1, Nome = "Luciano", Email = "fulano@email.com", Telefone = "81 99999-9999"});
            Usuario.listagem.Add(
                new Usuario {IdUsuario = 2, Nome = "Emerson", Email = "sicrano@email.com", Telefone = "81 88888-9999"});
            Usuario.listagem.Add(
                new Usuario {IdUsuario = 3, Nome = "Pedro", Email = "pedro@email.com", Telefone = "81 99555-5555"});
            Usuario.listagem.Add(
                new Usuario {IdUsuario = 4, Nome = "João", Email = "joao@email.com", Telefone = "81 99444-4444"});
            Usuario.listagem.Add(
                new Usuario {IdUsuario = 5, Nome = "Maria", Email = "maria@email.com", Telefone = "81 99777-7777"});  
        }

        public static void Salvar(Usuario usuario)
        {
            var usuarioExistente = Usuario.listagem.Find(u => u.IdUsuario == usuario.IdUsuario);
            if (usuarioExistente != null)
            {
                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Email = usuario.Email;
                usuarioExistente.Telefone = usuario.Telefone;
            }
            else
            {
                int maiorId = Usuario.Listagem.Max(u => u.IdUsuario);
                usuario.IdUsuario = maiorId + 1;
                Usuario.listagem.Add(usuario);
            }
        }

        public static void Excluir(int idUsuario)
        {
            var usuarioExistente = Usuario.listagem.Find(u => u.IdUsuario == idUsuario);
            if (usuarioExistente != null)
            {
                Usuario.listagem.Remove(usuarioExistente);
            }
        }
    }
}