using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsercizioSettimanale4Marzo.Models
{
    public class Addetti
    {
       

        [Required(ErrorMessage = "Username è obbligatorio.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password è obbligatorio.")]
        public string Password { get; set; }


    }
}