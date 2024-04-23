
namespace Interfaz
{
    partial class frmMostrarLibro
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
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.bttnRegresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(12, 12);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(1280, 295);
            this.dgvDatos.TabIndex = 0;
            // 
            // bttnRegresar
            // 
            this.bttnRegresar.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnRegresar.Location = new System.Drawing.Point(589, 353);
            this.bttnRegresar.Margin = new System.Windows.Forms.Padding(4);
            this.bttnRegresar.Name = "bttnRegresar";
            this.bttnRegresar.Size = new System.Drawing.Size(174, 63);
            this.bttnRegresar.TabIndex = 103;
            this.bttnRegresar.Text = "REGRESAR";
            this.bttnRegresar.UseVisualStyleBackColor = true;
            this.bttnRegresar.Click += new System.EventHandler(this.bttnRegresar_Click);
            // 
            // frmMostrarLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1314, 470);
            this.Controls.Add(this.bttnRegresar);
            this.Controls.Add(this.dgvDatos);
            this.Name = "frmMostrarLibro";
            this.Text = "frmMostrarLibro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMostrarLibro_FormClosing);
            this.Load += new System.EventHandler(this.frmMostrarLibro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button bttnRegresar;
    }
}