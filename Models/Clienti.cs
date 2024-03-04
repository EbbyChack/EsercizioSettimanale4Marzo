using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsercizioSettimanale4Marzo.Models
{
    public class Clienti
    {
       

        [Display(Name = "Codice Fiscale o Partita IVA")]
        [Required(ErrorMessage = "Codice Fiscale o Partita IVA è obbligatorio.")]
        public string CFoPIVA { get; set; }

        [Required(ErrorMessage = "Nome Cliente o Azienda è obbligatorio.")]
        [Display(Name = "Nome Cliente o Azienda")]
        public string NomeCliente { get; set; }
    }
}