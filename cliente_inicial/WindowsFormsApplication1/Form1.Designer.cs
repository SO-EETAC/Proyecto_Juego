namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.invitar = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.consulta_lista = new System.Windows.Forms.RadioButton();
            this.consulta_duracion = new System.Windows.Forms.RadioButton();
            this.consulta_fecha = new System.Windows.Forms.RadioButton();
            this.LogIn = new System.Windows.Forms.RadioButton();
            this.SignUp = new System.Windows.Forms.RadioButton();
            this.conectar = new System.Windows.Forms.Button();
            this.desconectar = new System.Windows.Forms.Button();
            this.chat = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(183, 296);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.chat);
            this.groupBox1.Controls.Add(this.invitar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.consulta_lista);
            this.groupBox1.Controls.Add(this.consulta_duracion);
            this.groupBox1.Controls.Add(this.consulta_fecha);
            this.groupBox1.Controls.Add(this.LogIn);
            this.groupBox1.Controls.Add(this.SignUp);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(25, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(484, 347);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticion";
            // 
            // invitar
            // 
            this.invitar.AutoSize = true;
            this.invitar.Location = new System.Drawing.Point(155, 228);
            this.invitar.Margin = new System.Windows.Forms.Padding(4);
            this.invitar.Name = "invitar";
            this.invitar.Size = new System.Drawing.Size(182, 21);
            this.invitar.TabIndex = 12;
            this.invitar.TabStop = true;
            this.invitar.Text = "Invitar a otros jugadores";
            this.invitar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 9;
            // 
            // consulta_lista
            // 
            this.consulta_lista.AutoSize = true;
            this.consulta_lista.Location = new System.Drawing.Point(155, 199);
            this.consulta_lista.Margin = new System.Windows.Forms.Padding(4);
            this.consulta_lista.Name = "consulta_lista";
            this.consulta_lista.Size = new System.Drawing.Size(274, 21);
            this.consulta_lista.TabIndex = 11;
            this.consulta_lista.TabStop = true;
            this.consulta_lista.Text = "Consultar la lista de jugadores en linea";
            this.consulta_lista.UseVisualStyleBackColor = true;
            // 
            // consulta_duracion
            // 
            this.consulta_duracion.AutoSize = true;
            this.consulta_duracion.Location = new System.Drawing.Point(155, 171);
            this.consulta_duracion.Margin = new System.Windows.Forms.Padding(4);
            this.consulta_duracion.Name = "consulta_duracion";
            this.consulta_duracion.Size = new System.Drawing.Size(230, 21);
            this.consulta_duracion.TabIndex = 10;
            this.consulta_duracion.TabStop = true;
            this.consulta_duracion.Text = "Consultar ganador por duracion";
            this.consulta_duracion.UseVisualStyleBackColor = true;
            // 
            // consulta_fecha
            // 
            this.consulta_fecha.AutoSize = true;
            this.consulta_fecha.Location = new System.Drawing.Point(155, 142);
            this.consulta_fecha.Margin = new System.Windows.Forms.Padding(4);
            this.consulta_fecha.Name = "consulta_fecha";
            this.consulta_fecha.Size = new System.Drawing.Size(210, 21);
            this.consulta_fecha.TabIndex = 9;
            this.consulta_fecha.TabStop = true;
            this.consulta_fecha.Text = "Consultar ganador por fecha";
            this.consulta_fecha.UseVisualStyleBackColor = true;
            // 
            // LogIn
            // 
            this.LogIn.AutoSize = true;
            this.LogIn.Location = new System.Drawing.Point(155, 112);
            this.LogIn.Margin = new System.Windows.Forms.Padding(4);
            this.LogIn.Name = "LogIn";
            this.LogIn.Size = new System.Drawing.Size(240, 21);
            this.LogIn.TabIndex = 7;
            this.LogIn.TabStop = true;
            this.LogIn.Text = "Quiero hacer Log In en mi cuenta";
            this.LogIn.UseVisualStyleBackColor = true;
            // 
            // SignUp
            // 
            this.SignUp.AutoSize = true;
            this.SignUp.Location = new System.Drawing.Point(155, 84);
            this.SignUp.Margin = new System.Windows.Forms.Padding(4);
            this.SignUp.Name = "SignUp";
            this.SignUp.Size = new System.Drawing.Size(163, 21);
            this.SignUp.TabIndex = 8;
            this.SignUp.TabStop = true;
            this.SignUp.Text = "Quiero darme de alta";
            this.SignUp.UseVisualStyleBackColor = true;
            // 
            // conectar
            // 
            this.conectar.Location = new System.Drawing.Point(563, 140);
            this.conectar.Margin = new System.Windows.Forms.Padding(4);
            this.conectar.Name = "conectar";
            this.conectar.Size = new System.Drawing.Size(100, 28);
            this.conectar.TabIndex = 7;
            this.conectar.Text = "Conectar";
            this.conectar.UseVisualStyleBackColor = true;
            this.conectar.Click += new System.EventHandler(this.conectar_Click);
            // 
            // desconectar
            // 
            this.desconectar.Location = new System.Drawing.Point(563, 197);
            this.desconectar.Margin = new System.Windows.Forms.Padding(4);
            this.desconectar.Name = "desconectar";
            this.desconectar.Size = new System.Drawing.Size(100, 28);
            this.desconectar.TabIndex = 8;
            this.desconectar.Text = "Desonectar";
            this.desconectar.UseVisualStyleBackColor = true;
            this.desconectar.Click += new System.EventHandler(this.desconectar_Click);
            // 
            // chat
            // 
            this.chat.AutoSize = true;
            this.chat.Location = new System.Drawing.Point(155, 257);
            this.chat.Margin = new System.Windows.Forms.Padding(4);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(92, 21);
            this.chat.TabIndex = 13;
            this.chat.TabStop = true;
            this.chat.Text = "Abrir Chat";
            this.chat.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 420);
            this.Controls.Add(this.desconectar);
            this.Controls.Add(this.conectar);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton LogIn;
        private System.Windows.Forms.RadioButton SignUp;
        private System.Windows.Forms.RadioButton consulta_fecha;
        private System.Windows.Forms.Button conectar;
        private System.Windows.Forms.Button desconectar;
        private System.Windows.Forms.RadioButton consulta_duracion;
        private System.Windows.Forms.RadioButton consulta_lista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton invitar;
        private System.Windows.Forms.RadioButton chat;
    }
}

