using ProAtividade.Domain.Entities;
using ProAtividade.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ProAtividade.Domain.Interfaces.Services
{
    public class AtividadeService : IAtividadeService
    {
        private readonly IAtividadeRepo _atividadeRepo;

        public AtividadeService(IAtividadeRepo atividadeRepo)
        {
            _atividadeRepo = atividadeRepo;
        }

        public async Task<Atividade> AddAtividade(Atividade atividade)
        {
            if (await _atividadeRepo.GetByTitleAsync(atividade.Titulo) != null)
                throw new Exception("Já existe uma atividade com esse título");

            if (await _atividadeRepo.GetByIdAsync(atividade.Id) == null)
            {
                _atividadeRepo.Add(atividade);
                if(await _atividadeRepo.SaveChangesAsync())
                    return atividade;
            }

            return null;
        }

        public async Task<bool> ConcluirAtividade(Atividade atividade)
        {
            if (atividade != null)
            {
                atividade.Conclude();
                _atividadeRepo.Update<Atividade>(atividade);

                return await _atividadeRepo.SaveChangesAsync();
            }

            return false;
        }

        public async Task<bool> DeleteAtividade(int atividadeId)
        {
            var atividade = await _atividadeRepo.GetByIdAsync(atividadeId);

            if (atividade == null) throw new Exception("Atividade não existe");

            _atividadeRepo.Delete(atividade);

            return await _atividadeRepo.SaveChangesAsync();
        }

        public async Task<Atividade[]> GetAllAtividadesAsync()
        {
            try
            {
                var atividades = await _atividadeRepo.GetAllAsync();
                if (atividades == null) return null;

                return atividades;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Atividade> GetAtividadeByIdAsync(int atividadeId)
        {
            try
            {
                var atividade = await _atividadeRepo.GetByIdAsync(atividadeId);
                if (atividade == null) return null;

                return atividade;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Atividade?> UpdateAtividade(Atividade atividade)
        {
            if (atividade.DateConclusion != null)
                throw new Exception("Não pode alterar atividade já concluida");

            if (await _atividadeRepo.GetByIdAsync(atividade.Id) != null)
            {
                //_atividadeRepo.Add(atividade);
                _atividadeRepo.Update<Atividade>(atividade);
                if (await _atividadeRepo.SaveChangesAsync())
                    return atividade;
            }

            return null;

        }
    }
}
