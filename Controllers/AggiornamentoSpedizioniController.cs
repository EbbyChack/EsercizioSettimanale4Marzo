using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsercizioSettimanale4Marzo.Controllers
{
    public class AggiornamentoSpedizioniController : Controller
    {
        // GET: AggiornamentoSpedizioni
        public ActionResult AggiornamentoSpedizioni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AggiornamentoSpedizionii()
        {
            return View();
        }
    }
}