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
    public class SpedizioniController : Controller
    {
        // GET: Spedizioni
        public ActionResult InserisciSpedizione()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InserisciSpedizionee(Spedizioni spedizioni)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Spedizione (IdCliente, DataSpedizione, Peso, Citta, Indirizzo, NomeDestinatario, CostoSpedizione, ConsegnaPrevista) VALUES (@IdCliente, @DataSpedizione, @Peso, @Citta, @Indirizzo, @NomeDestinatario, @CostoSpedizione, @ConsegnaPrevista)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", spedizioni.IdCliente);
                    cmd.Parameters.AddWithValue("@DataSpedizione", spedizioni.DataSpedizione);
                    cmd.Parameters.AddWithValue("@Peso", spedizioni.Peso);
                    cmd.Parameters.AddWithValue("@Citta", spedizioni.Citta);
                    cmd.Parameters.AddWithValue("@Indirizzo", spedizioni.Indirizzo);
                    cmd.Parameters.AddWithValue("@NomeDestinatario", spedizioni.NomeDestinatario);
                    cmd.Parameters.AddWithValue("@CostoSpedizione", spedizioni.CostoSpedizione);
                    cmd.Parameters.AddWithValue("@ConsegnaPrevista", spedizioni.ConsegnaPrevista);

                    cmd.ExecuteNonQuery();
                }
                return View("InserisciSpedizione");
            }
        }
    }
}