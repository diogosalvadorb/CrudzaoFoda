using CrudzaoFoda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudzaoFoda.Application.Contratos
{
    public interface IFilmeService
    {
        Task<Filme> AddFilme(Filme model);
        Task<Filme> UpdateFime(int id, Filme model);
        Task<bool> DeleteFilme(int id);

        Task<Filme> GetFilmeByIdAsync(int id);
        Task<Filme[]> GetAllFilmesAsync();
    }
}
