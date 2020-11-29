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

        int my_index = -1;

        public Form7()
        {
            InitializeComponent();
        }

        public void setListado(string jugadores)
        {
            listado_invitados = jugadores;
        }

        public void setUsuario(string usr)
        {
            usuario = usr;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
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
                {

                    listView1.Items.Add(segmentos[i]);

                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                string cmpr = usuario + "(Tú)";
                if (listView1.Items[i].Text == cmpr)
                {

                    listView1.Items[i].BackColor = Color.Green;

                }

            }


        }
    }
}
