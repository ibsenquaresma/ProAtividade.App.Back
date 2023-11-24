using ProAtividade.Domain.Entities;

namespace ProAtividade.Domain.Interfaces.Repositories
{
    public interface IAtividadeRepo: IGeralRepo
    {
        Task<Atividade[]> GetAllAsync();

        Task<Atividade> GetByIdAsync(int id);

        Task<Atividade> GetByTitleAsync(string titulo);
    }
}
