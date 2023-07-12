using MinhaAPI.Models.Enum;

namespace MinhaAPI.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }
    }
}
