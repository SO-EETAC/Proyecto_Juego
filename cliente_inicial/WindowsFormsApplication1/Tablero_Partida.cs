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
    public partial class Tablero_Partida : Form
    {
        string listado_invitados, usuario;
        string invitador;
        string frase;
        public Tablero_Partida()
        {
            InitializeComponent();
        }
        public void setInvitador(string Invitador)
        {
            invitador = Invitador; //anakilator
        }

        public void setUsuario(string usr)
        {
            usuario = usr; //juanito23
        }

        
        private void Tablero_Partida_Load(object sender, EventArgs e)
        {
            jugador1Lbl.Text = invitador;
            jugador2Lbl.Text = usuario;
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NumFichasJug3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {//boton enviar
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
