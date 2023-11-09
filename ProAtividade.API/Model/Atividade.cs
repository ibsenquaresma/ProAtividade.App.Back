using ProAtividade.API.Model.Enum;

namespace ProAtividade.API.Model
{
    public class Atividade
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public Prioridade Prioridade { get; set; }

        public Atividade() { }

        public Atividade(int id)
        {
            Id = id;
        }

    }
}
