using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsercizioSettimanale4Marzo.Controllers
{
    public class ClientiController : Controller
    {
        public ActionResult InserisciCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InserisciClientee()
        {
            return View();
        }
    }
}