using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace SneikChat
{
    public class ManejadorServer
    {
        private String host;
        private int puerto;
        private String nomUser;
        private bool salir;
        private bool conectado;
        private RichTextBox chat;
        private FlowLayoutPanel usuarios;
        private String ultMSG = "";
        private TcpClient cliente;
        private StreamReader entrada;
        private StreamWriter salida;
        public List<String> listaUsuarios;
        public bool acListaUsu;


        public ManejadorServer(String hostp,int puertop,String nomUserp,RichTextBox chatp,FlowLayoutPanel usuariosp)
        {
            host = hostp;
            puerto = puertop;
            nomUser = nomUserp;
            chat = chatp;
            usuarios = usuariosp;
            salir = false;
            conectado = false;
            ultMSG = "Ninguno";
            listaUsuarios = new List<string>();
            acListaUsu = false;
        }

        public void Cliente()
        {
            try
            {
                if (!conectado)
                {
                    conectado = true;
                    cliente = new TcpClient(host, puerto);
                    NetworkStream ns = cliente.GetStream();
                    entrada = new StreamReader(ns);
                    salida = new StreamWriter(ns);
                    chat.Text = "Conectado!";
                    EnviarMSG("<<cmd>>!Ucnt" + nomUser);
                    while (!salir)
                    {
                        String chatTmp = entrada.ReadLine();
                        try
                        {
                            if(chatTmp == null){
                                chatTmp = "null";
                            }
                        }
                        catch
                        {
                            chatTmp = "null";
                        }
                        if (chatTmp.StartsWith("<<cmd>>!Ucnt")) //Usuario conectado
                        {
                            String user = chatTmp.Substring(12);
                            listaUsuarios.Add(user);
                            chat.Text = chat.Text + Environment.NewLine + "Usuario conectado: " + user;
                            acListaUsu = true;
                        }
                        else if (chatTmp.StartsWith("<<cmd>>!UDcnt")) //Usuario desconectado
                        {
                            String user = chatTmp.Substring(13);
                            listaUsuarios.Remove(user);
                            chat.Text = chat.Text + Environment.NewLine + "Usuario desconectado: " + user;
                            acListaUsu = true;
                        }
                        else if (!chatTmp.Equals(ultMSG)) //Nuevo mensaje
                        {
                            chat.Text = chat.Text + Environment.NewLine + chatTmp;
                        }
                    }
                    ns.Close();
                    cliente.Close();
                    entrada.Close();
                    salida.Close();
                }
            }
            catch //fallo al conectarse
            {
                conectado = false;
                MessageBox.Show("Error en la conexión con el servidor", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                conectado = false;
            }
        }

        public void EnviarMSG(String mensaje)
        {
            try
            {
                salida.WriteLine(mensaje);
                salida.Flush();
            }
            catch
            {
                MessageBox.Show("No se ha podido enviar el mensage(Te has conectado?).", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public bool GetConectado()
        {
            return conectado;
        }

        public void SetNomUser(String nusu)
        {
            EnviarMSG("El usuario " + nomUser + " es ahora " + nusu);
            EnviarMSG("<<cmd>>!UDcnt" + nomUser);
            EnviarMSG("<<cmd>>!Ucnt" + nusu);
            nomUser = nusu;
        }

        public void SetNomUserSC(String nusu)
        {
            nomUser = nusu;
        }

        public void SetSalir(bool sal)
        {
            salir = sal;
        }

        public void SetHost(String hostP)
        {
            host = hostP;
        }

        public void SetPuerto(int puertoP)
        {
            puerto = puertoP;
        }
    }
}
