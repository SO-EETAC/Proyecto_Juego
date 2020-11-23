namespace WindowsFormsApplication1
{
    partial class Tablero_Partida
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
            this.CajaRobar = new System.Windows.Forms.PictureBox();
            this.FondoTablero = new System.Windows.Forms.PictureBox();
            this.Robar = new System.Windows.Forms.Button();
            this.Mezclar = new System.Windows.Forms.Button();
            this.VolveraJugar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NumFichasJug3 = new System.Windows.Forms.TextBox();
            this.NumFichasJug2 = new System.Windows.Forms.TextBox();
            this.NumFichasJug4 = new System.Windows.Forms.TextBox();
            this.LogoJug3 = new System.Windows.Forms.PictureBox();
            this.LogoJug2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LogoJug4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NumFichasJug1 = new System.Windows.Forms.TextBox();
            this.LogoJug1 = new System.Windows.Forms.PictureBox();
            this.ImagenFichas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CajaRobar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FondoTablero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoJug3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoJug2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoJug4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoJug1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenFichas)).BeginInit();
            this.SuspendLayout();
            // 
            // CajaRobar
            // 
            this.CajaRobar.Image = global::WindowsFormsApplication1.Properties.Resources.Robar_caja;
            this.CajaRobar.Location = new System.Drawing.Point(731, 154);
            this.CajaRobar.Name = "CajaRobar";
            this.CajaRobar.Size = new System.Drawing.Size(79, 164);
            this.CajaRobar.TabIndex = 1;
            this.CajaRobar.TabStop = false;
            // 
            // FondoTablero
            // 
            this.FondoTablero.Image = global::WindowsFormsApplication1.Properties.Resources.Tablero_def1;
            this.FondoTablero.Location = new System.Drawing.Point(293, 78);
            this.FondoTablero.Name = "FondoTablero";
            this.FondoTablero.Size = new System.Drawing.Size(531, 357);
            this.FondoTablero.TabIndex = 0;
            this.FondoTablero.TabStop = false;
            // 
            // Robar
            // 
            this.Robar.Location = new System.Drawing.Point(732, 324);
            this.Robar.Name = "Robar";
            this.Robar.Size = new System.Drawing.Size(78, 42);
            this.Robar.TabIndex = 2;
            this.Robar.Text = "Robar";
            this.Robar.UseVisualStyleBackColor = true;
            // 
            // Mezclar
            // 
            this.Mezclar.Location = new System.Drawing.Point(36, 36);
            this.Mezclar.Name = "Mezclar";
            this.Mezclar.Size = new System.Drawing.Size(89, 50);
            this.Mezclar.TabIndex = 3;
            this.Mezclar.Text = "Mezclar";
            this.Mezclar.UseVisualStyleBackColor = true;
            // 
            // VolveraJugar
            // 
            this.VolveraJugar.Location = new System.Drawing.Point(36, 92);
            this.VolveraJugar.Name = "VolveraJugar";
            this.VolveraJugar.Size = new System.Drawing.Size(88, 50);
            this.VolveraJugar.TabIndex = 4;
            this.VolveraJugar.Text = "Volver a Jugar";
            this.VolveraJugar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(493, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Jugador 3";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(132, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Jugador 2";
            // 
            // NumFichasJug3
            // 
            this.NumFichasJug3.Location = new System.Drawing.Point(602, 12);
            this.NumFichasJug3.Name = "NumFichasJug3";
            this.NumFichasJug3.Size = new System.Drawing.Size(39, 20);
            this.NumFichasJug3.TabIndex = 7;
            this.NumFichasJug3.TextChanged += new System.EventHandler(this.NumFichasJug3_TextChanged);
            // 
            // NumFichasJug2
            // 
            this.NumFichasJug2.Location = new System.Drawing.Point(246, 208);
            this.NumFichasJug2.Name = "NumFichasJug2";
            this.NumFichasJug2.Size = new System.Drawing.Size(35, 20);
            this.NumFichasJug2.TabIndex = 8;
            // 
            // NumFichasJug4
            // 
            this.NumFichasJug4.Location = new System.Drawing.Point(948, 208);
            this.NumFichasJug4.Name = "NumFichasJug4";
            this.NumFichasJug4.Size = new System.Drawing.Size(36, 20);
            this.NumFichasJug4.TabIndex = 9;
            this.NumFichasJug4.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // LogoJug3
            // 
            this.LogoJug3.Location = new System.Drawing.Point(497, 32);
            this.LogoJug3.Name = "LogoJug3";
            this.LogoJug3.Size = new System.Drawing.Size(92, 40);
            this.LogoJug3.TabIndex = 10;
            this.LogoJug3.TabStop = false;
            // 
            // LogoJug2
            // 
            this.LogoJug2.Location = new System.Drawing.Point(141, 242);
            this.LogoJug2.Name = "LogoJug2";
            this.LogoJug2.Size = new System.Drawing.Size(94, 60);
            this.LogoJug2.TabIndex = 11;
            this.LogoJug2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(830, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Jugador 4";
            // 
            // LogoJug4
            // 
            this.LogoJug4.Location = new System.Drawing.Point(837, 229);
            this.LogoJug4.Name = "LogoJug4";
            this.LogoJug4.Size = new System.Drawing.Size(95, 72);
            this.LogoJug4.TabIndex = 13;
            this.LogoJug4.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(486, 452);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "Jugador 1";
            // 
            // NumFichasJug1
            // 
            this.NumFichasJug1.Location = new System.Drawing.Point(599, 452);
            this.NumFichasJug1.Name = "NumFichasJug1";
            this.NumFichasJug1.Size = new System.Drawing.Size(41, 20);
            this.NumFichasJug1.TabIndex = 15;
            // 
            // LogoJug1
            // 
            this.LogoJug1.Location = new System.Drawing.Point(395, 489);
            this.LogoJug1.Name = "LogoJug1";
            this.LogoJug1.Size = new System.Drawing.Size(179, 64);
            this.LogoJug1.TabIndex = 16;
            this.LogoJug1.TabStop = false;
            // 
            // ImagenFichas
            // 
            this.ImagenFichas.Location = new System.Drawing.Point(594, 488);
            this.ImagenFichas.Name = "ImagenFichas";
            this.ImagenFichas.Size = new System.Drawing.Size(205, 77);
            this.ImagenFichas.TabIndex = 17;
            this.ImagenFichas.TabStop = false;
            // 
            // Tablero_Partida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(996, 597);
            this.Controls.Add(this.ImagenFichas);
            this.Controls.Add(this.LogoJug1);
            this.Controls.Add(this.NumFichasJug1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LogoJug4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LogoJug2);
            this.Controls.Add(this.LogoJug3);
            this.Controls.Add(this.NumFichasJug4);
            this.Controls.Add(this.NumFichasJug2);
            this.Controls.Add(this.NumFichasJug3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VolveraJugar);
            this.Controls.Add(this.Mezclar);
            this.Controls.Add(this.Robar);
            this.Controls.Add(this.CajaRobar);
            this.Controls.Add(this.FondoTablero);
            this.Name = "Tablero_Partida";
            this.Text = "Tablero_Partida";
            this.Load += new System.EventHandler(this.Tablero_Partida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CajaRobar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FondoTablero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoJug3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoJug2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoJug4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoJug1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenFichas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FondoTablero;
        private System.Windows.Forms.PictureBox CajaRobar;
        private System.Windows.Forms.Button Robar;
        private System.Windows.Forms.Button Mezclar;
        private System.Windows.Forms.Button VolveraJugar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NumFichasJug3;
        private System.Windows.Forms.TextBox NumFichasJug2;
        private System.Windows.Forms.TextBox NumFichasJug4;
        private System.Windows.Forms.PictureBox LogoJug3;
        private System.Windows.Forms.PictureBox LogoJug2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox LogoJug4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NumFichasJug1;
        private System.Windows.Forms.PictureBox LogoJug1;
        private System.Windows.Forms.PictureBox ImagenFichas;
    }
}