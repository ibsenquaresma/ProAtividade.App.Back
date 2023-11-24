using ProAtividade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProAtividade.Domain.Interfaces.Services
{
    public interface IAtividadeService
    {
        Task<Atividade> AddAtividade(Atividade atividade);

        Task<Atividade> UpdateAtividade(Atividade atividade);

        Task<bool> DeleteAtividade(int atividadeId);

        Task<bool> ConcluirAtividade(Atividade atividade);

        Task<Atividade[]> GetAllAtividadesAsync();

        Task<Atividade> GetAtividadeByIdAsync(int atividadeId);
    }
}
