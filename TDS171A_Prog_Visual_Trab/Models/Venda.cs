using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TDS171A_Prog_Visual_Trab.Models
{
    public class Venda
    {
        public long? VendaId { get; set; }
        public long NumeroNota { get; set; }
        public DateTime Data { get; set; }

        [Required(ErrorMessage ="Nomer é obrigatório",AllowEmptyStrings =false)]
        [Display(Name = "Informe o nome do comprador")]
        [StringLength(80, MinimumLength = 3)]
        public string NomeComprador { get; set; }

        [Required(ErrorMessage ="CPF obrigatório",AllowEmptyStrings =false)]
        public long CpfComprador { get; set; }

        [Required(ErrorMessage ="Obrigatório o telefone", AllowEmptyStrings = false)]
        public long TelefoneComprador { get; set; }

        public Decimal? Total { get; set; }

        public virtual ICollection<VendaItem> VendaItems { get; set; }
    }
}