using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TDS171A_Prog_Visual_Trab.Models
{
    public class Produto
    {
        public long? ProdutoId { get; set; }

        [StringLength(100, ErrorMessage = "O nome do produto precisa ter no mínimo 3 caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Nome { get; set; }

        public bool Removido { get; set; }
        
        
        public long? CategoriaId { get; set; }
        
        public long? FabricanteId { get; set; }

        public Categoria Categoria { get; set; }
        public Fabricante Fabricante { get; set; }
        public virtual ICollection<VendaItem> VendaItems { get; set; }
    }
}