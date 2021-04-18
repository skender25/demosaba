using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using demosaba.Models;


namespace demosaba.Controllers
{
    public class demoController : Controller
    {
        // GET: demo
        public ActionResult Index()
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "set dateformat dmy select top 200 * from [erpadmin].[P_APP_HACIENDA_DE] ";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<MVClass> lc = new List<MVClass>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                lc.Add(new MVClass
                {
                    DOCUMENTO = Convert.ToString(dr["DOCUMENTO"]),
                    CLIENTE = Convert.ToString(dr["CLIENTE"]),
                    FECHA = Convert.ToDateTime(dr["FECHA"]),
                    NOMBRE = Convert.ToString(dr["NOMBRE"]),
                    NIT_RECEPTOR = Convert.ToString(dr["NIT_RECEPTOR"]),
                    CODIGO_MONEDA = Convert.ToString(dr["CODIGO_MONEDA"]),
                    CLAVE = Convert.ToString(dr["CLAVE"]),
                    TOTALGRAVADO = Convert.ToString(dr["TOTALGRAVADO"]),
                    TOTALEXENTO = Convert.ToString(dr["TOTALEXENTO"]),
                    TOTALDESCUENTOS = Convert.ToString(dr["TOTALDESCUENTOS"]),
                    TOTALIMPUESTO = Convert.ToString(dr["TOTALIMPUESTO"]),
                    TOTALCOMPROBANTE = Convert.ToString(dr["TOTALCOMPROBANTE"]),
                    CONTIENE_ERRORES = Convert.ToString(dr["CONTIENE_ERRORES"]),
                    ERROR_WS = Convert.ToString(dr["ERROR_WS"]),
                    ERROR_SOFTLAND = Convert.ToString(dr["ERROR_SOFTLAND"]),
                    ENVIADO = Convert.ToString(dr["ENVIADO"]),
                    ACEPTADO = Convert.ToString(dr["ACEPTADO"]),
                    RESPUESTA_XML = Convert.ToString(dr["RESPUESTA_XML"]),
                    PDF = Convert.ToString(dr["PDF"]),
                    XML = Convert.ToString(dr["XML"])


                });
            }

            sqlconn.Close();
            ModelState.Clear();
            return View(lc);
        }

        [HttpPost]
        public ActionResult Index(DateTime? start, DateTime? end)
        {

            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "set dateformat dmy select  * from [erpadmin].[P_APP_HACIENDA_DE] where FECHA between '" + start + "'and'" + end + "'";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<MVClass> lc = new List<MVClass>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lc.Add(new MVClass
                {

                    DOCUMENTO = Convert.ToString(dr["DOCUMENTO"]),
                    CLIENTE = Convert.ToString(dr["CLIENTE"]),
                    FECHA = Convert.ToDateTime(dr["FECHA"]),
                    NOMBRE = Convert.ToString(dr["NOMBRE"]),
                    NIT_RECEPTOR = Convert.ToString(dr["NIT_RECEPTOR"]),
                    CODIGO_MONEDA = Convert.ToString(dr["CODIGO_MONEDA"]),
                    CLAVE = Convert.ToString(dr["CLAVE"]),
                    TOTALGRAVADO = Convert.ToString(dr["TOTALGRAVADO"]),
                    TOTALEXENTO = Convert.ToString(dr["TOTALEXENTO"]),
                    TOTALDESCUENTOS = Convert.ToString(dr["TOTALDESCUENTOS"]),
                    TOTALIMPUESTO = Convert.ToString(dr["TOTALIMPUESTO"]),
                    TOTALCOMPROBANTE = Convert.ToString(dr["TOTALCOMPROBANTE"]),
                    CONTIENE_ERRORES = Convert.ToString(dr["CONTIENE_ERRORES"]),
                    ERROR_WS = Convert.ToString(dr["ERROR_WS"]),
                    ERROR_SOFTLAND = Convert.ToString(dr["ERROR_SOFTLAND"]),
                    ENVIADO = Convert.ToString(dr["ENVIADO"]),
                    ACEPTADO = Convert.ToString(dr["ACEPTADO"]),
                    RESPUESTA_XML = Convert.ToString(dr["RESPUESTA_XML"]),
                    PDF = Convert.ToString(dr["PDF"]),
                    XML = Convert.ToString(dr["XML"])

                });
            }

            sqlconn.Close();
            ModelState.Clear();
            return View(lc);
        }
    }
}