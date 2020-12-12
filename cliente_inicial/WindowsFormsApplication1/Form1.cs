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
        Tablero_Partida F8 = new Tablero_Partida();

        string nombre;
        string usuario;
        string contraseña;
        string user_login;
        string password_login;
        string fecha;
        string duracion;
        string conectados;
        string aceptados;
        int cont_invitados = 1;
        int cont_aceptados = 1; //el invitador cuenta como el primer aceptado

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void AtenderServidor()
        {

            while (true)
            {
                //Recibimos la respuesta del servidor //  7/invitador
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1].Split('\0')[0];
                Form6 F6 = new Form6();
                Form7 F7 = new Form7();
                string[] seg;
                string invitador;
                int numInvitados;
                string invitado;
                string respuesta;

                switch (codigo)
                {

                    case 1:
                        //Puedo crear una cuenta

                        MessageBox.Show(mensaje);
                        break;

                    case 2:
                        //Puedo iniciar sesión? Recibo un mensaje de la forma Y_Usuario o N

                        string[] segmentos = mensaje.Split('_');

                        if (segmentos[0] == "Y")
                        {
                            MessageBox.Show("Has sido autenticado correctamente!!!");
                            usuario = segmentos[1];
                            label1.Text = "Has iniciado sesión como: " + usuario;
                        }
                        else if (segmentos[0] == "N")
                            MessageBox.Show("Contraseña incorrecta");
                        else if (segmentos[0] == "USER")
                            MessageBox.Show("El usuario no existe.");

                        break;

                    case 3:
                        //Hay ganadores para una fecha?

                        if (mensaje == "NOT_FOUND")
                            MessageBox.Show("No hay ganadores para esta fecha");
                        else
                            MessageBox.Show(mensaje);
                        break;

                    case 4:
                        //Hay ganadores para una duración?

                        if (mensaje == "NOT_FOUND")
                            MessageBox.Show("No hay ganadores con la duracion de partida proporcionada ");
                        else
                            MessageBox.Show(mensaje);
                        break;

                    case 5:
                        //Que usuarios hay conectados?

                        F6.setListado(mensaje);
                        F6.setUsuario(usuario);
                        F6.ShowDialog();
                        break;

                    case 6:
                        //Hay una notificación de nuevo conectado!

                        conectados = mensaje;   //  2_anakilator_juanito23
                        F6.setListado(conectados);
                        F6.setUsuario(usuario);
                        F6.ShowDialog();
                        break;

                    case 7:
                        //Hay una invitación: 7/invitador_numInvitados_invitado

                        
                        seg = mensaje.Split(new char[] { '_' }, 3);


                        invitador = seg[0];
                        numInvitados = Convert.ToInt32(seg[1]);
                        invitado = seg[2];



                        if ((invitado == usuario)&&(invitador != usuario))
                        {
                            MessageBox.Show("Hola " + invitado + ", " + invitador + " te ha invitado a jugar!");
                            F7.setListado(conectados);
                            F7.setInvitador(invitador);
                            F7.setUsuario(usuario);
                            F7.ShowDialog();
                            respuesta = F7.GetRespuesta();
                            //Enviamos petición con la respuesta de la invitacion
                            string mensj = "8/" + invitador + "/" + numInvitados + "/" + invitado + "/" + respuesta;
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensj);
                            server.Send(msg);
                            
                        }
                        break;
                        
                    case 9:
                        //El invitador recibe respuesta de la invitacion: 9/invitador_numInvitados_invitado_siOno

                        seg = mensaje.Split(new char[] { '_' }, 4);


                        invitador = seg[0];
                        numInvitados = Convert.ToInt32(seg[1]);
                        invitado = seg[2];
                        respuesta = seg[3];

                        if (usuario == invitador)
                        {
                            aceptados = invitador;

                            while (cont_aceptados <= cont_invitados)
                            {
                                if (respuesta == "no")
                                {
                                    MessageBox.Show(invitado + " ha rechazado la invitación");
                                    cont_invitados++; //incrementamos +1 el contador de invitados que han contestado
                                }
                                else
                                { //respuesta == si, tmb podria ser k no conteste alguno
                                    F8.setInvitador(invitador);
                                    
                                    cont_invitados++; //incrementamos +1 el contador de invitados que han contestado
                                    cont_aceptados++;//incrementamos +1 el contador de invitados que han aceptado
                                    aceptados = aceptados + "_" + invitado;//añadimos el usuario a la lista de aceptados
                                    if (numInvitados == cont_invitados)
                                    {
                                        //Quiere enviar mensaje a todos los invitados que han aceptado para empezar a jugar
                                        string mensj = "10" + "/" + Convert.ToString(cont_aceptados) + "/" + aceptados;
                                        // Enviamos al servidor
                                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensj);
                                        server.Send(msg);
                                        F8.ShowDialog();
                                    }
                                }
                            }
                        }
                        break;

                    case 11:

                        //Los que han aceptado, empiezan a jugar;  mensaje:11/aceptado/lista_participantes
                        seg = mensaje.Split(new char[] { '/' }, 4);

                        invitado = seg[0];
                        aceptados = seg[1];
                        string[] s = aceptados.Split(new char[] { '_' }, cont_aceptados);
                        int i = 1;
                        while (i < cont_aceptados)
                        {
                            invitador = s[0];
                            
                            if((usuario!=invitador)&&(usuario == invitado))
                            {
                                F8.setInvitador(invitador);
                                F8.setUsuario(invitado);
                                F8.setNumParticipantes(cont_aceptados);
                                F8.setParticipantes(aceptados);
                                F8.ShowDialog();
                            }
                            i++;
                        }
                        break;

                }

            }
         
        }

        private void conectar_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102"); //147.83.117.22
            IPEndPoint ipep = new IPEndPoint(direc, 9003); //50001
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
            else if(invitar.Checked)
            {
                Form6 F6 = new Form6();
                F6.setListado(conectados);
                F6.ShowDialog();
                string invitados = F6.GetListado();
                string mensaje = "6/"+usuario+"/"+invitados; //    6/invitador/1/listado_invitados
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
