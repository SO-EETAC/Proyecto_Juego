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
    public partial class Form7 : Form
    {
        string listado_invitados, usuario;
        string invitador;
        string respuesta;

        public Form7()
        {
            InitializeComponent();
        }

        public void setListado(string jugadores)
        {
            listado_invitados = jugadores; //2_anakilator_juanito23
        }
        public void setInvitador(string Invitador)
        {
            invitador = Invitador; //anakilator
        }

        public void setUsuario(string usr)
        {
            usuario = usr; //juanito23
        }
        public string GetRespuesta()
        {
            return respuesta;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            if (usuario != invitador)
            {
                if (usuario == "anakilator")
                {
                    this.BackColor = Color.Red;
                }
                invitadorLbl.Text = invitador;
                
                string[] segmentos = listado_invitados.Split('_');

                if (segmentos[0] == "0")
                {

                    MessageBox.Show("Tiene que seleccionar jugadores!");
                    this.Close();

                }
                //else if (segmentos[0] == "1")
                //{

                //    MessageBox.Show("Tiene que seleccionar 2 o más jugadores!");
                //    this.Close();

                //}
                else
                {
                    for (int i = 1; i < (Convert.ToInt32(segmentos[0]) + 1); i++)
                        if (segmentos[i] != invitador)
                        {
                            listView1.Items.Add(segmentos[i]);
                        }

                    //for (int i = 1; i < (Convert.ToInt32(segmentos[0]) + 1); i++)
                    //{

                    //listView1.Items.Add(segmentos[i]);

                    //}
                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            respuesta = "no";
            Close();
        }

        private void button1_Click(object sender, EventArgs e)//Aceptar_click (aceptar invitacion)
        {

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                string cmpr = usuario;
                if (listView1.Items[i].Text == cmpr)
                {

                    listView1.Items[i].BackColor = Color.Green;

                }

            }
            
            respuesta = "si";
            Close();


        }
    }
}
//Judit y Hector