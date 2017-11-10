using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDS171A_Prog_Visual_Trab.Models
{
    public class Venda
    {
        public long? VendaId { get; set; }
        public long NumeroNota { get; set; }
        public DateTime Data { get; set; }
        public string NomeComprador { get; set; }
        public long CpfComprador { get; set; }
        public long TelefoneComprador { get; set; }
        public Decimal? Total { get; set; }

        public virtual ICollection<VendaItem> VendaItems { get; set; }
    }
}