using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form5 : Form
    {
        string duracion;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        
        public string getDuracion()
        {
            return duracion;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_duracion_Click(object sender, EventArgs e)
        {
            duracion = Duracion.Text;
            Close();
        }

        private void Duracion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
