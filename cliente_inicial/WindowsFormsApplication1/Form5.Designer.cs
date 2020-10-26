namespace WindowsFormsApplication1
{
    partial class Form5
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
            this.Duracion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_duracion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Duracion
            // 
            this.Duracion.Location = new System.Drawing.Point(302, 77);
            this.Duracion.Name = "Duracion";
            this.Duracion.Size = new System.Drawing.Size(164, 20);
            this.Duracion.TabIndex = 5;
            this.Duracion.TextChanged += new System.EventHandler(this.Duracion_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Introduce la duracion";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button_duracion
            // 
            this.button_duracion.Location = new System.Drawing.Point(240, 140);
            this.button_duracion.Margin = new System.Windows.Forms.Padding(2);
            this.button_duracion.Name = "button_duracion";
            this.button_duracion.Size = new System.Drawing.Size(73, 26);
            this.button_duracion.TabIndex = 7;
            this.button_duracion.Text = "Consultar";
            this.button_duracion.UseVisualStyleBackColor = true;
            this.button_duracion.Click += new System.EventHandler(this.button_duracion_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 194);
            this.Controls.Add(this.button_duracion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Duracion);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Duracion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_duracion;
    }
}