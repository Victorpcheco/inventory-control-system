using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlSystem.Application.DTOS
{
    public class LoginRequest
    {

        [Required]
        public string Matricula { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
