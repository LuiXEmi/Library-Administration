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
    public partial class frmBuscarVenta : Form
    {
        public frmBuscarVenta()
        {
            InitializeComponent();
        }

        DataTable x = new DataTable();
        int i,n,nombreCliente;

        private void bttnRegresar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmPrincipal x = new frmPrincipal();
            x.Show();
        }

        private void txtBuscarId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Sólo se permiten números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void frmBuscarVenta_Load(object sender, EventArgs e)
        {
            x.Columns.Add("ID_LIBRO");
            x.Columns.Add("TITULO");
            x.Columns.Add("CANTIDAD");
            x.Columns.Add("PRECIO");
            x.Columns.Add("IMPORTE");
            dtaVenta.DataSource = x.DefaultView;
        }

        private void bttnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarId.Text == "")
            {
                MessageBox.Show("Debes introducir un ID a buscar....");
                txtBuscarId.Focus();
            }
            else
            {
                try
                {
                    x.Rows.Clear();
                    int band = 0;
                    double subtotal = 0;
                    IDbConnection dbcon = new NpgsqlConnection
                    ("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                    dbcon.Open();
                    IDbCommand dbcmd = dbcon.CreateCommand();
                    dbcmd.CommandText = "select * from venta where id_venta=" + txtBuscarId.Text + "";

                    IDataReader reader = dbcmd.ExecuteReader();
                    if (reader.Read())
                    {
                        
                        txtIdEmpleado.Text = Convert.ToString(reader.GetInt32(reader.GetOrdinal("id_empleado")));

                        txtIdCliente.Text = Convert.ToString(reader.GetInt32(reader.GetOrdinal("id_cliente")));

                        lblFecha.Text = reader.GetString(reader.GetOrdinal("fecha_venta"));
                        lblIdVenta.Text = txtBuscarId.Text;

                        band = 1;
                    }
                    reader.Close();

                    if (band == 1)
                    {
                        IDbCommand comandoDetalleVenta = dbcon.CreateCommand();
                        comandoDetalleVenta.CommandText = "select * from venta_libro where id_venta=" + Convert.ToInt16(lblIdVenta.Text) + "";
                        IDataReader readerDetalleVenta = comandoDetalleVenta.ExecuteReader();
                        i = 0;
                        while (readerDetalleVenta.Read())
                        {
                            x.Rows.Add();
                            dtaVenta.Rows[i].Cells[0].Value = readerDetalleVenta.GetInt32(readerDetalleVenta.GetOrdinal("id_libro"));
                            dtaVenta.Rows[i].Cells[3].Value = readerDetalleVenta.GetDecimal(readerDetalleVenta.GetOrdinal("precio"));
                            dtaVenta.Rows[i].Cells[2].Value = readerDetalleVenta.GetInt32(readerDetalleVenta.GetOrdinal("cantidad"));
                            dtaVenta.Rows[i].Cells[4].Value = Convert.ToDouble(dtaVenta.Rows[i].Cells[2].Value) * Convert.ToDouble(dtaVenta.Rows[i].Cells[3].Value);
                            subtotal = subtotal + Convert.ToDouble(dtaVenta.Rows[i].Cells[4].Value);
                            i++;
                        }
                        readerDetalleVenta.Close();


                        int contador = 0;
                        IDbCommand comandoConsultaProducto = dbcon.CreateCommand();

                        while (contador != i)
                        {
                            comandoConsultaProducto.CommandText = "select titulo from libro where id_libro=" + Convert.ToInt16(dtaVenta.Rows[contador].Cells[0].Value) + "";
                            IDataReader readerProducto = comandoConsultaProducto.ExecuteReader();
                            if (readerProducto.Read())
                            {
                                dtaVenta.Rows[contador].Cells[1].Value = readerProducto.GetString(readerProducto.GetOrdinal("titulo"));
                                contador++;
                                readerProducto.Close();
                            }

                        }

                        n = Convert.ToInt32(txtIdEmpleado.Text);
                        IDbCommand dbcmdEmpleado = dbcon.CreateCommand();
                        dbcmdEmpleado.CommandText = "select nombre from empleado where id_empleado=" + n + "";
                        IDataReader readerEmpleado = dbcmdEmpleado.ExecuteReader();

                        if (readerEmpleado.Read())
                        {
                            txtNombreEmpleado.Text = readerEmpleado.GetString(readerEmpleado.GetOrdinal("nombre"));
                            readerEmpleado.Close();

                        }

                        nombreCliente = Convert.ToInt32(txtIdEmpleado.Text);
                        IDbCommand dbcmdCliente = dbcon.CreateCommand();
                        dbcmdCliente.CommandText = "select nombre from cliente where id_cliente=" + nombreCliente + "";
                        IDataReader readerCliente = dbcmdCliente.ExecuteReader();

                        if (readerCliente.Read())
                        {
                            txtNombreCliente.Text = readerCliente.GetString(readerCliente.GetOrdinal("nombre"));
                            readerCliente.Close();

                        }


                        lblSubtotal.Text = Convert.ToString(subtotal);
                        lblIVA.Text = Convert.ToString(subtotal * .16);
                        lblTotal.Text = Convert.ToString(subtotal * 1.16);
                    }
                    dbcon.Close();
                    if (band == 0)
                    {
                        MessageBox.Show("Venta No Encontrada......");
                    }

                }
                catch
                {
                    MessageBox.Show("Venta No Encontrada......");
                }
                txtBuscarId.Clear();
                txtBuscarId.Focus();
            }
        }
    }
}
