﻿using System.Text.Json.Serialization;

namespace Teste.Variacao.Domain.Enums
{
    public class TipoUsuarioEnum
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum TipoUsuario
        {
            Vendedor = 0,
            Instalador = 1,
            Administrador = 2
        }
    }
}