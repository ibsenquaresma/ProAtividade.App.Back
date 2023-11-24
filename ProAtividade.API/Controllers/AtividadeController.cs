using Microsoft.AspNetCore.Mvc;
using ProAtividade.Domain.Entities;
using ProAtividade.Domain.Interfaces.Services;

namespace ProAtividade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private readonly IAtividadeService _atividadeService;

        public AtividadeController(IAtividadeService atividadeService) 
        {
            _atividadeService = atividadeService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var atividades = await _atividadeService.GetAllAtividadesAsync();

                if (atividades == null) return NoContent();

                return Ok(atividades);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error ao tentar recuperar Atividades. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var atividade = await _atividadeService.GetAtividadeByIdAsync(id);

                if (atividade == null) return NoContent();

                return Ok(atividade);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error ao tentar recuperar Atividade {id}. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Atividade model)
        {
            try
            {
                var atividade = await _atividadeService.AddAtividade(model);

                if (atividade == null) return NoContent();

                return Ok(atividade);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error ao tentar adicionar Atividade. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Atividade model)
        {
            try
            {
                if (model.Id != id)
                {
                    this.StatusCode(StatusCodes.Status409Conflict,
                        "Você está tentando atualizar a Atividade errada.");
                }

                var atividade = await _atividadeService.UpdateAtividade(model);

                if (atividade == null) return NoContent();

                return Ok(atividade);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error ao tentar atualizar a Atividade {id}. Erro: {ex.InnerException.Message}");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var atividade = await _atividadeService.GetAtividadeByIdAsync(id);
                if (atividade == null)
                {
                    this.StatusCode(StatusCodes.Status409Conflict,
                        "Você está tentando deletar a Atividade errada ou não existe.");
                }
                if (await _atividadeService.DeleteAtividade(id))
                {
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    return BadRequest("Erro ao deletar a atividade");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error ao tentar deletar a Atividade {id}. Erro: {ex.Message}");
            }
        }
    }
}
