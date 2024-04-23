using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Interfaz.Clases
{
    class CConexion
    {
        NpgsqlConnection conexion = new NpgsqlConnection();

        static String servidor = "localhost";
        static String bd = "LIRA";
        static String usuario = "postgres";
        static String password = "postgres";
        static String puerto = "5432";

        String cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";

        public NpgsqlConnection establecerConexion()
        {
            try
            {
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
                MessageBox.Show("Se conectó a la base de datos =)");
            }
            catch (NpgsqlException e)
            { 
                MessageBox.Show("No se puso conectar a la base de datos. ERROR: "+ e.ToString());
            }
            return conexion;
        }

    }
}
