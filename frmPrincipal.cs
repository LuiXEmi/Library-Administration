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

namespace Interfaz
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clases.CConexion objetoConexion = new Clases.CConexion();
            objetoConexion.establecerConexion();
        }

        private void AGREGARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmAgregarLibro x = new frmAgregarLibro();
            x.Show();
        }

        void FrmPrincipalLoad(object sender, EventArgs e)
        {

            Process proceso = new Process();
            proceso.StartInfo = new
                ProcessStartInfo("arranque.bat");
            proceso.StartInfo.WindowStyle =
                ProcessWindowStyle.Minimized;
            proceso.Start();
        }
        void FrmPrincipalFormClosing(object sender, FormClosingEventArgs e)
        {
            Process proceso = new Process();
            proceso.StartInfo = new
                ProcessStartInfo("cierre.bat");
            proceso.StartInfo.WindowStyle =
                ProcessWindowStyle.Minimized;
            proceso.Start();
            Application.Exit();
        }

        private void bUSCARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmConsultarLibro x = new frmConsultarLibro();
            x.Show();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process proceso = new Process();
            proceso.StartInfo = new ProcessStartInfo("cierre.bat");
            proceso.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            proceso.Start();
            Application.Exit();
        }

        private void aGREGARToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmAgregarEmpleado x = new frmAgregarEmpleado();
            x.Show();
        }

        private void cONSULTARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmConsultarEmpleado x = new frmConsultarEmpleado();
            x.Show();
        }

        private void aGREGARToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmAgregarCliente x = new frmAgregarCliente();
            x.Show();
        }

        private void cONSULTARToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmConsultarCliente x = new frmConsultarCliente();
            x.Show();
        }

        private void aGREGARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmAgregarVenta x = new frmAgregarVenta();
            x.Show();
        }

        private void buscarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmBuscarVenta x = new frmBuscarVenta();
            x.Show();
        }

        private void mOSTRARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmMostrarLibro x = new frmMostrarLibro();
            x.Show();
        }

        private void mOSTRARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmMostrarEmpleado x = new frmMostrarEmpleado();
            x.Show();
        }

        private void mOSTRARToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmMostrarCliente x = new frmMostrarCliente();
            x.Show();
        }

        private void aGREGARToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmAgregarRenta x = new frmAgregarRenta();
            x.Show();
        }

        private void bUSCARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmBuscarRenta x = new frmBuscarRenta();
            x.Show();
        }

        private void aGREGARToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmAgregarPedido x = new frmAgregarPedido();
            x.Show();
        }

        private void bUSCARToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmBuscarPedido x = new frmBuscarPedido();
            x.Show();
        }
    }
}
