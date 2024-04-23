using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Npgsql;

namespace Interfaz
{
    public partial class frmMostrarEmpleado : Form
    {
        public frmMostrarEmpleado()
        {
            InitializeComponent();
        }

        private void bttnRegresar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmPrincipal x = new frmPrincipal();
            x.Show();
        }

        private void frmMostrarEmpleado_Load(object sender, EventArgs e)
        {
            DataTable memoria = new DataTable();
            try
            {

                NpgsqlConnection conexion = new NpgsqlConnection("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                NpgsqlDataAdapter datosConsulta = new NpgsqlDataAdapter("select * from empleado", conexion);
                datosConsulta.Fill(memoria);
                dgvDatos.DataSource = memoria.DefaultView;
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }
        }

        private void frmMostrarEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process proceso = new Process();
            proceso.StartInfo = new
                ProcessStartInfo("cierre.bat");
            proceso.StartInfo.WindowStyle =
                ProcessWindowStyle.Minimized;
            proceso.Start();
            Application.Exit();
        }
    }
}
