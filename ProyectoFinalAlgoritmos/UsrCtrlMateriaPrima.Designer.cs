namespace ProyectoFinalAlgoritmos
{
    partial class UsrCtrlMateriaPrima
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
            this.btnReporteValor = new System.Windows.Forms.Button();
            this.lblTotalInventario = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvMatePrima = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.usrCtrlDatosMateriaPrima1 = new ProyectoFinalAlgoritmos.UsrCtrlDatosMateriaPrima();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatePrima)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReporteValor
            // 
            this.btnReporteValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReporteValor.BackColor = System.Drawing.Color.SandyBrown;
            this.btnReporteValor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteValor.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReporteValor.Location = new System.Drawing.Point(272, 540);
            this.btnReporteValor.Name = "btnReporteValor";
            this.btnReporteValor.Size = new System.Drawing.Size(161, 69);
            this.btnReporteValor.TabIndex = 21;
            this.btnReporteValor.Text = "Ver Reporte de Valor";
            this.btnReporteValor.UseVisualStyleBackColor = false;
            this.btnReporteValor.Click += new System.EventHandler(this.btnReporteValor_Click);
            // 
            // lblTotalInventario
            // 
            this.lblTotalInventario.AutoSize = true;
            this.lblTotalInventario.Location = new System.Drawing.Point(38, 517);
            this.lblTotalInventario.Name = "lblTotalInventario";
            this.lblTotalInventario.Size = new System.Drawing.Size(51, 20);
            this.lblTotalInventario.TabIndex = 20;
            this.lblTotalInventario.Text = "label2";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(29)))), ((int)(((byte)(57)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminar.Location = new System.Drawing.Point(923, 540);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(161, 69);
            this.btnEliminar.TabIndex = 19;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(101)))), ((int)(((byte)(57)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditar.Location = new System.Drawing.Point(700, 540);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(161, 69);
            this.btnEditar.TabIndex = 18;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(40)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgregar.Location = new System.Drawing.Point(477, 540);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(161, 69);
            this.btnAgregar.TabIndex = 17;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvMatePrima
            // 
            this.dgvMatePrima.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMatePrima.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMatePrima.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatePrima.Location = new System.Drawing.Point(42, 92);
            this.dgvMatePrima.MultiSelect = false;
            this.dgvMatePrima.Name = "dgvMatePrima";
            this.dgvMatePrima.RowHeadersWidth = 62;
            this.dgvMatePrima.RowTemplate.Height = 28;
            this.dgvMatePrima.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMatePrima.Size = new System.Drawing.Size(1042, 393);
            this.dgvMatePrima.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Elephant", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(31, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(649, 62);
            this.label1.TabIndex = 15;
            this.label1.Text = "Gestión de Materia Prima";
            // 
            // usrCtrlDatosMateriaPrima1
            // 
            this.usrCtrlDatosMateriaPrima1.Location = new System.Drawing.Point(0, 0);
            this.usrCtrlDatosMateriaPrima1.Name = "usrCtrlDatosMateriaPrima1";
            this.usrCtrlDatosMateriaPrima1.Size = new System.Drawing.Size(1115, 647);
            this.usrCtrlDatosMateriaPrima1.TabIndex = 22;
            // 
            // UsrCtrlMateriaPrima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReporteValor);
            this.Controls.Add(this.lblTotalInventario);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvMatePrima);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usrCtrlDatosMateriaPrima1);
            this.Name = "UsrCtrlMateriaPrima";
            this.Size = new System.Drawing.Size(1115, 647);
            this.Load += new System.EventHandler(this.UsrCtrlMateriaPrima_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatePrima)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReporteValor;
        private System.Windows.Forms.Label lblTotalInventario;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvMatePrima;
        private System.Windows.Forms.Label label1;
        private UsrCtrlDatosMateriaPrima usrCtrlDatosMateriaPrima1;
    }
}
