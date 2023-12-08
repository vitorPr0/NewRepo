using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoFinalVitor.Models
{
    [Table("TipoProcedimento")]
    public class Tipoprocedimento
    {
        [Column("Id")]
        [Display(Name = "Código do Tipo do Procedimento")]
        public int Id { get; set; }

        [Column("TipoProcedimentoNome")]
        [Display(Name = "Nome do tipo do Procedimento")]
        public string TipoProcedimentoNome { get; set; } = string.Empty;
    }
}
