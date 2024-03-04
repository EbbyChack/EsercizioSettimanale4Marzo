using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsercizioSettimanale4Marzo.Models
{
    public class Spedizioni
    {
        [HiddenInput(DisplayValue = false)]
        public int IdSpedizione { get; set; }

        [Display(Name = "Id Cliente")]
        [Required(ErrorMessage = "Id Cliente è obbligatorio.")]
        public int IdCliente { get; set; }

        [Display(Name = "Data Spedizione")]
        [Required(ErrorMessage = "Data Spedizione è obbligatorio.")]
        public DateTime DataSpedizione { get; set; }

        [Display(Name = "Peso")]
        [Required(ErrorMessage = "Peso è obbligatorio.")]
        public double Peso { get; set; }

        [Display(Name = "Città")]
        [Required(ErrorMessage = "Citta è obbligatorio.")]
        public string Citta { get; set; }

        [Required(ErrorMessage = "Indirizzo è obbligatorio.")]
        public string Indirizzo { get; set; }

        [Display(Name = "Nome Destinatario")]
        [Required(ErrorMessage = "Nome Destinatario è obbligatorio.")]
        public string NomeDestinatario { get; set; }

        [Display(Name = "Costo Spedizione")]
        [Required(ErrorMessage = "Costo Spedizione è obbligatorio.")]
        public double CostoSpedizione { get; set; }

        [Display(Name = "Consegna Prevista")]
        [Required(ErrorMessage = "Consegna Prevista è obbligatorio.")]
        public DateTime ConsegnaPrevista { get; set; }



    }
}