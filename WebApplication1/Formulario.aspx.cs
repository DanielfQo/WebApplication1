using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.ServiceReference1;
using WebApplication1.ServiceReference2;
using System.Data.SqlClient;
using System.Web.Services;

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

                crearSesion(nombre, apellido, sexo, email, direccion, ciudad, requerimientos);
                crearCookie(nombre, apellido, sexo, email, direccion, ciudad, requerimientos);
                Response.Redirect("Auxiliar");
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
        private void crearSesion(string nombre, string apellido, string sexo, string email, string dir, string ciudad, string reque)
        {
            Session["Nombre"] = nombre;
            Session["Apellido"] = apellido;
            Session["Sexo"] = sexo;
            Session["Email"] = email;
            Session["Direccion"] = dir;
            Session["Ciudad"] = ciudad;
            Session["Requerimientos"] = reque;
        }
        private void crearCookie(string nombre, string apellido, string sexo, string email, string dir, string ciudad, string reque)
        {
            HttpCookie datosUsuario = new HttpCookie("SesionUsuario");

            datosUsuario["Nombre"] = nombre;
            datosUsuario["Apellido"] = apellido;
            datosUsuario["Sexo"] = sexo;
            datosUsuario["Email"] = email;
            datosUsuario["Direccion"] = dir;
            datosUsuario["Ciudad"] = ciudad;
            datosUsuario["Requerimientos"] = reque;

            datosUsuario.Expires = DateTime.Now.AddMinutes(2);
            Response.Cookies.Add(datosUsuario);
        }

        [WebMethod]
        public static bool verificarNombreApellido(string nombre, string apellido)
        {
            bool noexiste = false;
            string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=BaseDeDatos;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string consulta = "SELECT COUNT(*) FROM dbo.DataAlumnos WHERE Nombre = @Nombre AND Apellidos = @Apellidos";
                using (SqlCommand command = new SqlCommand(consulta, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellidos", apellido);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        noexiste = true;
                        return noexiste;
                    }
                }
                
            }
            return noexiste;
        }
    }
    
}