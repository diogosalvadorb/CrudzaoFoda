using CrudzaoFoda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudzaoFoda.Persistence.Contratos
{
    public interface IFilmesPersist
    {
        void Add<T>(T entity) where T:class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Filme> GetFilmeByIdAsync(int id);
        Task<Filme[]> GetAllFilmesAsync();
    }
}
