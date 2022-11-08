using System.Text.Json.Serialization;

namespace BancoAPI.Models
{
    public class Transacao
    {
        public string? chaveOrigem { get; set; }
        public decimal? Valor { get; set; }
        public string? chaveDestino { get; set; }

        [JsonIgnore]
        public string? chavePix { get; set; }
        
        [JsonIgnore]
        public Cliente? Cliente { get; set; }

    }
}
