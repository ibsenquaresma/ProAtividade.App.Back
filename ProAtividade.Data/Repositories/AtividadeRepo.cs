using Microsoft.EntityFrameworkCore;
using ProAtividade.Data.Context;
using ProAtividade.Domain.Entities;
using ProAtividade.Domain.Interfaces.Repositories;

namespace ProAtividade.Data.Repositories
{
    public class AtividadeRepo : GeralRepo, IAtividadeRepo
    {
        private readonly DataContext _dataContext;

        public AtividadeRepo(DataContext dataContext) : base(dataContext) 
        {
            _dataContext = dataContext;
        }

        public async Task<Atividade[]> GetAllAsync()
        {
            IQueryable<Atividade> query = _dataContext.Atividades;

            query = query
                    .AsNoTracking()
                    .OrderBy(ativ => ativ.Id);

            return await query.ToArrayAsync();

        }

        public async Task<Atividade> GetByIdAsync(int id)
        {
            IQueryable<Atividade> query = _dataContext.Atividades;

            query = query
                    .AsNoTracking()
                    .OrderBy(ativ => ativ.Id)
                    .Where(a => a.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Atividade> GetByTitleAsync(string titulo)
        {
            IQueryable<Atividade> query = _dataContext.Atividades;

            query = query
                    .AsNoTracking()
                    .OrderBy(ativ => ativ.Id);

            return await query.FirstOrDefaultAsync(a => a.Titulo == titulo);
        }
    }
}
