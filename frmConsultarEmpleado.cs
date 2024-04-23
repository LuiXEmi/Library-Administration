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
    public partial class frmConsultarEmpleado : Form
    {
        public frmConsultarEmpleado()
        {
            InitializeComponent();
        }

        void limpiarCajas()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtEdad.Clear();
            txtRfc.Clear();
            txtDomicilio.Clear();
            txtCelular.Clear();
            txtNss.Clear();
            txtPuesto.Clear();
        }

        //Botón Buscar
        private void bttnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int BUSCADO = Convert.ToInt32(txtID.Text);
                int band = 0;
                IDbConnection dbcon = new NpgsqlConnection
                    ("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                dbcon.Open();
                IDbCommand dbcmd = dbcon.CreateCommand();
                dbcmd.CommandText = "select * from empleado where id_empleado=" + BUSCADO + "";

                IDataReader reader = dbcmd.ExecuteReader();
                if (reader.Read())
                {
                    txtNombre.Text = reader.GetString(reader.GetOrdinal("nombre"));
                    txtEdad.Text = reader.GetString(reader.GetOrdinal("edad"));
                    txtRfc.Text = reader.GetString(reader.GetOrdinal("rfc"));
                    txtDomicilio.Text = reader.GetString(reader.GetOrdinal("domicilio"));
                    txtCelular.Text = reader.GetString(reader.GetOrdinal("celular"));
                    txtNss.Text = reader.GetString(reader.GetOrdinal("nss"));
                    txtPuesto.Text = reader.GetString(reader.GetOrdinal("puesto"));
                    band = 1;
                }
                dbcon.Close();
                if (band == 0)
                {
                    MessageBox.Show("Empleado NO Encontrado. . .");
                    limpiarCajas();
                }
            }
            catch
            {
                MessageBox.Show("Uno o más campos de entrada son incorrectos, corríjalos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtID.Focus();
        }

        //Botón Modificar
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtNombre.Text == "" || txtEdad.Text == "" || txtRfc.Text == "" || txtDomicilio.Text == "" || txtCelular.Text == "" || txtNss.Text == "" || txtPuesto.Text == "")
            {
                MessageBox.Show("Debes rellenar todos los campos disponibles", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Focus();
            }
            else
            {
                try
                {
                    string NOMBRE = txtNombre.Text, EDAD = txtEdad.Text, RFC = txtRfc.Text, DOMICILIO = txtDomicilio.Text, CELULAR = txtCelular.Text, NSS = txtNss.Text, PUESTO = txtPuesto.Text;
                    int BUSCADO = Convert.ToInt16(txtID.Text);
                    NpgsqlConnection dbcon = new NpgsqlConnection("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                    dbcon.Open();
                    NpgsqlCommand cmdUp = new NpgsqlCommand
                        ("update empleado set nombre='" + NOMBRE + "', edad='" + EDAD + "', rfc='" + RFC + "', domicilio='" + DOMICILIO +
                        "', celular='" + CELULAR + "', nss='" + NSS + "', puesto='" + PUESTO + "'  where id_empleado=" + BUSCADO + "", dbcon);
                    if (MessageBox.Show("Deseas Modificar El Empleado: "
                                        + txtNombre.Text + "?",
                                        "CONFIRMA", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                                        == DialogResult.Yes)
                    {
                        cmdUp.ExecuteNonQuery();
                        MessageBox.Show("REGISTRO MODIFICADO.....");
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

        private void txtRfc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Sólo se permiten números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void txtNss_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Sólo se permiten números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }
    }
}
