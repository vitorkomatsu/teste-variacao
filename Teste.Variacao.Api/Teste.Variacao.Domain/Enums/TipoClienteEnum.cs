using System.Text.Json.Serialization;

namespace Teste.Variacao.Domain.Enums
{
    public class TipoClienteEnum
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum TipoCliente
        {
            Fisica = 0,
            Juridica = 1
        }
    }
}
