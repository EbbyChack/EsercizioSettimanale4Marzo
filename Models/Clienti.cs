using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsercizioSettimanale4Marzo.Models
{
    public class Clienti
    {
       

        [Display(Name = "Codice Fiscale")]
        [StringLength(16, ErrorMessage = "Codice Fiscale non valido", MinimumLength = 16)]
        public string CF { get; set; }

        [Display(Name = "Partita Iva")]
        [StringLength(11, ErrorMessage = "Partita IVA non valida", MinimumLength = 11)]
        public string PIVA { get; set; }

        [Required(ErrorMessage = "Nome Cliente o Azienda è obbligatorio.")]
        [Display(Name = "Nome Cliente o Azienda")]
        public string NomeCliente { get; set; }
    }
}