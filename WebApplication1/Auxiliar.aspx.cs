using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Auxiliar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadSession();
        }
        private void loadSession()
        {
            String nombre = (String)(Session["Nombre"]);
            String apellido = (String)(Session["Apellido"]);
            String sexo = (String)(Session["Sexo"]);
            String email = (String)(Session["Email"]);
            String direccion = (String)(Session["Direccion"]);
            String ciudad = (String)(Session["Ciudad"]);
            String requerimientos = (String)(Session["Requerimientos"]);
            
            LabelUsuario.Text = "Enviado por Sesion: ";
            LabelNombre.Text = "Nombre: " + nombre;
            LabelApellido.Text = " Apellido: " + apellido;
            LabelSexo.Text = " Sexo: " + sexo;
            LabelEmail.Text = " Email: " + email;
            LabelDireccion.Text = " Direccion: " + direccion;
            LabelCiudad.Text = " Ciudad: " + ciudad;
            LabelRequerimientos.Text = " Requerimientos: " + requerimientos;
        }
        protected void loadCookies(object sender, EventArgs e)
        {
            HttpCookie datosUsuario = Request.Cookies["SesionUsuario"];
            if( datosUsuario != null )
            {
                string nombre = datosUsuario["Nombre"];
                string apellido = datosUsuario["Apellido"];
                string sexo = datosUsuario["Sexo"];
                string email = datosUsuario["Email"];
                string direccion = datosUsuario["Direccion"];
                string ciudad = datosUsuario["Ciudad"];
                string requerimientos = datosUsuario["Requerimientos"];

                string mensaje = "Nombre: " + nombre + Environment.NewLine;
                mensaje += "Apellido: " + apellido + Environment.NewLine;
                mensaje += "Sexo: " + sexo + Environment.NewLine;
                mensaje += "Email: " + email + Environment.NewLine;
                mensaje += "Dirección: " + direccion + Environment.NewLine;
                mensaje += "Ciudad: " + ciudad + Environment.NewLine;
                mensaje += "Requerimientos: " + Environment.NewLine + requerimientos;

                datosCookies.Text = mensaje;

            }
        }
    }
}