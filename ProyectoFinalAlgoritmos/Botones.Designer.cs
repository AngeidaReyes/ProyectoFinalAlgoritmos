namespace ProyectoFinalAlgoritmos
{
    partial class Botones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Botones));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ImgpictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgpictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ImgpictureBox1);
            this.panel1.Location = new System.Drawing.Point(19, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 191);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Schoolbook", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(254, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "$500.00";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(189, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 72);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre \r\nDel\r\nProducto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImgpictureBox1
            // 
            this.ImgpictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("ImgpictureBox1.Image")));
            this.ImgpictureBox1.Location = new System.Drawing.Point(13, 19);
            this.ImgpictureBox1.Name = "ImgpictureBox1";
            this.ImgpictureBox1.Size = new System.Drawing.Size(158, 153);
            this.ImgpictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgpictureBox1.TabIndex = 0;
            this.ImgpictureBox1.TabStop = false;
            this.ImgpictureBox1.Click += new System.EventHandler(this.ImgpictureBox1_Click);
            // 
            // Botones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Name = "Botones";
            this.Size = new System.Drawing.Size(464, 227);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgpictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ImgpictureBox1;
    }
}
