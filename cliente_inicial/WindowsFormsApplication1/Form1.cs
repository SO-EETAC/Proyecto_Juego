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
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;

        string nombre;
        string usuario;
        string contraseña;
        string user_login;
        string password_login;
        string fecha;
        string duracion;

        public Form1()
        {
            InitializeComponent();
        }

        private void AtenderServidor()
        {

            while (true)
            {
                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1].Split('\0')[0];
                Form6 F6 = new Form6();

                switch (codigo)
                {

                    case 1://Puedo crear una cuenta

                        MessageBox.Show(mensaje);
                        break;

                    case 2://Puedo iniciar sesión?

                        if (mensaje == "Y")
                            MessageBox.Show("Has sido autenticado correctamente!!!");
                        else if (mensaje == "N")
                            MessageBox.Show("Contraseña incorrecta");
                        else if (mensaje == "USER_NOT_FOUND")
                            MessageBox.Show("El usuario no existe.");
                        break;

                    case 3://Hay ganadores para una fecha?

                        if (mensaje == "NOT_FOUND")
                            MessageBox.Show("No hay ganadores para esta fecha");
                        else
                            MessageBox.Show(mensaje);
                        break;

                    case 4://Hay ganadores para una duración?

                        if (mensaje == "NOT_FOUND")
                            MessageBox.Show("No hay ganadores con la duracion de partida proporcionada ");
                        else
                            MessageBox.Show(mensaje);
                        break;

                    case 5://Que usuarios hay conectados?

                        F6.setListado(mensaje);
                        F6.ShowDialog();
                        break;

                    case 6://Hay una notificación!

                        F6.setListado(mensaje);
                        F6.ShowDialog();
                        break;

                }



            }
            


        }

        private void conectar_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("147.83.117.22");
            IPEndPoint ipep = new IPEndPoint(direc, 50001);
            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                //MessageBox.Show("Conectado");

            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }

            //Ponemos en marcha el thread que atenderá los mensajes del servidor
            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();

        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (SignUp.Checked)
            {
                Form2 F2 = new Form2();
                F2.ShowDialog();
                nombre = F2.SetNombre();
                usuario = F2.SetUsuario();
                contraseña = F2.SetContraseña();
                // Quiero saber si me he podido dar de alta o no
                string mensaje = "1/" + nombre + "/" + usuario + "/" + contraseña;
                // Enviamos al servidor el nombre tecleado

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else if (LogIn.Checked)
            {
                Form3 F3 = new Form3();

                F3.ShowDialog();
                user_login = F3.SetUser();
                password_login = F3.SetPassword();
                // Quiere loguearse

                string mensaje = "2/" + user_login + "/" + password_login;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else if (consulta_fecha.Checked)
            {
                Form4 F4 = new Form4();

                F4.ShowDialog();
                fecha = F4.getFecha();

                string mensaje = "3/" + fecha ;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else if (consulta_duracion.Checked)
            {
                Form5 F5 = new Form5();
                F5.ShowDialog();
                duracion = F5.getDuracion(); 

                string mensaje = "4/" + duracion;
                // Enviamos al servidor la duracion que nos han pasado por consola
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else if (consulta_lista.Checked){

                
                string mensaje = "5/";
                // Enviamos el código pertinente a la solicitud
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void desconectar_Click(object sender, EventArgs e)
        {
            //mensaje de desconexion
            string mensaje = "0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Se terminó el servicio. 

            atender.Abort();

            // Nos desconectamos
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
