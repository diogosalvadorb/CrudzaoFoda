using CrudzaoFoda.Domain;
using Microsoft.EntityFrameworkCore;

namespace CrudzaoFoda.Persistence.Contexto
{
    public class FilmeDbContexto : DbContext
    {
        public FilmeDbContexto(DbContextOptions<FilmeDbContexto> options) 
            : base(options)
        {    
        }
        public DbSet<Filme> Filmes { get; set; }
    }
}
