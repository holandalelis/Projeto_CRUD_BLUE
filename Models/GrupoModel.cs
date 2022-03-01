using System.ComponentModel.DataAnnotations;

namespace ProjetoAgenda.Models
{
    public class GrupoModel
    {
        [Key]
        public int IdGrupo {get;set;}
        [Required, MaxLength(150)]
        public string Nome {get;set;}
    }
}