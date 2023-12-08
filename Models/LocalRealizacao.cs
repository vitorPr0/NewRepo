using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinalVitor.Models
{
    [Table("Localizacao")]
    public class LocalRealizacao
    {
        [Column("Id")]
        [Display(Name = "Código do Usuario")]
        public int Id { get; set; }

        [Column("LocalNome")]
        [Display(Name = "Nome do Local")]
        public string LocalNome { get; set; } = string.Empty;

        [ForeignKey("CidadeId")]
        public int CidadeId { get; set; }
        public Cidade? Cidade { get; set; }
    }
}
