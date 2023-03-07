using System.Text.Json.Serialization;

namespace Teste.Variacao.Domain.Enums
{
    public class TipoStatusEnum
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Status
        {
            Ativo = 0,
            Inativo = 1
        }
    }
}
