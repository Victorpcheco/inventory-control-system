using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryControlSystem.Domain.Enums;

namespace InventoryControlSystem.Application.DTOS
{
    public class RegisterRequestDto
    {

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Matricula { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public TipoUsuario TipoUsuario { get; set; }


    }
}
