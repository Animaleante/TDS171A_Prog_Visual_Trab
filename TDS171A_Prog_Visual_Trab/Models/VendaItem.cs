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

        [Range(1, int.MaxValue, ErrorMessage = "Valor deve ser maior que 0")]
        public int Quantidade { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Valor deve ser maior que 0")]
        public double Valor { get; set; }       
        
        public double totalUnitario { get; set; }

        public Venda Venda { get; set; }
        public Produto Produto { get; set; }
    }
}