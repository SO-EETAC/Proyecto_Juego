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
    public partial class Form2 : Form
    {
        Form1 F1 = new Form1();
        string name;
        string username;
        string password;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public string SetNombre()
        {
            return name;
        }
        public string SetUsuario()
        {
            return username;
        }
        public string SetContraseña()
        {
            return password;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            name = nombre.Text;
            username = usuario.Text;
            password = contraseña.Text;
            Close();
        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
