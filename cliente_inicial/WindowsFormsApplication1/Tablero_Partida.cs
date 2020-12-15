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
        string usuario;
        string invitador;
        string participantes;
        int numParticipantes;
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
        public void setParticipantes(string p)
        {
            participantes = p; // anakilator_juanito23_martita21
        }
        public void setNumParticipantes(int n)
        {
            numParticipantes = n;
        }
        private void Tablero_Partida_Load(object sender, EventArgs e)
        {
            turno1Lbl.Text = "Primer turno:" + invitador;
            
            string[] seg = participantes.Split('_');
            

            jugador1Lbl.Text = seg[0];
            jugador2Lbl.Text = seg[1];
            Jugador3Lbl.Text = seg[2];
            Jugador4Lbl.Text = seg[3];
            
            






        }
    }
}
