using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDS171A_Prog_Visual_Trab.Models
{
    public class Produto
    {
        public long? ProdutoId { get; set; }
        public string Nome { get; set; }
        public bool Removido { get; set; }
        public Decimal Preco { get; set; }

        public long? CategoriaId { get; set; }
        public long? FabricanteId { get; set; }

        public Categoria Categoria { get; set; }
        public Fabricante Fabricante { get; set; }
    }
}