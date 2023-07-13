using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;

namespace ProyectData
{
    public class Ciudad
    {
        public IList<String> getCiudades()
        {
            List<String> ciudades = new List<String>();
            string conexion = "Data Source=(localdb)\\ProjectModels;Initial Catalog=BaseDeDatos;Integrated Security=True;";
            string consulta = "SELECT Ciudad FROM DataCiudad";
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                SqlCommand command = new SqlCommand(consulta, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string ciudad = reader.GetString(0);
                    ciudades.Add(ciudad);
                }

                reader.Close();
            }
            return ciudades;
        }
    }
}
