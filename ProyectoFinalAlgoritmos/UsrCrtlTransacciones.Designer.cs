namespace ProyectoFinalAlgoritmos
{
    partial class UsrCrtlTransacciones
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
            this.lblGestion = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.dgvTransacciones = new System.Windows.Forms.DataGridView();
            this.btnReporte = new System.Windows.Forms.Button();
            this.tabTransacciones = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPgPrima = new System.Windows.Forms.TabPage();
            this.dgvPrima = new System.Windows.Forms.DataGridView();
            this.btnRepPrima = new System.Windows.Forms.Button();
            this.btnRegPrima = new System.Windows.Forms.Button();
            this.usrCtrlTransaccionesMP1 = new ProyectoFinalAlgoritmos.UsrCtrlTransaccionesMP();
            this.usrCtrlDatosTransacciones1 = new ProyectoFinalAlgoritmos.UsrCtrlDatosTransacciones();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransacciones)).BeginInit();
            this.tabTransacciones.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPgPrima.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrima)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGestion
            // 
            this.lblGestion.AutoSize = true;
            this.lblGestion.Font = new System.Drawing.Font("Elephant", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblGestion.Location = new System.Drawing.Point(3, 10);
            this.lblGestion.Name = "lblGestion";
            this.lblGestion.Size = new System.Drawing.Size(638, 62);
            this.lblGestion.TabIndex = 9;
            this.lblGestion.Text = "Gestión de Transacciones";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(40)))));
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnRegistrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegistrar.Location = new System.Drawing.Point(757, 398);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(317, 69);
            this.btnRegistrar.TabIndex = 8;
            this.btnRegistrar.Text = "Registrar Transacción";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // dgvTransacciones
            // 
            this.dgvTransacciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransacciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransacciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransacciones.Location = new System.Drawing.Point(2, 3);
            this.dgvTransacciones.MultiSelect = false;
            this.dgvTransacciones.Name = "dgvTransacciones";
            this.dgvTransacciones.RowHeadersWidth = 62;
            this.dgvTransacciones.RowTemplate.Height = 28;
            this.dgvTransacciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransacciones.Size = new System.Drawing.Size(1099, 389);
            this.dgvTransacciones.TabIndex = 7;
            // 
            // btnReporte
            // 
            this.btnReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(101)))), ((int)(((byte)(57)))));
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnReporte.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReporte.Location = new System.Drawing.Point(31, 398);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(317, 69);
            this.btnReporte.TabIndex = 11;
            this.btnReporte.Text = "Generar Reporte";
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // tabTransacciones
            // 
            this.tabTransacciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabTransacciones.Controls.Add(this.tabPage1);
            this.tabTransacciones.Controls.Add(this.tabPgPrima);
            this.tabTransacciones.Font = new System.Drawing.Font("Elephant", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTransacciones.Location = new System.Drawing.Point(0, 75);
            this.tabTransacciones.Name = "tabTransacciones";
            this.tabTransacciones.SelectedIndex = 0;
            this.tabTransacciones.Size = new System.Drawing.Size(1112, 540);
            this.tabTransacciones.TabIndex = 12;
            this.tabTransacciones.SelectedIndexChanged += new System.EventHandler(this.tabTransacciones_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvTransacciones);
            this.tabPage1.Controls.Add(this.btnReporte);
            this.tabPage1.Controls.Add(this.btnRegistrar);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1104, 503);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Productos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPgPrima
            // 
            this.tabPgPrima.Controls.Add(this.dgvPrima);
            this.tabPgPrima.Controls.Add(this.btnRepPrima);
            this.tabPgPrima.Controls.Add(this.btnRegPrima);
            this.tabPgPrima.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPgPrima.Location = new System.Drawing.Point(4, 33);
            this.tabPgPrima.Name = "tabPgPrima";
            this.tabPgPrima.Padding = new System.Windows.Forms.Padding(3);
            this.tabPgPrima.Size = new System.Drawing.Size(1104, 503);
            this.tabPgPrima.TabIndex = 1;
            this.tabPgPrima.Text = "Materia Prima";
            this.tabPgPrima.UseVisualStyleBackColor = true;
            // 
            // dgvPrima
            // 
            this.dgvPrima.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPrima.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrima.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrima.Location = new System.Drawing.Point(3, 3);
            this.dgvPrima.MultiSelect = false;
            this.dgvPrima.Name = "dgvPrima";
            this.dgvPrima.RowHeadersWidth = 62;
            this.dgvPrima.RowTemplate.Height = 28;
            this.dgvPrima.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrima.Size = new System.Drawing.Size(1099, 389);
            this.dgvPrima.TabIndex = 12;
            // 
            // btnRepPrima
            // 
            this.btnRepPrima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRepPrima.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(101)))), ((int)(((byte)(57)))));
            this.btnRepPrima.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepPrima.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnRepPrima.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRepPrima.Location = new System.Drawing.Point(31, 398);
            this.btnRepPrima.Name = "btnRepPrima";
            this.btnRepPrima.Size = new System.Drawing.Size(317, 69);
            this.btnRepPrima.TabIndex = 14;
            this.btnRepPrima.Text = "Generar Reporte";
            this.btnRepPrima.UseVisualStyleBackColor = false;
            this.btnRepPrima.Click += new System.EventHandler(this.btnRepPrima_Click);
            // 
            // btnRegPrima
            // 
            this.btnRegPrima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegPrima.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(40)))));
            this.btnRegPrima.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegPrima.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnRegPrima.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegPrima.Location = new System.Drawing.Point(757, 398);
            this.btnRegPrima.Name = "btnRegPrima";
            this.btnRegPrima.Size = new System.Drawing.Size(317, 69);
            this.btnRegPrima.TabIndex = 13;
            this.btnRegPrima.Text = "Registrar Transacción";
            this.btnRegPrima.UseVisualStyleBackColor = false;
            this.btnRegPrima.Click += new System.EventHandler(this.btnRegPrima_Click);
            // 
            // usrCtrlTransaccionesMP1
            // 
            this.usrCtrlTransaccionesMP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrCtrlTransaccionesMP1.Location = new System.Drawing.Point(0, 0);
            this.usrCtrlTransaccionesMP1.Name = "usrCtrlTransaccionesMP1";
            this.usrCtrlTransaccionesMP1.Size = new System.Drawing.Size(1115, 647);
            this.usrCtrlTransaccionesMP1.TabIndex = 13;
            // 
            // usrCtrlDatosTransacciones1
            // 
            this.usrCtrlDatosTransacciones1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrCtrlDatosTransacciones1.Location = new System.Drawing.Point(0, 0);
            this.usrCtrlDatosTransacciones1.Name = "usrCtrlDatosTransacciones1";
            this.usrCtrlDatosTransacciones1.Size = new System.Drawing.Size(1115, 647);
            this.usrCtrlDatosTransacciones1.TabIndex = 10;
            // 
            // UsrCrtlTransacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabTransacciones);
            this.Controls.Add(this.lblGestion);
            this.Controls.Add(this.usrCtrlDatosTransacciones1);
            this.Controls.Add(this.usrCtrlTransaccionesMP1);
            this.Name = "UsrCrtlTransacciones";
            this.Size = new System.Drawing.Size(1115, 647);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransacciones)).EndInit();
            this.tabTransacciones.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPgPrima.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrima)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGestion;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DataGridView dgvTransacciones;
        private UsrCtrlDatosTransacciones usrCtrlDatosTransacciones1;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.TabControl tabTransacciones;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPgPrima;
        private System.Windows.Forms.DataGridView dgvPrima;
        private System.Windows.Forms.Button btnRepPrima;
        private System.Windows.Forms.Button btnRegPrima;
        private UsrCtrlTransaccionesMP usrCtrlTransaccionesMP1;
    }
}
