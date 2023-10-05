using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServiceBD.dsDatosTableAdapters;

namespace WebServiceBD
{
   
    /// <summary>
    /// Descripción breve de SERVICIOBD
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
   



    
    public class SERVICIOBD : System.Web.Services.WebService
    {

        AUTOSTableAdapter autos = new AUTOSTableAdapter();

        //instancia de mi dataset 
        dsDatos dsDatos = new dsDatos();




        [WebMethod]
        public DataSet Seleccionar_AUTOS()
        {
            this.autos.Fill(this.dsDatos.AUTOS);
            return dsDatos;
        }



        [WebMethod]
        public string Insertar_Autos(string Marca, string Modelo, string Año, string Color, string Precio )
        {
            string resultado;
            try
            {
                this.autos.Insert(Marca, Modelo, Int32.Parse(Año), Color, Int32.Parse(Precio));
                resultado = "El registro se inserto correctamente";
                return resultado;
            }
            catch(Exception ex)
            {
                resultado = "Error al insertar" + ex.Message.ToString();
                return resultado;
            }

           
        }


        [WebMethod]
        public string Actualizar_Autos(string Marca, string Modelo, string Año, string Color, string Precio ,int ID) 
        {
            try
            {
                this.autos.Update(Marca, Modelo, Int32.Parse(Año), Color, Int32.Parse(Precio), ID);

                return "El registro de Actulizo Correctamente";

            }
            catch(Exception ex)
            {
                
                return "Error al actualizar el registro" + ex.Message.ToString();
            }

        }


        [WebMethod]
        public string Eliminar_Autos(int ID)
        {
            try
            {
                this.autos.Delete(ID);
                return "El registro se elimino correctamente";
            }
            catch(Exception ex)
            {
                return "Error al Eliminar el registro" + ex.Message.ToString();
            }

        }



        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
    }
}
