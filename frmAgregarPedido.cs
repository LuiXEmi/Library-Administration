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

namespace Interfaz
{
    public partial class frmAgregarPedido : Form
    {
        public frmAgregarPedido()
        {
            InitializeComponent();
        }
        int n, i;
        double subtotal;
        DataTable x = new DataTable();
        

        private void txtIdCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Sólo se permiten números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == 13)
                {
                    if (txtIdCliente.Text == "")
                    {
                        MessageBox.Show("DEBES INTRODUCIR EL ID " +
                                        "DEL CLIENTE....");
                        txtIdCliente.Focus();
                    }
                    else
                    {
                        try
                        {
                            IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                            dbcon.Open();
                            n = Convert.ToInt32(txtIdCliente.Text);
                            IDbCommand dbcmd = dbcon.CreateCommand();
                            dbcmd.CommandText = "select * from " + "cliente where id_cliente=" + n + "";
                            IDataReader reader = dbcmd.ExecuteReader();
                            if (reader.Read())
                            {
                                txtNombreCliente.Text = reader.GetString(reader.GetOrdinal("nombre"));
                                dbcon.Close();
                                txtTitulo.Focus();
                            }
                            else
                            {
                                txtIdCliente.Clear();
                                txtNombreCliente.Clear();
                                MessageBox.Show("Cliente no encontrado. . .");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Intenta de nuevo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

        private void frmAgregarPedido_Load(object sender, EventArgs e)
        {
            
            x.Columns.Add("TITULO");
            x.Columns.Add("AUTOR");
            x.Columns.Add("EDITORIAL");
            x.Columns.Add("EDICION");
            x.Columns.Add("CANTIDAD");
            x.Columns.Add("PRECIO");
            x.Columns.Add("IMPORTE");
            dtaVenta.DataSource = x.DefaultView;
            Genera();
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtIdEmpleado.Focus();
        }

        

        private void bttnAgregar_Click(object sender, EventArgs e)
        {
            if (txtTitulo.Text == "" || txtEditorial.Text == "" || txtEdicion.Text == "" || txtAutor.Text == "" || txtCantidad.Text == "" || txtPrecio.Text == "")
            {
                MessageBox.Show("Debes rellenar todos los campos disponibles", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {


                    if (Convert.ToInt16(txtCantidad.Text) <= 0)
                    {
                        MessageBox.Show("Debes introducir una cantidad mayor a cero", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCantidad.Clear();
                        txtCantidad.Focus();
                    }
                    if (Convert.ToDouble(txtPrecio.Text) <= 0)
                    {
                        MessageBox.Show("Debes introducir un precio mayor a cero", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCantidad.Clear();
                        txtCantidad.Focus();
                    }
                    else
                    {

                        if (MessageBox.Show("Deseas agregar el libro al pedido?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            x.Rows.Add();

                            dtaVenta.Rows[i].Cells[0].Value = txtTitulo.Text;
                            dtaVenta.Rows[i].Cells[1].Value = txtAutor.Text;
                            dtaVenta.Rows[i].Cells[2].Value = txtEditorial.Text;
                            dtaVenta.Rows[i].Cells[3].Value = txtEdicion.Text;
                            dtaVenta.Rows[i].Cells[4].Value = txtCantidad.Text;
                            dtaVenta.Rows[i].Cells[5].Value = txtPrecio.Text;
                            dtaVenta.Rows[i].Cells[6].Value = Convert.ToDouble(txtPrecio.Text) * Convert.ToDouble(txtCantidad.Text);
                            subtotal = subtotal + Convert.ToDouble(dtaVenta.Rows[i].Cells[6].Value);
                            dtaVenta.Refresh();
                            txtTitulo.Text = "";
                            txtAutor.Text = "";
                            txtEditorial.Text = "";
                            txtEdicion.Text = "";
                            txtCantidad.Text = "";
                            txtPrecio.Text = "";
                            txtTitulo.Focus();
                            i++;

                            lblSubtotal.Text = Convert.ToString(subtotal);
                            lblIVA.Text = Convert.ToString(subtotal * .16);
                            lblTotal.Text = Convert.ToString(subtotal * 1.16);
                        }
                        txtTitulo.Clear();
                        txtAutor.Clear();
                        txtEditorial.Clear();
                        txtEdicion.Clear();
                        txtCantidad.Clear();
                        txtPrecio.Clear();
                        txtTitulo.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Uno o más campos de entrada son incorrectos, corríjalos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void bttnGuardar_Click(object sender, EventArgs e)
        {
            if(txtIdEmpleado.Text == "" || txtIdCliente.Text == "")
            {
                MessageBox.Show("INGRESA UN ID DE EMPLEADO Y CLIENTE VÁLIDO");
                txtIdEmpleado.Focus();
            }
            else
            {
                if(MessageBox.Show("Deseas guardar el pedido?", "CONFIRMACIÓN", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    if(i > 0)
                    {
                        try
                        {
                            int contador = 0, existnew;
                            NpgsqlConnection dbcon = new NpgsqlConnection("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                            dbcon.Open();
                            
                            IDbCommand dbcmdVenta = dbcon.CreateCommand();
                            dbcmdVenta.CommandText =
                                "insert into pedido values(" + Convert.ToInt16(lblIdVenta.Text) + "," + Convert.ToInt16(txtIdEmpleado.Text) + "," + Convert.ToInt16(txtIdCliente.Text) + ",'" + lblFecha.Text + "','SIN ENTREGAR'" + ")";
                            IDataReader reader = dbcmdVenta.ExecuteReader();
                            MessageBox.Show("PEDIDO REALIZADO CON ÉXITO.....");
                            txtIdEmpleado.Focus();
                            dbcon.Close();
                            contador = 0;
                            while (i != contador)
                            {
                                IDbConnection dbconVenta_Libro = new NpgsqlConnection
                               ("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                                dbconVenta_Libro.Open();
                                IDbCommand dbcmdVenta_Libro = dbconVenta_Libro.CreateCommand();
                                dbcmdVenta_Libro.CommandText =
                                     "insert into  pedido_libro  (id_pedido,titulo,editorial,edicion,autor,cantidad,precio) values(" + Convert.ToInt16(lblIdVenta.Text) + ",'" + Convert.ToString(dtaVenta.Rows[contador].Cells[0].Value) + "','" + Convert.ToString(dtaVenta.Rows[contador].Cells[2].Value) + "','" + Convert.ToString(dtaVenta.Rows[contador].Cells[3].Value) + "','" + Convert.ToString(dtaVenta.Rows[contador].Cells[1].Value) + "', " + Convert.ToInt32(dtaVenta.Rows[contador].Cells[4].Value) + "," + Convert.ToDecimal(dtaVenta.Rows[contador].Cells[5].Value) + ")";
                                IDataReader reader2 = dbcmdVenta_Libro.ExecuteReader();
                                contador++;
                            }
                            txtIdEmpleado.Clear();
                            txtNombreEmpleado.Clear();
                            txtIdCliente.Clear();
                            txtNombreCliente.Clear();
                            txtCantidad.Clear();
                            txtTitulo.Clear();
                            txtPrecio.Clear();
                            txtAutor.Clear();
                            txtEditorial.Clear();
                            txtEdicion.Clear();
                            Genera();
                            i = 0;
                            lblSubtotal.Text = "";
                            lblTotal.Text = "";
                            lblIVA.Text = "";
                            subtotal = 0;
                            x.Rows.Clear();
                        }
                        catch
                        {
                            MessageBox.Show("Intenta de nuevo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("PRIMERO DEBES INTRODUCIR LIBROS.....");
                    }
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Sólo se permiten números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || e.KeyChar == 47 || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Sólo se permiten números decimales ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void txtIdEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Sólo se permiten números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
            else
            {


                if (e.KeyChar == 13)
                {
                    if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
                    {
                        MessageBox.Show("Sólo se permiten números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Handled = true;
                    }
                    else
                    {
                        if (txtIdEmpleado.Text == "")
                        {
                            MessageBox.Show("DEBES INTRODUCIR EL ID " +
                                            "DEL EMPLEADO....");
                            txtIdEmpleado.Focus();
                        }
                        else
                        {
                            try
                            {
                                IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                                dbcon.Open();
                                n = Convert.ToInt32(txtIdEmpleado.Text);
                                IDbCommand dbcmd = dbcon.CreateCommand();
                                dbcmd.CommandText = "select * from " + "empleado where id_empleado=" + n + "";
                                IDataReader reader = dbcmd.ExecuteReader();
                                if (reader.Read())
                                {
                                    txtNombreEmpleado.Text = reader.GetString(reader.GetOrdinal("nombre"));
                                    dbcon.Close();
                                    txtIdCliente.Focus();
                                }
                                else
                                {
                                    txtIdEmpleado.Clear();
                                    txtNombreEmpleado.Clear();
                                    MessageBox.Show("Empleado no encontrado. . .");
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Intenta de nuevo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
            }
        }

        public void Genera()
        {
            try
            {
                int sigue;
                NpgsqlConnection dbcon = new NpgsqlConnection("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                dbcon.Open();
                IDbCommand dbcmd = dbcon.CreateCommand();
                dbcmd.CommandText ="select id_pedido from pedido order by id_pedido desc limit 1";
                IDataReader reader = dbcmd.ExecuteReader();
                if (reader.Read())
                {

                    sigue =
                        Convert.ToInt32
                        (reader.GetInt32(reader.GetOrdinal("id_pedido")) + 1);
                    lblIdVenta.Text = Convert.ToString(sigue);
                    dbcon.Close();
                }
                else
                {
                    lblIdVenta.Text = "1";
                }

            }
            catch
            {
                MessageBox.Show("Intenta de nuevo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void bttnRegresar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmPrincipal x = new frmPrincipal();
            x.Show();
        }
    }
}
