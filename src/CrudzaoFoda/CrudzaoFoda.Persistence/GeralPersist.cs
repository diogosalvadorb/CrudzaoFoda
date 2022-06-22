using CrudzaoFoda.Persistence.Contexto;
using CrudzaoFoda.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudzaoFoda.Persistence
{
    public class GeralPersist :IGeralPersist
    {
        private readonly FilmeDbContexto _context;
        public GeralPersist(FilmeDbContexto contexto)
        {
            _context = contexto;
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
    }
}
