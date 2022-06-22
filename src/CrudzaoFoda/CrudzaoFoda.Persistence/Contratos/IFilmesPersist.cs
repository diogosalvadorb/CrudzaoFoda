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
        Task<Filme> GetFilmeByIdAsync(int id);
        Task<Filme[]> GetAllFilmesAsync();
    }
}
