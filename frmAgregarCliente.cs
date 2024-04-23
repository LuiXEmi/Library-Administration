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
    public partial class frmAgregarCliente : Form
    {
        public frmAgregarCliente()
        {
            InitializeComponent();
        }

        private void bttnAgregar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtNombre.Text == "" || txtEdad.Text == "" || txtDomicilio.Text == "" || txtCelular.Text == "" || txtCorreo.Text == "")
            {
                MessageBox.Show("Debes rellenar todos los campos disponibles", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    string NOMBRE = txtNombre.Text, EDAD = txtEdad.Text, CORREO = txtCorreo.Text, DOMICILIO = txtDomicilio.Text, CELULAR = txtCelular.Text;

                    IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                    dbcon.Open();
                    IDbCommand dbcmd = dbcon.CreateCommand();
                    dbcmd.CommandText = "insert into cliente values(" + Convert.ToInt16(txtID.Text) + ",'" + NOMBRE + "','" + EDAD + "','" + DOMICILIO + "','" + CELULAR + "','" + CORREO + "' )";
                    IDataReader reader = dbcmd.ExecuteReader();
                    dbcon.Close();
                    txtID.Clear();
                    txtNombre.Clear();
                    txtEdad.Clear();
                    txtDomicilio.Clear();
                    txtCelular.Clear();
                    txtCorreo.Clear();
                    MessageBox.Show("Cliente guardado correctamente!");
                }
                catch (Exception msg)
                {
                    MessageBox.Show("Uno o más campos de entrada son incorrectos, corríjalos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void bttnRegresar_Click_1(object sender, EventArgs e)
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
