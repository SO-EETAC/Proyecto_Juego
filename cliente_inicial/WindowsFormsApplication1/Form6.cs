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
    public partial class Form6 : Form
    {
        string listado_jugadores, usuario;
        string listado_invitados;
        int cont = 0;

        public Form6()
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
        public string GetListado()
        {
            
            return listado_invitados; // numInvitados/invitado[0]/invitado[1]/...
        }

        

        private void Form6_Load(object sender, EventArgs e)
        {
            cont++;

            if (cont == 1)
            {
                this.BackColor = Color.Red;
            }
            else if (cont == 2)
            {
                this.BackColor = Color.Blue;
            }


            //recogemos la lista de jugadores en línea y los mostramos
            string[] segmentos = listado_jugadores.Split('_'); 

            if (segmentos[0] == "0")
            { //no hay

                listBox1.Items.Add("No hay ningún jugador en linea");

            }
            else if (segmentos[0] == "1")
            { //hay 1

                listBox1.Items.Add("El/La jugador/a en linea es: ");

                if (segmentos[1]  == usuario) //cuando coincida el nombre del listado con el usuario que te has registrado, en la lista de conectados ponemos(Tu) al lado de tu usuario.
                    listBox1.Items.Add(segmentos[1] + "(Tú)"); 
                else
                    listBox1.Items.Add(segmentos[1]);
            }
            else
            { //hay mas de 1

                listBox1.Items.Add("Los " + Convert.ToInt32(segmentos[0]) + " jugadores en linea son: ");

                for (int i = 1; i < (Convert.ToInt32(segmentos[0])+1); i++)
                {
                    if (segmentos[i] == usuario) //cuando coincida el nombre del listado con el usuario que te has registrado, en la lista de conectados ponemos(Tu) al lado de tu usuario.
                        listBox1.Items.Add(segmentos[i] + "(Tú)");
                    else
                        listBox1.Items.Add(segmentos[i]);

                }
            }
        }

        private void invitar_Click(object sender, EventArgs e)
        {//Se seleccionan los usuarios que queremos invitar, y se crea una lista de invitados

            string num_invitados = Convert.ToString(listBox1.SelectedIndices.Count);

            listado_invitados = num_invitados + "/" + listBox1.SelectedItems[0];

            for (int i = 1; i < listBox1.SelectedIndices.Count; i++)
            {
                
                listado_invitados = listado_invitados + "/" + listBox1.SelectedItems[i]; 

            }
            Close();
          
        }


    }
}
