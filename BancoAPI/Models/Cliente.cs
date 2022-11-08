using System.Text.Json.Serialization;

namespace BancoAPI.Models
{
    public class Cliente
    {
        public string? Nome { get; set; }
        public string? Documento { get; set; }
        public string? chavePix { get; set; }

        [JsonIgnore]
        public ICollection<Transacao>? Transacoes { get; set; }
    }
}
