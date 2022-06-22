using CrudzaoFoda.Application.Contratos;
using CrudzaoFoda.Domain;
using CrudzaoFoda.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudzaoFoda.Application
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmesPersist _filmePersist;
        public FilmeService(IFilmesPersist filmePersist)
        {
            _filmePersist = filmePersist;
        }
        public async Task<Filme> AddFilme(Filme model)
        {
            try
            {
                _filmePersist.Add<Filme>(model);
                if (await _filmePersist.SaveChangesAsync())
                {
                    return await _filmePersist.GetFilmeByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };
        }

        public async Task<Filme> UpdateFime(int id, Filme model)
        {
            try
            {
                var filme = await _filmePersist.GetFilmeByIdAsync(id);
                if (filme == null) return null;

                model.Id = filme.Id;

                _filmePersist.Update(model);
                if (await _filmePersist.SaveChangesAsync())
                {
                    return await _filmePersist.GetFilmeByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteFilme(int id)
        {
            try
            {
                var filme = await _filmePersist.GetFilmeByIdAsync(id);
                if (filme == null) throw new Exception("Filme não encontrado.");

                _filmePersist.Delete<Filme>(filme);
                return await _filmePersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Filme[]> GetAllFilmesAsync()
        {
            try
            {
                var filme = await _filmePersist.GetAllFilmesAsync();
                if (filme == null) return null;

                return filme;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public async Task<Filme> GetFilmeByIdAsync(int id)
        {
            try
            {
                var filme = await _filmePersist.GetFilmeByIdAsync(id);
                if (filme == null) return null;

                return filme;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
