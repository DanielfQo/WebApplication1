using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectData
{
    class DBconnection
    {
        public static void Main(String[] args)
        {
            DBconnection db = new DBconnection();
            db.query();
            Console.ReadKey();
        }
        private void query()
        {
            Ciudad c = new Ciudad();
            IList<String> ciudades = c.getCiudades();
            if (ciudades == null)
            {
                Console.WriteLine("Datos no encontrados");
                return;
            }
            for (int i = 0; i < ciudades.Count; i++)
            {
                Console.WriteLine(ciudades[i]);
            }
        }
    }
    
}
