using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDS171A_Prog_Visual_Trab.Models
{
    public class VendaItem
    {
        public long? VendaItemId { get; set; }
        public long VendaId { get; set; }
        public long ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public Decimal Valor { get; set; }

        public Venda Venda { get; set; }
        public Produto Produto { get; set; }
    }
}