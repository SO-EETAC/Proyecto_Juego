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
            this.consulta_lista = new System.Windows.Forms.RadioButton();
            this.consulta_duracion = new System.Windows.Forms.RadioButton();
            this.consulta_fecha = new System.Windows.Forms.RadioButton();
            this.LogIn = new System.Windows.Forms.RadioButton();
            this.SignUp = new System.Windows.Forms.RadioButton();
            this.conectar = new System.Windows.Forms.Button();
            this.desconectar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(132, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.consulta_lista);
            this.groupBox1.Controls.Add(this.consulta_duracion);
            this.groupBox1.Controls.Add(this.consulta_fecha);
            this.groupBox1.Controls.Add(this.LogIn);
            this.groupBox1.Controls.Add(this.SignUp);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(19, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 282);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticion";
            // 
            // consulta_lista
            // 
            this.consulta_lista.AutoSize = true;
            this.consulta_lista.Location = new System.Drawing.Point(116, 162);
            this.consulta_lista.Name = "consulta_lista";
            this.consulta_lista.Size = new System.Drawing.Size(205, 17);
            this.consulta_lista.TabIndex = 11;
            this.consulta_lista.TabStop = true;
            this.consulta_lista.Text = "Consultar la lista de jugadores en linea";
            this.consulta_lista.UseVisualStyleBackColor = true;
            // 
            // consulta_duracion
            // 
            this.consulta_duracion.AutoSize = true;
            this.consulta_duracion.Location = new System.Drawing.Point(116, 139);
            this.consulta_duracion.Name = "consulta_duracion";
            this.consulta_duracion.Size = new System.Drawing.Size(173, 17);
            this.consulta_duracion.TabIndex = 10;
            this.consulta_duracion.TabStop = true;
            this.consulta_duracion.Text = "Consultar ganador por duracion";
            this.consulta_duracion.UseVisualStyleBackColor = true;
            // 
            // consulta_fecha
            // 
            this.consulta_fecha.AutoSize = true;
            this.consulta_fecha.Location = new System.Drawing.Point(116, 115);
            this.consulta_fecha.Name = "consulta_fecha";
            this.consulta_fecha.Size = new System.Drawing.Size(159, 17);
            this.consulta_fecha.TabIndex = 9;
            this.consulta_fecha.TabStop = true;
            this.consulta_fecha.Text = "Consultar ganador por fecha";
            this.consulta_fecha.UseVisualStyleBackColor = true;
            // 
            // LogIn
            // 
            this.LogIn.AutoSize = true;
            this.LogIn.Location = new System.Drawing.Point(116, 91);
            this.LogIn.Name = "LogIn";
            this.LogIn.Size = new System.Drawing.Size(183, 17);
            this.LogIn.TabIndex = 7;
            this.LogIn.TabStop = true;
            this.LogIn.Text = "Quiero hacer Log In en mi cuenta";
            this.LogIn.UseVisualStyleBackColor = true;
            // 
            // SignUp
            // 
            this.SignUp.AutoSize = true;
            this.SignUp.Location = new System.Drawing.Point(116, 68);
            this.SignUp.Name = "SignUp";
            this.SignUp.Size = new System.Drawing.Size(123, 17);
            this.SignUp.TabIndex = 8;
            this.SignUp.TabStop = true;
            this.SignUp.Text = "Quiero darme de alta";
            this.SignUp.UseVisualStyleBackColor = true;
            // 
            // conectar
            // 
            this.conectar.Location = new System.Drawing.Point(422, 114);
            this.conectar.Name = "conectar";
            this.conectar.Size = new System.Drawing.Size(75, 23);
            this.conectar.TabIndex = 7;
            this.conectar.Text = "Conectar";
            this.conectar.UseVisualStyleBackColor = true;
            this.conectar.Click += new System.EventHandler(this.conectar_Click);
            // 
            // desconectar
            // 
            this.desconectar.Location = new System.Drawing.Point(422, 160);
            this.desconectar.Name = "desconectar";
            this.desconectar.Size = new System.Drawing.Size(75, 23);
            this.desconectar.TabIndex = 8;
            this.desconectar.Text = "Desonectar";
            this.desconectar.UseVisualStyleBackColor = true;
            this.desconectar.Click += new System.EventHandler(this.desconectar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 341);
            this.Controls.Add(this.desconectar);
            this.Controls.Add(this.conectar);
            this.Controls.Add(this.groupBox1);
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
    }
}

