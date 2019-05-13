namespace UI
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSaludo = new System.Windows.Forms.Label();
            this.lblCultura = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSaludo
            // 
            this.lblSaludo.AutoSize = true;
            this.lblSaludo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSaludo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaludo.Location = new System.Drawing.Point(140, 99);
            this.lblSaludo.Name = "lblSaludo";
            this.lblSaludo.Size = new System.Drawing.Size(50, 24);
            this.lblSaludo.TabIndex = 0;
            this.lblSaludo.Text = "label";
            // 
            // lblCultura
            // 
            this.lblCultura.AutoSize = true;
            this.lblCultura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCultura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCultura.Location = new System.Drawing.Point(140, 145);
            this.lblCultura.Name = "lblCultura";
            this.lblCultura.Size = new System.Drawing.Size(50, 24);
            this.lblCultura.TabIndex = 1;
            this.lblCultura.Text = "label";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCultura);
            this.Controls.Add(this.lblSaludo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSaludo;
        private System.Windows.Forms.Label lblCultura;
    }
}

