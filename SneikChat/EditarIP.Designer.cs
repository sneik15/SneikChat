namespace SneikChat
{
    partial class EditarIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarIP));
            this.btnAcep = new System.Windows.Forms.Button();
            this.btnCan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAcep
            // 
            this.btnAcep.Location = new System.Drawing.Point(517, 55);
            this.btnAcep.Name = "btnAcep";
            this.btnAcep.Size = new System.Drawing.Size(75, 23);
            this.btnAcep.TabIndex = 0;
            this.btnAcep.Text = "Aceptar";
            this.btnAcep.UseVisualStyleBackColor = true;
            this.btnAcep.Click += new System.EventHandler(this.Aceptar);
            // 
            // btnCan
            // 
            this.btnCan.Location = new System.Drawing.Point(436, 55);
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(75, 23);
            this.btnCan.TabIndex = 1;
            this.btnCan.Text = "Cancelar";
            this.btnCan.UseVisualStyleBackColor = true;
            this.btnCan.Click += new System.EventHandler(this.Cancelar);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Introduce la dirección IP del servidor:";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(13, 29);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(579, 20);
            this.txtIP.TabIndex = 3;
            // 
            // EditarIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 92);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCan);
            this.Controls.Add(this.btnAcep);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(620, 130);
            this.MinimumSize = new System.Drawing.Size(620, 130);
            this.Name = "EditarIP";
            this.Text = "Editar IP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAcep;
        private System.Windows.Forms.Button btnCan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
    }
}