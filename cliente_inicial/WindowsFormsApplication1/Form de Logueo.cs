using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        
        string username;
        string password;
        public Form3()
        {
            InitializeComponent();
        }
        public string SetUser()
        {
            return username;
        }
        public string SetPassword()
        {
            return password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            password = textBox2.Text;
            Close();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
