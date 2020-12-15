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
    public partial class Form9 : Form
    {
        string frase, mensaje;
        string listado_jugadores;
        string usuario, emisor;
        public Form9()
        {
            InitializeComponent();
        }

        public void setListado(string jugadores)
        {
            listado_jugadores = jugadores;
        }
        public void setUsuario(string usr)
        {
            usuario = usr;
        }
        public void setEmisor(string e)
        {
            emisor = e;
        }
        public void setMensaje(string f)
        {
            mensaje = f;
        }

        public string GetFrase()
        {
            return frase; //frase del chat
        }

        private void button1_Click(object sender, EventArgs e)
        {//enviar mensaje de chat
            frase = fraseBox.Text;
            fraseBox.Text = null;
            listBox1.Items.Add(usuario+": " + frase);
            Close();
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            if (usuario == "anakilator")
            {
                this.BackColor = Color.Red;
            }
            listBox1.Items.Add(emisor + ": " + mensaje);
        }
    }
}
