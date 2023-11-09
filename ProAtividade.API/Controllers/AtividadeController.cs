using Microsoft.AspNetCore.Mvc;
using ProAtividade.API.Data;
using ProAtividade.API.Model;

namespace ProAtividade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public AtividadeController(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }
        
        [HttpGet]
        public IEnumerable<Atividade> Get()
        {
            return _dataContext.Atividades;
        }

        [HttpGet("{id}")]
        public Atividade Get(int id)
        {
            return _dataContext.Atividades.FirstOrDefault(ativ => ativ.Id == id);
        }

        [HttpPost]
        public IEnumerable<Atividade> Post(Atividade atividade)
        {
            _dataContext.Atividades.Add(atividade);

            if (_dataContext.SaveChanges() > 0)
                return _dataContext.Atividades;
            else
                throw new Exception("Atividade não adicionada");
        }

        [HttpPut("{id}")]
        public Atividade Put(int id, Atividade atividade)
        {
            if (atividade.Id != id) throw new Exception("Você está tentando atualizar a atividade errada");

            _dataContext.Update(atividade);

            if (_dataContext.SaveChanges() > 0)
                return _dataContext.Atividades.FirstOrDefault(ativ => ativ.Id == id);
            else
                return new Atividade();

        }

        [HttpDelete("{id}")]
        public Boolean Delete(int id)
        {
            var atividade = _dataContext.Atividades.FirstOrDefault(ativ => ativ.Id == id);

            if (atividade == null)
                throw new Exception("Atividade não existe");

            _dataContext.Remove(atividade);

            return _dataContext.SaveChanges() > 0;
        }
    }
}
