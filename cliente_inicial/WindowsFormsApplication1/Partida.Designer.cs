namespace WindowsFormsApplication1
{
    partial class Partida
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
            this.Mezclar = new System.Windows.Forms.Button();
            this.Replay = new System.Windows.Forms.Button();
            this.Jugador3 = new System.Windows.Forms.Label();
            this.Jugador2 = new System.Windows.Forms.Label();
            this.Robar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NumFichasJug3 = new System.Windows.Forms.TextBox();
            this.NumFichasJug2 = new System.Windows.Forms.TextBox();
            this.NumFichasJug4 = new System.Windows.Forms.TextBox();
            this.NumFichasJug1 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.IconoJug1 = new System.Windows.Forms.PictureBox();
            this.FichasJug1 = new System.Windows.Forms.PictureBox();
            this.IconoJug2 = new System.Windows.Forms.PictureBox();
            this.IconoJug4 = new System.Windows.Forms.PictureBox();
            this.IconoJug3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconoJug1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FichasJug1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconoJug2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconoJug4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconoJug3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Mezclar
            // 
            this.Mezclar.Location = new System.Drawing.Point(21, 26);
            this.Mezclar.Name = "Mezclar";
            this.Mezclar.Size = new System.Drawing.Size(94, 45);
            this.Mezclar.TabIndex = 2;
            this.Mezclar.Text = "Mezclar";
            this.Mezclar.UseVisualStyleBackColor = true;
            this.Mezclar.Click += new System.EventHandler(this.button1_Click);
            // 
            // Replay
            // 
            this.Replay.Location = new System.Drawing.Point(21, 89);
            this.Replay.Name = "Replay";
            this.Replay.Size = new System.Drawing.Size(94, 45);
            this.Replay.TabIndex = 3;
            this.Replay.Text = "Volver a Jugar";
            this.Replay.UseVisualStyleBackColor = true;
            // 
            // Jugador3
            // 
            this.Jugador3.AutoSize = true;
            this.Jugador3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jugador3.Location = new System.Drawing.Point(438, 2);
            this.Jugador3.Name = "Jugador3";
            this.Jugador3.Size = new System.Drawing.Size(80, 20);
            this.Jugador3.TabIndex = 4;
            this.Jugador3.Text = "Jugador 3";
            // 
            // Jugador2
            // 
            this.Jugador2.AutoSize = true;
            this.Jugador2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jugador2.Location = new System.Drawing.Point(118, 214);
            this.Jugador2.Name = "Jugador2";
            this.Jugador2.Size = new System.Drawing.Size(80, 20);
            this.Jugador2.TabIndex = 5;
            this.Jugador2.Text = "Jugador 2";
            // 
            // Robar
            // 
            this.Robar.Location = new System.Drawing.Point(683, 358);
            this.Robar.Name = "Robar";
            this.Robar.Size = new System.Drawing.Size(79, 50);
            this.Robar.TabIndex = 8;
            this.Robar.Text = "Robar";
            this.Robar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 498);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Jugador 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(777, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Jugador 4";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // NumFichasJug3
            // 
            this.NumFichasJug3.Location = new System.Drawing.Point(530, 4);
            this.NumFichasJug3.Name = "NumFichasJug3";
            this.NumFichasJug3.Size = new System.Drawing.Size(44, 20);
            this.NumFichasJug3.TabIndex = 15;
            // 
            // NumFichasJug2
            // 
            this.NumFichasJug2.Location = new System.Drawing.Point(204, 216);
            this.NumFichasJug2.Name = "NumFichasJug2";
            this.NumFichasJug2.Size = new System.Drawing.Size(29, 20);
            this.NumFichasJug2.TabIndex = 17;
            // 
            // NumFichasJug4
            // 
            this.NumFichasJug4.Location = new System.Drawing.Point(860, 213);
            this.NumFichasJug4.Name = "NumFichasJug4";
            this.NumFichasJug4.Size = new System.Drawing.Size(31, 20);
            this.NumFichasJug4.TabIndex = 18;
            // 
            // NumFichasJug1
            // 
            this.NumFichasJug1.Location = new System.Drawing.Point(352, 500);
            this.NumFichasJug1.Name = "NumFichasJug1";
            this.NumFichasJug1.Size = new System.Drawing.Size(45, 20);
            this.NumFichasJug1.TabIndex = 19;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApplication1.Properties.Resources.Robar_caja;
            this.pictureBox2.Location = new System.Drawing.Point(683, 188);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(79, 164);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // IconoJug1
            // 
            this.IconoJug1.Location = new System.Drawing.Point(258, 526);
            this.IconoJug1.Name = "IconoJug1";
            this.IconoJug1.Size = new System.Drawing.Size(150, 57);
            this.IconoJug1.TabIndex = 16;
            this.IconoJug1.TabStop = false;
            // 
            // FichasJug1
            // 
            this.FichasJug1.Location = new System.Drawing.Point(432, 514);
            this.FichasJug1.Name = "FichasJug1";
            this.FichasJug1.Size = new System.Drawing.Size(311, 69);
            this.FichasJug1.TabIndex = 12;
            this.FichasJug1.TabStop = false;
            // 
            // IconoJug2
            // 
            this.IconoJug2.Location = new System.Drawing.Point(146, 243);
            this.IconoJug2.Name = "IconoJug2";
            this.IconoJug2.Size = new System.Drawing.Size(83, 77);
            this.IconoJug2.TabIndex = 11;
            this.IconoJug2.TabStop = false;
            // 
            // IconoJug4
            // 
            this.IconoJug4.Location = new System.Drawing.Point(777, 243);
            this.IconoJug4.Name = "IconoJug4";
            this.IconoJug4.Size = new System.Drawing.Size(84, 73);
            this.IconoJug4.TabIndex = 10;
            this.IconoJug4.TabStop = false;
            // 
            // IconoJug3
            // 
            this.IconoJug3.Location = new System.Drawing.Point(442, 36);
            this.IconoJug3.Name = "IconoJug3";
            this.IconoJug3.Size = new System.Drawing.Size(132, 35);
            this.IconoJug3.TabIndex = 9;
            this.IconoJug3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.Tablero_def;
            this.pictureBox1.Location = new System.Drawing.Point(246, 89);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(525, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Partida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(900, 595);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.NumFichasJug1);
            this.Controls.Add(this.NumFichasJug4);
            this.Controls.Add(this.NumFichasJug2);
            this.Controls.Add(this.IconoJug1);
            this.Controls.Add(this.NumFichasJug3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FichasJug1);
            this.Controls.Add(this.IconoJug2);
            this.Controls.Add(this.IconoJug4);
            this.Controls.Add(this.IconoJug3);
            this.Controls.Add(this.Robar);
            this.Controls.Add(this.Jugador2);
            this.Controls.Add(this.Jugador3);
            this.Controls.Add(this.Replay);
            this.Controls.Add(this.Mezclar);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Partida";
            this.Text = "Partida";
            this.Load += new System.EventHandler(this.Partida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconoJug1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FichasJug1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconoJug2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconoJug4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconoJug3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Mezclar;
        private System.Windows.Forms.Button Replay;
        private System.Windows.Forms.Label Jugador3;
        private System.Windows.Forms.Label Jugador2;
        private System.Windows.Forms.Button Robar;
        private System.Windows.Forms.PictureBox IconoJug3;
        private System.Windows.Forms.PictureBox IconoJug4;
        private System.Windows.Forms.PictureBox IconoJug2;
        private System.Windows.Forms.PictureBox FichasJug1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NumFichasJug3;
        private System.Windows.Forms.PictureBox IconoJug1;
        private System.Windows.Forms.TextBox NumFichasJug2;
        private System.Windows.Forms.TextBox NumFichasJug4;
        private System.Windows.Forms.TextBox NumFichasJug1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}