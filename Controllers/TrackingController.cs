using EsercizioSettimanale4Marzo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsercizioSettimanale4Marzo.Controllers
{
    public class TrackingController : Controller
    {
        // GET: Tracking
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TrackingView(SearchInfo searchInfo)
        {
            if (searchInfo.CFPIVA == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

                List<Tracking> lista = new List<Tracking>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT 
                                Clienti.NomeCliente,
                                AggiornamentoSpedizione.IdSpedizione, 
                                AggiornamentoSpedizione.Stato, 
                                AggiornamentoSpedizione.LuogoAttuale, 
                                AggiornamentoSpedizione.Descrizione,
                                AggiornamentoSpedizione.DataOraAggiornamento,
                                Spedizione.ConsegnaPrevista
                                FROM AggiornamentoSpedizione
                                INNER JOIN Spedizione ON Spedizione.IdSpedizione = AggiornamentoSpedizione.IdSpedizione
                                INNER JOIN Clienti ON Spedizione.IdCliente = Clienti.IdCliente
                                WHERE Clienti.PIVA = @CFPIVA OR Clienti.CF = @CFPIVA
                                AND AggiornamentoSpedizione.IdSpedizione = @Id
                                ORDER BY AggiornamentoSpedizione.DataOraAggiornamento DESC;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CFPIVA", searchInfo.CFPIVA);
                        cmd.Parameters.AddWithValue("@Id", searchInfo.IdSpedizione);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Tracking tracking = new Tracking();
                                tracking.NomeCliente = reader.GetString(0);
                                tracking.IdSpedizione = reader.GetInt32(1);
                                tracking.Stato = reader.GetString(2);
                                tracking.LuogoAttuale = reader.GetString(3);
                                tracking.Descrizione = reader.GetString(4);
                                tracking.DataOraAggiornamento = reader.GetDateTime(5);
                                tracking.ConsegnaPrevista = reader.GetDateTime(6).ToString("dd-MM-yyyy");
                                lista.Add(tracking);

                            }

                        }
                    }
                }
                return View(lista);
            }
        }
            
    }
}