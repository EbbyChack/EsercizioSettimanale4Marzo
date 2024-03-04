using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsercizioSettimanale4Marzo.Controllers
{
    public class SpedizioniController : Controller
    {
        // GET: Spedizioni
        public ActionResult InserisciSpedizione()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InserisciSpedizionee()
        {
            return View();
        }
    }
}