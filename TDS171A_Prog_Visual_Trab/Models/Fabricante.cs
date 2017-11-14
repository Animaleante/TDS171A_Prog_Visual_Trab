using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TDS171A_Prog_Visual_Trab.Models
{
    public class Fabricante
    {
        public long FabricanteId { get; set; }

        [StringLength(100, ErrorMessage = "O nome do fabricante precisa ter no  mínimo  3  caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Informe o nome do Fabricantes")]
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}