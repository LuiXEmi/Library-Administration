using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Mono.Security;
using System.Diagnostics;

namespace Interfaz
{
    public partial class frmAgregarLibro : Form
    {
        public frmAgregarLibro()
        {
            InitializeComponent();
        }

        private void bttnAgregar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtTitulo.Text == "" || txtEditorial.Text == "" || txtEdicion.Text == "" || txtAutor.Text == "" || txtPrecioVenta.Text == "" || txtPrecioRenta.Text == "" || txtDisponibleVenta.Text == "" || txtDisponibleRenta.Text == "")
            {
                MessageBox.Show("Debes rellenar todos los campos disponibles", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    string TITULO = txtTitulo.Text;
                    string EDITORIAL = txtEditorial.Text;
                    string EDICION = txtEdicion.Text;
                    string AUTOR = txtAutor.Text;
                    IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                    dbcon.Open();
                    IDbCommand dbcmd = dbcon.CreateCommand();
                    dbcmd.CommandText = "insert into libro values(" + Convert.ToInt16(txtID.Text) + ",'" + TITULO + "','" + EDITORIAL + "','" + EDICION + "','" + AUTOR + "'," + Convert.ToDecimal(txtPrecioVenta.Text) + ", " + Convert.ToDecimal(txtPrecioRenta.Text) + "," + Convert.ToInt16(txtDisponibleVenta.Text) + "," + Convert.ToInt16(txtDisponibleRenta.Text) + " )";
                    IDataReader reader = dbcmd.ExecuteReader();
                    dbcon.Close();
                    txtID.Clear();
                    txtTitulo.Clear();
                    txtEditorial.Clear();
                    txtEdicion.Clear();
                    txtAutor.Clear();
                    txtPrecioVenta.Clear();
                    txtPrecioRenta.Clear();
                    txtDisponibleVenta.Clear();
                    txtDisponibleRenta.Clear();
                    MessageBox.Show("Libro guardado correctamente!");
                }
                catch
                {
                    MessageBox.Show("Uno o más campos de entrada son incorrectos, corríjalos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void bttnRegresar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmPrincipal x = new frmPrincipal();
            x.Show();
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Sólo se permiten números","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                e.Handled = true; 
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || e.KeyChar == 47 || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Sólo se permiten números decimales ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }

        private void txtDisponibleVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Sólo se permiten números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }

        private void txtPrecioRenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || e.KeyChar == 47 || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Sólo se permiten números decimales", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }

        private void txtDisponibleRenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Sólo se permiten números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }
    }
}
