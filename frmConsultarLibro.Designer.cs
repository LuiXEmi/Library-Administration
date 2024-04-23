
namespace Interfaz
{
    partial class frmConsultarLibro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultarLibro));
            this.bttnRegresar = new System.Windows.Forms.Button();
            this.txtDisponibleRenta = new System.Windows.Forms.TextBox();
            this.txtDisponibleVenta = new System.Windows.Forms.TextBox();
            this.txtPrecioRenta = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.txtEdicion = new System.Windows.Forms.TextBox();
            this.txtEditorial = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bttnBuscar = new System.Windows.Forms.Button();
            this.bttnModificar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bttnRegresar
            // 
            this.bttnRegresar.Location = new System.Drawing.Point(678, 376);
            this.bttnRegresar.Margin = new System.Windows.Forms.Padding(4);
            this.bttnRegresar.Name = "bttnRegresar";
            this.bttnRegresar.Size = new System.Drawing.Size(105, 57);
            this.bttnRegresar.TabIndex = 1;
            this.bttnRegresar.Text = "Regresar";
            this.bttnRegresar.UseVisualStyleBackColor = true;
            this.bttnRegresar.Click += new System.EventHandler(this.bttnRegresar_Click);
            // 
            // txtDisponibleRenta
            // 
            this.txtDisponibleRenta.Location = new System.Drawing.Point(678, 292);
            this.txtDisponibleRenta.Margin = new System.Windows.Forms.Padding(4);
            this.txtDisponibleRenta.Name = "txtDisponibleRenta";
            this.txtDisponibleRenta.ShortcutsEnabled = false;
            this.txtDisponibleRenta.Size = new System.Drawing.Size(105, 27);
            this.txtDisponibleRenta.TabIndex = 36;
            this.txtDisponibleRenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDisponibleRenta_KeyPress);
            // 
            // txtDisponibleVenta
            // 
            this.txtDisponibleVenta.Location = new System.Drawing.Point(678, 151);
            this.txtDisponibleVenta.Margin = new System.Windows.Forms.Padding(4);
            this.txtDisponibleVenta.Name = "txtDisponibleVenta";
            this.txtDisponibleVenta.ShortcutsEnabled = false;
            this.txtDisponibleVenta.Size = new System.Drawing.Size(105, 27);
            this.txtDisponibleVenta.TabIndex = 35;
            this.txtDisponibleVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDisponibleVenta_KeyPress);
            // 
            // txtPrecioRenta
            // 
            this.txtPrecioRenta.Location = new System.Drawing.Point(678, 227);
            this.txtPrecioRenta.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecioRenta.Name = "txtPrecioRenta";
            this.txtPrecioRenta.ShortcutsEnabled = false;
            this.txtPrecioRenta.Size = new System.Drawing.Size(105, 27);
            this.txtPrecioRenta.TabIndex = 34;
            this.txtPrecioRenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioRenta_KeyPress);
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(678, 93);
            this.txtPrecioVenta.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.ShortcutsEnabled = false;
            this.txtPrecioVenta.Size = new System.Drawing.Size(105, 27);
            this.txtPrecioVenta.TabIndex = 33;
            this.txtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioVenta_KeyPress);
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(158, 155);
            this.txtAutor.Margin = new System.Windows.Forms.Padding(4);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(247, 27);
            this.txtAutor.TabIndex = 32;
            // 
            // txtEdicion
            // 
            this.txtEdicion.Location = new System.Drawing.Point(158, 299);
            this.txtEdicion.Margin = new System.Windows.Forms.Padding(4);
            this.txtEdicion.Name = "txtEdicion";
            this.txtEdicion.Size = new System.Drawing.Size(247, 27);
            this.txtEdicion.TabIndex = 31;
            // 
            // txtEditorial
            // 
            this.txtEditorial.Location = new System.Drawing.Point(158, 221);
            this.txtEditorial.Margin = new System.Windows.Forms.Padding(4);
            this.txtEditorial.Name = "txtEditorial";
            this.txtEditorial.Size = new System.Drawing.Size(247, 27);
            this.txtEditorial.TabIndex = 30;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(158, 89);
            this.txtTitulo.Margin = new System.Windows.Forms.Padding(4);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(247, 27);
            this.txtTitulo.TabIndex = 29;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(342, 26);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.ShortcutsEnabled = false;
            this.txtID.Size = new System.Drawing.Size(119, 27);
            this.txtID.TabIndex = 28;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(440, 299);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(219, 20);
            this.label10.TabIndex = 27;
            this.label10.Text = "DISPONIBLE EN RENTA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(440, 154);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(219, 20);
            this.label9.TabIndex = 26;
            this.label9.Text = "DISPONIBLE EN VENTA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(481, 230);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "PRECIO DE RENTA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(481, 99);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "PRECIO DE VENTA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(50, 158);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "AUTOR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(35, 299);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "EDICIÓN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(13, 221);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "EDITORIAL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(45, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "TÍTULO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(219, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "ID LIBRO";
            // 
            // bttnBuscar
            // 
            this.bttnBuscar.Location = new System.Drawing.Point(485, 19);
            this.bttnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.bttnBuscar.Name = "bttnBuscar";
            this.bttnBuscar.Size = new System.Drawing.Size(132, 40);
            this.bttnBuscar.TabIndex = 37;
            this.bttnBuscar.Text = "Buscar";
            this.bttnBuscar.UseVisualStyleBackColor = true;
            this.bttnBuscar.Click += new System.EventHandler(this.bttnBuscar_Click);
            // 
            // bttnModificar
            // 
            this.bttnModificar.Location = new System.Drawing.Point(342, 369);
            this.bttnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.bttnModificar.Name = "bttnModificar";
            this.bttnModificar.Size = new System.Drawing.Size(142, 64);
            this.bttnModificar.TabIndex = 38;
            this.bttnModificar.Text = "Modificar";
            this.bttnModificar.UseVisualStyleBackColor = true;
            this.bttnModificar.Click += new System.EventHandler(this.bttnModificar_Click);
            // 
            // frmConsultarLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(871, 446);
            this.Controls.Add(this.bttnModificar);
            this.Controls.Add(this.bttnBuscar);
            this.Controls.Add(this.txtDisponibleRenta);
            this.Controls.Add(this.txtDisponibleVenta);
            this.Controls.Add(this.txtPrecioRenta);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.txtAutor);
            this.Controls.Add(this.txtEdicion);
            this.Controls.Add(this.txtEditorial);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bttnRegresar);
            this.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmConsultarLibro";
            this.Text = "Consultar Libro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bttnRegresar;
        private System.Windows.Forms.TextBox txtDisponibleRenta;
        private System.Windows.Forms.TextBox txtDisponibleVenta;
        private System.Windows.Forms.TextBox txtPrecioRenta;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.TextBox txtEdicion;
        private System.Windows.Forms.TextBox txtEditorial;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bttnBuscar;
        private System.Windows.Forms.Button bttnModificar;
    }
}