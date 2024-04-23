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
    public partial class frmBuscarPedido : Form
    {
        public frmBuscarPedido()
        {
            InitializeComponent();
        }

        DataTable x = new DataTable();
        int i, n, nombreCliente;

        private void bttnEntrega_Click(object sender, EventArgs e)
        {
            if (lblIdRenta.Text == "0")
            {
                MessageBox.Show("Debes introducir un ID de Pedido válido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtBuscarId.Focus();
            }
            if (lblEstado.Text == "ENTREGADO")
            {
                MessageBox.Show("EL PEDIDO YA HA SIDO ENTREGADO");
                txtBuscarId.Focus();
            }
            else
            {
                try
                {
                    int BUSCADO = Convert.ToInt16(lblIdRenta.Text);
                    NpgsqlConnection dbcon = new NpgsqlConnection("Server=localhost;" + "Database=LIRA;" + "User ID=postgres;" + "port=5432;" + "password=postgres");
                    dbcon.Open();
                    NpgsqlCommand cmdUp = new NpgsqlCommand
                        ("update pedido set estado='ENTREGADO' where id_pedido=" + BUSCADO + "", dbcon);
                    if (MessageBox.Show("Deseas Confirmar la Entrega?:", "CONFIRMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        cmdUp.ExecuteNonQuery();
                        MessageBox.Show("PEDIDO ENTREGADO");
                    }
                    txtBuscarId.Clear();
                    txtIdEmpleado.Clear();
                    txtNombreEmpleado.Clear();
                    txtIdCliente.Clear();
                    txtNombreCliente.Clear();
                    lblIdRenta.Text = "-";
                    lblFecha.Text = "-";
                    lblSubtotal.Text = "-";
                    lblIVA.Text = "-";
                    lblTotal.Text = "-";
                    lblEstado.Text = "-";
                    x.Rows.Clear();
                    txtBuscarId.Focus();
                    dbcon.Close();

                }
                catch
                {
                    MessageBox.Show("Intenta de nuevo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

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
                    dbcmd.CommandText = "select * from pedido where id_pedido=" + txtBuscarId.Text + "";

                    IDataReader reader = dbcmd.ExecuteReader();
                    if (reader.Read())
                    {

                        txtIdEmpleado.Text = Convert.ToString(reader.GetInt32(reader.GetOrdinal("id_empleado")));

                        txtIdCliente.Text = Convert.ToString(reader.GetInt32(reader.GetOrdinal("id_cliente")));


                        lblEstado.Text = reader.GetString(reader.GetOrdinal("estado"));
                        lblFecha.Text = reader.GetString(reader.GetOrdinal("fecha_pedido"));
                        lblIdRenta.Text = txtBuscarId.Text;

                        band = 1;
                    }
                    reader.Close();

                    if (band == 1)
                    {
                        IDbCommand comandoDetalleVenta = dbcon.CreateCommand();
                        comandoDetalleVenta.CommandText = "select * from pedido_libro where id_pedido=" + Convert.ToInt16(lblIdRenta.Text) + "";
                        IDataReader readerDetalleVenta = comandoDetalleVenta.ExecuteReader();
                        i = 0;
                        while (readerDetalleVenta.Read())
                        {
                            x.Rows.Add();
                            dtaVenta.Rows[i].Cells[0].Value = readerDetalleVenta.GetString(readerDetalleVenta.GetOrdinal("titulo"));
                            dtaVenta.Rows[i].Cells[1].Value = readerDetalleVenta.GetString(readerDetalleVenta.GetOrdinal("autor"));
                            dtaVenta.Rows[i].Cells[2].Value = readerDetalleVenta.GetString(readerDetalleVenta.GetOrdinal("editorial"));
                            dtaVenta.Rows[i].Cells[3].Value = readerDetalleVenta.GetString(readerDetalleVenta.GetOrdinal("edicion"));
                            dtaVenta.Rows[i].Cells[4].Value = readerDetalleVenta.GetInt32(readerDetalleVenta.GetOrdinal("cantidad"));
                            dtaVenta.Rows[i].Cells[5].Value = readerDetalleVenta.GetDecimal(readerDetalleVenta.GetOrdinal("precio"));
                            dtaVenta.Rows[i].Cells[6].Value = Convert.ToDouble(dtaVenta.Rows[i].Cells[4].Value) * Convert.ToDouble(dtaVenta.Rows[i].Cells[5].Value);
                            subtotal = subtotal + Convert.ToDouble(dtaVenta.Rows[i].Cells[6].Value);
                            i++;
                        }
                        readerDetalleVenta.Close();


                        

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
                        MessageBox.Show("Pedido No Encontrado......");
                    }

                }
                catch
                {
                    MessageBox.Show("Debes ingresar un número de ID existente");
                }
                txtBuscarId.Clear();
                txtBuscarId.Focus();
            }
        }

        private void frmBuscarPedido_Load(object sender, EventArgs e)
        {
            x.Columns.Add("TITULO");
            x.Columns.Add("AUTOR");
            x.Columns.Add("EDITORIAL");
            x.Columns.Add("EDICION");
            x.Columns.Add("CANTIDAD");
            x.Columns.Add("PRECIO");
            x.Columns.Add("IMPORTE");
            dtaVenta.DataSource = x.DefaultView;
        }
    }
}
