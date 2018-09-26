namespace SneikChat
{
    partial class Usuario
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUsuConect = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUsuConect
            // 
            this.lblUsuConect.AutoSize = true;
            this.lblUsuConect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuConect.Location = new System.Drawing.Point(3, 0);
            this.lblUsuConect.Name = "lblUsuConect";
            this.lblUsuConect.Size = new System.Drawing.Size(50, 16);
            this.lblUsuConect.TabIndex = 0;
            this.lblUsuConect.Text = "Default";
            // 
            // Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUsuConect);
            this.Name = "Usuario";
            this.Size = new System.Drawing.Size(130, 16);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuConect;
    }
}
