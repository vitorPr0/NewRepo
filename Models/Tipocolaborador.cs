using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoFinalVitor.Models
{
    [Table("TipoColaborador")]
    public class Tipocolaborador
    {
        [Column("Id")]
        [Display(Name = "Código do Tipo do colaborador")]
        public int Id { get; set; }

        [Column("TipoColaboradorNome")]
        [Display(Name = "Nome do tipo do colaborador")]
        public string TipoColaboradorNome { get; set; } = string.Empty;
    }
}
