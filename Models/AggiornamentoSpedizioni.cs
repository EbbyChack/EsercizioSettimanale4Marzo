using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsercizioSettimanale4Marzo.Models
{
    public class AggiornamentoSpedizioni
    {
        [Display(Name = "Id Spedizione")]
        [Required(ErrorMessage = "Id Spedizione è obbligatorio.")]
        public int IdSpedizione { get; set; }

        [Required(ErrorMessage = "Stato è obbligatorio.")]
        public string Stato { get; set; }

        [Display(Name = "Luogo Attuale")]
        [Required(ErrorMessage = "Luogo Attuale è obbligatorio.")]
        public string LuogoAttuale { get; set; }

        
        public string Descrizione { get; set; }

        [Display(Name = "Data Ora Aggiornamento")]
        [Required(ErrorMessage = "Data Ora Aggiornamento è obbligatorio.")]
        public DateTime DataOraAggiornamento { get; set; }
    }
}