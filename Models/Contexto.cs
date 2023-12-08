using Microsoft.EntityFrameworkCore;
using ProjetoFinalVitor.Models;

namespace ProjetoFinalVitor.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<ProjetoFinalVitor.Models.Cidade>? Cidade { get; set; }
        public DbSet<ProjetoFinalVitor.Models.LocalRealizacao>? LocalRealizacao { get; set; }
        public DbSet<ProjetoFinalVitor.Models.Cliente>? Cliente { get; set; }
        public DbSet<ProjetoFinalVitor.Models.Colaborador>? Colaborador { get; set; }
        public DbSet<ProjetoFinalVitor.Models.Estado>? Estado { get; set; }
        public DbSet<ProjetoFinalVitor.Models.Procedimento>? Procedimento { get; set; }
        public DbSet<ProjetoFinalVitor.Models.Procedimentorealizacao>? Procedimentorealizacao { get; set; }
        public DbSet<ProjetoFinalVitor.Models.Tipocolaborador>? Tipocolaborador { get; set; }
        public DbSet<ProjetoFinalVitor.Models.Tipoprocedimento>? Tipoprocedimento { get; set; }
        public DbSet<ProjetoFinalVitor.Models.Usuario>? Usuario { get; set; }

    }
}
