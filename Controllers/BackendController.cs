﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsercizioSettimanale4Marzo.Controllers
{
    public class BackendController : Controller
    {
        // GET: Backend
        public ActionResult Index()
        { if(User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }
    }
}