﻿using System;
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

        private void Form6_Load(object sender, EventArgs e)
        {
            string[] segmentos = listado_jugadores.Split('_');

            if (segmentos[0] == "0")
            {

                listBox1.Items.Add("No hay ningún jugador en linea");

            }
            else if (segmentos[0] == "1")
            {
                listBox1.Items.Add("El/La jugador/a en linea es: ");
                if (segmentos[1]  == usuario)
                    listBox1.Items.Add(segmentos[1] + "(Tú)");
                else
                    listBox1.Items.Add(segmentos[1]);
            }
            else
            {
                listBox1.Items.Add("Los " + Convert.ToInt32(segmentos[0]) + " jugador en linea son: ");

                for (int i = 1; i < (Convert.ToInt32(segmentos[0])+1); i++)
                {
                    if (segmentos[i] == usuario)
                        listBox1.Items.Add(segmentos[i] + "(Tú)");
                    else
                        listBox1.Items.Add(segmentos[i]);

                }
            }
        }

        private void invitar_Click(object sender, EventArgs e)
        {

            string mensaje = Convert.ToString(listBox1.SelectedIndices.Count);


            for (int i = 0; i < listBox1.SelectedIndices.Count; i++)
            {

                mensaje = mensaje + "_" + listBox1.SelectedItems[i];

            }
            Form7 F7 = new Form7();
            F7.setUsuario(usuario);                 
            F7.setListado(mensaje);
            F7.ShowDialog();


        }


    }
}
