using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TDS171A_Prog_Visual_Trab.Models
{
    public class Categoria
    {

        public long CategoriaId { get; set; }

        [StringLength(100, ErrorMessage = "O	nome	da categoria precisa ter no  mínimo  3  caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Informe	o	nome	da categoria")]
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}