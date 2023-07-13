using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.ServiceReference1;
using WebApplication1.ServiceReference2;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            addDropDownCiudadItems();
        }
        private String[] serviceCall()
        {
            Service1Client cliente = new Service1Client();
            String[] ciudades = cliente.getCiudades();
           
            return ciudades;
        }
        private void addDropDownCiudadItems()
        {
            String[] ciudades = serviceCall();
            Array.Sort(ciudades);
            
            for (int i = 0; i < ciudades.Length; i++)
            {
                string s = ciudades[i];
                OpcionesCiudad.Items.Add(s);
            }
        }
        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string nombre = InputNombre.Text;
                string apellido = InputApellido.Text;
                string sexo = InputSexo.SelectedValue;
                string email = InputEmail.Text;
                string direccion = InputDireccion.Text;
                string ciudad = OpcionesCiudad.SelectedValue;
                string requerimientos = TextAreaRequerimientos.Text;

                string mensaje = "Nombre: " + nombre + Environment.NewLine;
                mensaje += "Apellido: " + apellido + Environment.NewLine;
                mensaje += "Sexo: " + sexo + Environment.NewLine;
                mensaje += "Email: " + email + Environment.NewLine;
                mensaje += "Dirección: " + direccion + Environment.NewLine;
                mensaje += "Ciudad: " + ciudad + Environment.NewLine;
                mensaje += "Requerimientos: " + Environment.NewLine + requerimientos;

                enviarInformacion(nombre,apellido,sexo,email,direccion,ciudad,requerimientos);

                MostrarContenido.Text = mensaje;
                MostrarContenido.Visible = true;

                InputNombre.Text = string.Empty;
                InputApellido.Text = string.Empty;
                InputSexo.ClearSelection();
                InputEmail.Text = string.Empty;
                InputDireccion.Text = string.Empty;
                OpcionesCiudad.ClearSelection();
                TextAreaRequerimientos.Text = string.Empty;
            }
        }
        private void enviarInformacion(string nombre, string apellido, string sexo, string email, string dir, string ciudad, string reque)
        {
            Service2Client cliente = new Service2Client();
            cliente.tomarInformacion(nombre,apellido,sexo,email,dir,ciudad,reque);
        }
    }
}