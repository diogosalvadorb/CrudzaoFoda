using CrudzaoFoda.Domain;
using CrudzaoFoda.Persistence.Contexto;
using CrudzaoFoda.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudzaoFoda.Persistence
{
    public class FilmesPersist : IFilmesPersist
    {
        private readonly FilmeDbContexto _context;
        public FilmesPersist(FilmeDbContexto context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            //se retorno for maior que zero o retorno e true; houve uma alteração
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Filme[]> GetAllFilmesAsync()
        {
            IQueryable<Filme> query = _context.Filmes;
            query = query.AsNoTracking()
                         .OrderBy(f => f.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Filme> GetFilmeByIdAsync(int id)
        {
            IQueryable<Filme> query = _context.Filmes;
            query = query.AsNoTracking()
                         .OrderBy(f => f.Id)
                         .Where(f => f.Id == id);

            return await query.FirstOrDefaultAsync();
        }       
    }
}
