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
    public class AggiornamentoSpedizioniController : Controller
    {
        // GET: AggiornamentoSpedizioni
        public ActionResult AggiornamentoSpedizioni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AggiornamentoSpedizionii(AggiornamentoSpedizioni aggiornamento)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO AggiornamentoSpedizione (IdSpedizione, Stato, LuogoAttuale, Descrizione, DataOraAggiornamento) VALUES (@IdSpedizione, @Stato, @LuogoAttuale, @Descrizione, @DataOraAggiornamento)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdSpedizione", aggiornamento.IdSpedizione);
                    cmd.Parameters.AddWithValue("@Stato", aggiornamento.Stato);
                    cmd.Parameters.AddWithValue("@LuogoAttuale", aggiornamento.LuogoAttuale);
                    if (aggiornamento.Descrizione == null)
                    {
                        cmd.Parameters.AddWithValue("@Descrizione", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Descrizione", aggiornamento.Descrizione);
                    }
                    ;
                    cmd.Parameters.AddWithValue("@DataOraAggiornamento", DateTime.Now);

                    

                    cmd.ExecuteNonQuery();
                }
                return View("AggiornamentoSpedizioni");
            }
        }
    }
}