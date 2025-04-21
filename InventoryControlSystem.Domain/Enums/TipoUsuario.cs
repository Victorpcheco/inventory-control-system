using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InventoryControlSystem.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))] // Permite enviar o enum como string no JSON
    public enum TipoUsuario
    {

        Admin = 0,
        Operador = 1
    }
}
