using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjetoAgenda.Models;

namespace ProjetoAgenda
{
    public class UsuarioModel
    {
        [Key]
        public int IdUsuario {get;set;}
        [Required, MaxLength(150)]
        public string Nome {get;set;}
       
        public string Email {get;set;}
       
        public string Telefone {get;set;}

        [ForeignKey("Grupo")]
        public string IdGrupo {get;set;}

        public GrupoModel grupo {get;set;}

    }
}