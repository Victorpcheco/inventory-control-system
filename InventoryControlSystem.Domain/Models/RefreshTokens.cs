using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlSystem.Domain.Models
{
    public class RefreshTokens
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }



    }
}
