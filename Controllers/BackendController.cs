using Antlr.Runtime.Misc;
using EsercizioSettimanale4Marzo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsercizioSettimanale4Marzo.Controllers
{
    public class BackendController : Controller
    {
        // GET: Backend
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpGet]
        public JsonResult SpedizioniInconsegnaOggi()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            List<Spedizioni> lista = new List<Spedizioni>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT 
                                    Spedizione.IdSpedizione, IdCliente, DataSpedizione, Peso,	Citta, Indirizzo, NomeDestinatario, CostoSpedizione, ConsegnaPrevista
                                    FROM SPEDIZIONE
                                    INNER JOIN AggiornamentoSpedizione ON Spedizione.IdSpedizione = AggiornamentoSpedizione.IdSpedizione
                                    WHERE Stato = 'In Consegna' AND ConsegnaPrevista = '2024-03-06'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Spedizioni spedizione = new Spedizioni();
                            spedizione.IdSpedizione = reader.GetInt32(0);
                            spedizione.IdCliente = reader.GetInt32(1);
                            spedizione.DataSpedizione = reader.GetDateTime(2);
                            spedizione.Peso = (double)reader.GetDecimal(3);
                            spedizione.Citta = reader.GetString(4);
                            spedizione.Indirizzo = reader.GetString(5);
                            spedizione.NomeDestinatario = reader.GetString(6);
                            spedizione.CostoSpedizione = (double)reader.GetDecimal(7);
                            spedizione.ConsegnaPrevista = reader.GetDateTime(8);
                            lista.Add(spedizione);
                        }
                    }
                    return Json(lista, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult SpedizioniInconsegnaOggiView()
        {
            var data = SpedizioniInconsegnaOggi();
         
            return View(data.Data);
        }

        [HttpGet]
        public JsonResult SpedizioniInAttesaconsegna()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            int TotaleSpedizioni = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT COUNT(*) AS TotaleSpedizioni FROM AggiornamentoSpedizione
                                     WHERE Stato = 'In Consegna'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            TotaleSpedizioni = reader.GetInt32(0);
   
                        }
                    }
                    return Json(TotaleSpedizioni, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult SpedizioniInAttesaconsegnaView()
        {
            var data = SpedizioniInAttesaconsegna();

            return View(data.Data);
        }

        [HttpGet]
        public JsonResult RaggruppateCitta()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            List<SpedizioneCitta> risultati = new List<SpedizioneCitta>();
           
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT COUNT(Spedizione.IdSpedizione) AS TotaleSpedizioni, Citta
                                     FROM Spedizione
                                     GROUP BY Citta";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int TotaleSpedizioni = reader.GetInt32(0);
                            string Citta = reader.GetString(1);
                            risultati.Add(new SpedizioneCitta { TotaleSpedizioni = TotaleSpedizioni, Citta = Citta });

                        }
                    }
                    return Json(risultati, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult RaggruppateCittaView()
        {
            var data = RaggruppateCitta();
            var model = data.Data as List<SpedizioneCitta>;
            return View(model);
        }
    }
}