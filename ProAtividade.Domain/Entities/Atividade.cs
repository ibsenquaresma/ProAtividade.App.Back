using ProAtividade.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProAtividade.Domain.Entities
{
    public class Atividade
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Titulo { get; set; }

        public string? Descricao { get; set; }

        public DateTime? DateCreation { get; set; }

        public DateTime? DateConclusion { get; set; }

        public Prioridade Prioridade { get; set; }

        public Atividade()
        {
            DateCreation = DateTime.Now;
            DateConclusion = null;
        } 

        public Atividade(int id, string titulo, string descricao) : this()
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
        }

        public void Conclude()
        {
            if (DateConclusion == null)
                DateConclusion = DateTime.Now;
            else
                throw new Exception($"Atividade já concluida em : {DateConclusion?.ToString("dd/MM/yyyy hh:mm")}");
        }

    }
}
