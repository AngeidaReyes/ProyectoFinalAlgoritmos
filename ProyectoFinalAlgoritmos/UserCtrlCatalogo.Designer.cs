namespace ProyectoFinalAlgoritmos
{
    partial class UserCtrlCatalogo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelBusqueda = new System.Windows.Forms.Panel();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panelResultados = new System.Windows.Forms.Panel();
            this.panelBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.panelBusqueda.Controls.Add(this.btnRefrescar);
            this.panelBusqueda.Controls.Add(this.txtBuscar);
            this.panelBusqueda.Controls.Add(this.btnBuscar);
            this.panelBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBusqueda.Location = new System.Drawing.Point(0, 0);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Size = new System.Drawing.Size(1085, 77);
            this.panelBusqueda.TabIndex = 3;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(785, 22);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(123, 51);
            this.btnRefrescar.TabIndex = 2;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(267, 34);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(305, 26);
            this.txtBuscar.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(620, 22);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(123, 51);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panelResultados
            // 
            this.panelResultados.AutoScroll = true;
            this.panelResultados.AutoSize = true;
            this.panelResultados.BackColor = System.Drawing.Color.Transparent;
            this.panelResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResultados.Location = new System.Drawing.Point(0, 77);
            this.panelResultados.Name = "panelResultados";
            this.panelResultados.Size = new System.Drawing.Size(1085, 775);
            this.panelResultados.TabIndex = 4;
            // 
            // UserCtrlCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panelResultados);
            this.Controls.Add(this.panelBusqueda);
            this.Name = "UserCtrlCatalogo";
            this.Size = new System.Drawing.Size(1085, 852);
            this.Load += new System.EventHandler(this.UserCtrlCatalogo_Load);
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        public System.Windows.Forms.Panel panelResultados;
    }
}
