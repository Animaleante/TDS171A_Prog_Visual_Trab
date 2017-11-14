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
        [StringLength(80, ErrorMessage = "O nome do produto precisa ter no mínimo 3 caracteres", MinimumLength = 3)]
        public string NomeComprador { get; set; }

        [Required(ErrorMessage ="CPF obrigatório",AllowEmptyStrings =false)]
        [StringLength(11, ErrorMessage = "O CPF precisa ter 11 números",MinimumLength = 11)]
        public string CpfComprador { get; set; }

        [Required(ErrorMessage ="Obrigatório o telefone", AllowEmptyStrings = false)]
        [StringLength(13, ErrorMessage = "O telefone precisa ter pelo menos 11 digitos (somente números)", MinimumLength = 10)]
        public string TelefoneComprador { get; set; }

        public double? Total { get; set; }

        public virtual ICollection<VendaItem> VendaItems { get; set; }
    }
}