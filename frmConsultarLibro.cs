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

namespace Interfaz
{
    public partial class frmConsultarLibro : Form
    {
        public frmConsultarLibro()
        {
            InitializeComponent();
        }
        void limpiarCajas()
        {
            txtID.Clear();
            txtTitulo.Clear();
            txtAutor.Clear();
            txtEditorial.Clear();
            txtEdicion.Clear();
            txtPrecioVenta.Clear();
            txtDisponibleVenta.Clear();
            txtPrecioRenta.Clear();
            txtDisponibleRenta.Clear();
        }
        private void bttnRegresar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmPrincipal x = new frmPrincipal();
            x.Show();
        }

        private void bttnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int BUSCADO = Convert.ToInt32(txtID.Text);
                int band = 0;
                IDbConnection dbcon = new NpgsqlConnection
                    ("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                dbcon.Open();
                IDbCommand dbcmd = dbcon.CreateCommand();
                dbcmd.CommandText = "select * from libro where id_libro=" + BUSCADO + "";

                IDataReader reader = dbcmd.ExecuteReader();
                if (reader.Read())
                {
                    txtTitulo.Text = reader.GetString(reader.GetOrdinal("titulo"));
                    txtAutor.Text = reader.GetString(reader.GetOrdinal("autor"));
                    txtEditorial.Text = reader.GetString(reader.GetOrdinal("editorial"));
                    txtEdicion.Text = reader.GetString(reader.GetOrdinal("edicion"));
                    txtPrecioVenta.Text = Convert.ToString(reader.GetDecimal(reader.GetOrdinal("precio_venta")));
                    txtDisponibleVenta.Text = Convert.ToString(reader.GetInt32(reader.GetOrdinal("disponible_venta")));
                    txtPrecioRenta.Text = Convert.ToString(reader.GetDecimal(reader.GetOrdinal("precio_renta")));
                    txtDisponibleRenta.Text = Convert.ToString(reader.GetInt32(reader.GetOrdinal("disponible_renta")));
                    band = 1;
                }
                dbcon.Close();
                if (band == 0)
                {
                    MessageBox.Show("Libro NO Encontrado");
                    limpiarCajas();
                }
            }
            catch
            {
                MessageBox.Show("Uno o más campos de entrada son incorrectos, corríjalos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtID.Focus();
        }

        private void bttnModificar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtTitulo.Text == "" || txtEditorial.Text == "" || txtEdicion.Text == "" || txtAutor.Text == "" || txtPrecioVenta.Text == "" || txtPrecioRenta.Text == "" || txtDisponibleVenta.Text == "" || txtDisponibleRenta.Text == "")
            {
                MessageBox.Show("Debes rellenar todos los campos disponibles", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTitulo.Focus();
            }
            else
            {
                try
                {
                    string TITULO = txtTitulo.Text;
                    string EDITORIAL = txtEditorial.Text;
                    string EDICION = txtEdicion.Text;
                    string AUTOR = txtAutor.Text;
                    int BUSCADO = Convert.ToInt16(txtID.Text);
                    NpgsqlConnection dbcon = new NpgsqlConnection("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                    dbcon.Open();
                    NpgsqlCommand cmdUp = new NpgsqlCommand
                        ("update libro set titulo='" + TITULO + "', editorial='" + EDITORIAL + "', edicion='" + EDICION  + "', autor='" + AUTOR +
                        "', precio_venta = " + Convert.ToDecimal(txtPrecioVenta.Text) + ", precio_renta=" + Convert.ToDecimal(txtPrecioRenta.Text) + ", disponible_venta= " + Convert.ToInt16(txtDisponibleVenta.Text) + ", disponible_renta= " + Convert.ToInt16(txtDisponibleRenta.Text) + "  where id_libro=" + BUSCADO + "", dbcon);
                    if (MessageBox.Show("Deseas modificar el libro: "
                                        + txtTitulo.Text + "?",
                                        "Confirmación", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                                        == DialogResult.Yes)
                    {
                        cmdUp.ExecuteNonQuery();
                        MessageBox.Show("Libro modificado correctamente!");
                    }
                    limpiarCajas();
                    txtID.Focus();
                    dbcon.Close();

                }
                catch
                {
                    MessageBox.Show("Uno o más campos de entrada son incorrectos, corríjalos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Sólo se permiten números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || e.KeyChar == 47 || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Sólo se permiten números decimales", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }

        private void txtDisponibleVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Sólo se permiten números enteros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Sólo se permiten números enteros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }
    }
}
