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
    public partial class frmConsultarCliente : Form
    {
        public frmConsultarCliente()
        {
            InitializeComponent();
        }
        void limpiarCajas()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtEdad.Clear();
            txtDomicilio.Clear();
            txtCelular.Clear();
            txtCorreo.Clear();
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
                dbcmd.CommandText = "select * from cliente where id_cliente=" + BUSCADO + "";

                IDataReader reader = dbcmd.ExecuteReader();
                if (reader.Read())
                {
                    txtNombre.Text = reader.GetString(reader.GetOrdinal("nombre"));
                    txtEdad.Text = reader.GetString(reader.GetOrdinal("edad"));
                    txtDomicilio.Text = reader.GetString(reader.GetOrdinal("domicilio"));
                    txtCelular.Text = reader.GetString(reader.GetOrdinal("celular"));
                    txtCorreo.Text = reader.GetString(reader.GetOrdinal("correo"));
                    band = 1;
                }
                dbcon.Close();
                if (band == 0)
                {
                    MessageBox.Show("Cliente NO Encontrado");
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
            if (txtID.Text == "" || txtNombre.Text == "" || txtEdad.Text == "" || txtDomicilio.Text == "" || txtCelular.Text == "" || txtCorreo.Text == "")
            {
                MessageBox.Show("Debes rellenar todos los campos disponibles", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Focus();
            }
            else
            {
                try
                {
                    string NOMBRE = txtNombre.Text, EDAD = txtEdad.Text, DOMICILIO = txtDomicilio.Text, CELULAR = txtCelular.Text, CORREO = txtCorreo.Text;
                    int BUSCADO = Convert.ToInt16(txtID.Text);
                    NpgsqlConnection dbcon = new NpgsqlConnection("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                    dbcon.Open();
                    NpgsqlCommand cmdUp = new NpgsqlCommand
                        ("update cliente set nombre='" + NOMBRE + "', edad='" + EDAD + "', domicilio='" + DOMICILIO +
                        "', celular='" + CELULAR + "', correo='" + CORREO + "' where id_cliente=" + BUSCADO + "", dbcon);
                    if (MessageBox.Show("Deseas modificar el cliente: "
                                        + txtNombre.Text + "?",
                                        "Confirmación", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                                        == DialogResult.Yes)
                    {
                        cmdUp.ExecuteNonQuery();
                        MessageBox.Show("Cliente modificado correctamente!");
                    }
                    limpiarCajas();
                    txtID.Focus();
                    dbcon.Close();

                }
                catch (Exception msg)
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
                MessageBox.Show("Sólo se permiten números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Sólo se permiten números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Sólo se permiten números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }
    }
}
