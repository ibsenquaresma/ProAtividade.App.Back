using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAtividade.API.Model;

namespace ProAtividade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        public IEnumerable<Atividade> Atividades = new List<Atividade>()
            {
                new Atividade(1),
                new Atividade(2),
                new Atividade(3)
            };

        public AtividadeController() { }
        
        [HttpGet]
        public IEnumerable<Atividade> Get()
        {
            return Atividades;
        }

        [HttpGet("{id}")]
        public Atividade Get(int id)
        {
            return Atividades.FirstOrDefault(ativ => ativ.Id == id);
        }

        [HttpPost]
        public IEnumerable<Atividade> Post(Atividade atividade)
        {
            return Atividades.Append<Atividade>(atividade);
        }

        [HttpPut]
        public string Put()
        {
            return "Meu primeiro put";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Meu primeiro put com parametro {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Meu primeiro delete {id}";
        }
    }
}
