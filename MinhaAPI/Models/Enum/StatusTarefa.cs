using System.ComponentModel;

namespace MinhaAPI.Models.Enum
{
    public enum StatusTarefa
    {
        [Description("A Fazer")] //Desnecessario, mas é bom saber que existe
        AFazer,
        [Description("Em Andamento")]
        EmAndamento,
        [Description("Concluido")]
        Concluido
    }
}
