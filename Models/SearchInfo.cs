using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsercizioSettimanale4Marzo.Models
{
    public class SearchInfo
    {
        [Display(Name = "Codice Fiscale o Partita IVA")]
        public string CFPIVA { get; set; }
        [Display(Name = "Numero Spedizione")]
        public int IdSpedizione { get; set; }
    }
}