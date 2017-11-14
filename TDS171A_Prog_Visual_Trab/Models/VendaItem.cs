using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TDS171A_Prog_Visual_Trab.Models
{
    public class VendaItem
    {
        public long? VendaItemId { get; set; }
        public long? VendaId { get; set; }
        public long? ProdutoId { get; set; }

        [Required(ErrorMessage ="Quantidade deve ser maior que 0",AllowEmptyStrings =false)]
        public int Quantidade { get; set; }

        
        public double? Valor { get; set; }       


        public double? totalUnitario { get; set; }

        public Venda Venda { get; set; }
        public Produto Produto { get; set; }
    }
}