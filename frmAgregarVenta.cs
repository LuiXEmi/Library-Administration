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
    public partial class frmAgregarVenta : Form
    {
        public frmAgregarVenta()
        {
            InitializeComponent();
        }

        int n, i, exist;
        double subtotal;
        DataTable x = new DataTable();
        int banderas, cuenta;

        public void Genera()
        {
            try
            {
                int sigue;
                NpgsqlConnection dbcon = new NpgsqlConnection("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                dbcon.Open();
                IDbCommand dbcmd = dbcon.CreateCommand();
                dbcmd.CommandText = "select id_venta from venta order by id_venta desc limit 1";
                IDataReader reader = dbcmd.ExecuteReader();
                if (reader.Read())
                {

                    sigue =
                        Convert.ToInt32
                        (reader.GetInt32(reader.GetOrdinal("id_venta")) + 1);
                    lblIdVenta.Text = Convert.ToString(sigue);
                    dbcon.Close();
                }
                else
                {
                    lblIdVenta.Text = "1";
                }

            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }

        }
        private void txtBuscarId_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (txtBuscarId.Text == "")
                    {
                        MessageBox.Show("Debes introducir un ID existente de Libro", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtBuscarId.Focus();
                    }
                    else
                    {
                        try
                        {
                            IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                            dbcon.Open();
                            n = Convert.ToInt32(txtBuscarId.Text);
                            IDbCommand dbcmd = dbcon.CreateCommand();
                            dbcmd.CommandText = "select * from " + "libro where id_libro=" + n + "";
                            IDataReader reader = dbcmd.ExecuteReader();
                            if (reader.Read())
                            {
                                txtTitulo.Text =
                                    reader.GetString
                                    (reader.GetOrdinal("titulo"));
                                txtPrecio.Text =
                                    Convert.ToString
                                    (reader.GetDecimal
                                     (reader.GetOrdinal("precio_venta")));
                                exist = reader.GetInt32
                                    (reader.GetOrdinal("disponible_venta"));
                                txtBuscarId.Text = "";
                                dbcon.Close();
                                txtCantidad.Focus();
                            }
                            else
                            {
                                txtBuscarId.Clear();
                                txtTitulo.Clear();
                                txtPrecio.Clear();
                                MessageBox.Show
                                    ("Libro no encontrado");
                            }
                        }
                        catch (Exception msg)
                        {
                            MessageBox.Show("Uno o más campos de entrada son incorrectos, corríjalos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
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
            else
            {
                if (e.KeyChar == 13)
                {
                    if (txtCantidad.Text == "")
                    {
                        MessageBox.Show("Debes introducir una cantidad mayor a cero", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                            else
                            {
                                BuscarEnGrid();
                                if (Convert.ToInt32(txtCantidad.Text) <= exist)
                                {


                                    if (MessageBox.Show("Deseas agregar el libro a la venta?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {


                                        if (banderas == 1)
                                        {
                                            if ((Convert.ToInt32(txtCantidad.Text) + Convert.ToInt32(dtaVenta.Rows[cuenta].Cells[2].Value)) <= exist)
                                            {

                                                subtotal = subtotal - Convert.ToDouble(dtaVenta.Rows[cuenta].Cells[4].Value);
                                                dtaVenta.Rows[cuenta].Cells[2].Value = Convert.ToInt16(dtaVenta.Rows[cuenta].Cells[2].Value) +
                                                Convert.ToInt16(txtCantidad.Text);

                                                dtaVenta.Rows[cuenta].Cells[4].Value = Convert.ToInt16(dtaVenta.Rows[cuenta].Cells[2].Value) *
                                                Convert.ToDouble(txtPrecio.Text);

                                                subtotal = subtotal + Convert.ToDouble
                                                (dtaVenta.Rows[cuenta].Cells[4].Value);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Se supera la existencia disponible");
                                            }

                                        }
                                        else
                                        {
                                            x.Rows.Add();
                                            dtaVenta.Rows[i].Cells[0].Value = n;
                                            dtaVenta.Rows[i].Cells[1].Value =
                                                txtTitulo.Text;
                                            dtaVenta.Rows[i].Cells[2].Value =
                                                txtCantidad.Text;
                                            dtaVenta.Rows[i].Cells[3].Value =
                                                txtPrecio.Text;
                                            dtaVenta.Rows[i].Cells[4].Value =
                                                Convert.ToDouble(txtPrecio.Text)
                                                * Convert.ToDouble(txtCantidad.Text);
                                            subtotal = subtotal
                                                + Convert.ToDouble
                                                (dtaVenta.Rows[i].Cells[4].Value);
                                            dtaVenta.Refresh();
                                            txtCantidad.Text = "";
                                            txtTitulo.Text = "";
                                            txtPrecio.Text = "";
                                            txtBuscarId.Focus();
                                            i++;
                                        }
                                        lblSubtotal.Text = Convert.ToString(subtotal);
                                        lblIVA.Text = Convert.ToString(subtotal * .16);
                                        lblTotal.Text = Convert.ToString(subtotal * 1.16);
                                    }
                                    txtCantidad.Clear();
                                    txtTitulo.Clear();
                                    txtPrecio.Clear();
                                    txtBuscarId.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Excedes la existencia, la cantidad disponible es de " + exist + " libros");
                                    txtCantidad.Text = "";
                                    txtCantidad.Focus();
                                }

                            }
                        }
                        catch
                        {
                            MessageBox.Show("Ingresa una cantidad válida", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtCantidad.Clear();
                            txtCantidad.Focus();
                        }
                    }
                }
            }
        }

        
        private void bttnAgregar_Click(object sender, EventArgs e)
        {
            if (txtIdEmpleado.Text == "" || txtIdCliente.Text == "")
            {
                MessageBox.Show("INGRESA UN ID DE EMPLEADO Y CLIENTE VÁLIDO");
                txtIdEmpleado.Focus();
            }
            else
            {


                if (MessageBox.Show("DESEAS GRABAR LA FACTURA?", "CONFIRMACIÓN",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                                    System.Windows.Forms.DialogResult.Yes)
                {
                    if (i > 0)
                    {
                        try
                        {
                            int contador = 0, existnew;
                            NpgsqlConnection dbcon = new NpgsqlConnection("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                            dbcon.Open();
                            while (i != contador)
                            {
                                n =
                                    Convert.ToInt32
                                    (dtaVenta.Rows[contador].Cells[0].Value);
                                existnew =
                                    Convert.ToInt32(dtaVenta.Rows[contador].Cells[2].Value);
                                string queryUp =
                                    "update libro set disponible_venta=disponible_venta-" + existnew +
                                    " where id_libro=" + n + "";
                                NpgsqlCommand cmdUp =
                                    new NpgsqlCommand(queryUp, dbcon);
                                cmdUp.ExecuteNonQuery();
                                contador++;


                            }



                            IDbCommand dbcmdVenta = dbcon.CreateCommand();
                            dbcmdVenta.CommandText =
                                "insert into venta values(" + Convert.ToInt16(lblIdVenta.Text) + ", " + Convert.ToInt16(txtIdEmpleado.Text) + ", '" + lblFecha.Text + "', " + Convert.ToInt16(txtIdCliente.Text) + ")";
                            IDataReader reader = dbcmdVenta.ExecuteReader();
                            MessageBox.Show("VENTA REALIZADA CON ÉXITO.....");
                            txtBuscarId.Focus();
                            dbcon.Close();
                            contador = 0;
                            while (i != contador)
                            {
                                IDbConnection dbconVenta_Libro = new NpgsqlConnection
                               ("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                                dbconVenta_Libro.Open();
                                IDbCommand dbcmdVenta_Libro = dbconVenta_Libro.CreateCommand();
                                dbcmdVenta_Libro.CommandText =
                                     "insert into  venta_libro  (id_libro,id_venta,precio,cantidad) values(" + Convert.ToInt32(dtaVenta.Rows[contador].Cells[0].Value) + ", " + Convert.ToInt16(lblIdVenta.Text) + ", " + Convert.ToDecimal(dtaVenta.Rows[contador].Cells[3].Value) + ", " + Convert.ToInt32(dtaVenta.Rows[contador].Cells[2].Value) + ")";
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
                    if (txtIdEmpleado.Text == "")
                    {
                        MessageBox.Show("Debes introducir un ID existente de Empleado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                                MessageBox.Show("Empleado no encontrado");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Uno o más campos de entrada son incorrectos, corríjalos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

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
                        MessageBox.Show("Debes introducir un ID existente de Cliente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                                txtBuscarId.Focus();
                            }
                            else
                            {
                                txtIdCliente.Clear();
                                txtNombreCliente.Clear();
                                MessageBox.Show("Cliente no encontrado");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Uno o más campos de entrada son incorrectos, corríjalos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

        private void frmAgregarVenta_Load(object sender, EventArgs e)
        {
            x.Columns.Add("ID_LIBRO");
            x.Columns.Add("TITULO");
            x.Columns.Add("CANTIDAD");
            x.Columns.Add("PRECIO");
            x.Columns.Add("IMPORTE");
            dtaVenta.DataSource = x.DefaultView;
            Genera();
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtBuscarId.Focus();
        }

        public void BuscarEnGrid()
        {
            cuenta = 0;
            banderas = 0;
            do
            {
                int h = Convert.ToInt16(dtaVenta.Rows[cuenta].Cells[0].Value);
                if (h == n)
                {
                    banderas = 1;
                    break;

                }
                cuenta++;
            }
            while (cuenta < i);
        }

        private void bttnRegresar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmPrincipal x = new frmPrincipal();
            x.Show();
        }


    }
}
