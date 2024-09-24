namespace Generator_Class_BD
{
    partial class frmView
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtViewClase = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtViewClase
            // 
            this.txtViewClase.Location = new System.Drawing.Point(12, 12);
            this.txtViewClase.Name = "txtViewClase";
            this.txtViewClase.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtViewClase.Size = new System.Drawing.Size(351, 308);
            this.txtViewClase.TabIndex = 1;
            this.txtViewClase.Text = "";
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 333);
            this.Controls.Add(this.txtViewClase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Clase Conexion";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox txtViewClase;
    }
}