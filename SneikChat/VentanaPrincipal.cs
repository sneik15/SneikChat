using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SneikChat
{
    public partial class VentanaPrincipal : Form
    {
        private String usuario = "Default";
        private String host = "127.0.0.1";
        public String hostAUX;
        public int puertoAUX;
        private int puerto = 25566;
        private ManejadorServer cliente;
        private GestionFichero fichero;
        private String archivo;

        public VentanaPrincipal()
        {
            InitializeComponent();
            archivo = Application.StartupPath + @"\SneikChat.ini";
            fichero = new GestionFichero(archivo);
            CheckForIllegalCrossThreadCalls = false;
            fichero.LeerConfig();
            List<String> config = fichero.GetConfig();
            usuario = config[0];
            cliente = new ManejadorServer(host, puerto, usuario, chatPrincipal, listaUsuarios);
            host = config[1];
            try{
                puerto = int.Parse(config[2]);
            }
            catch
            {
                puerto = 25566;
            }
            hostAUX = host;
            puertoAUX = puerto;
            lblUsu.Text = usuario;
        }

        private void Conectar(object sender, EventArgs e)
        {
            if (!cliente.GetConectado())
            {
                cliente.SetHost(host);
                cliente.SetPuerto(puerto);
                Thread clienteTH = new Thread(delegate()
                {
                    cliente.Cliente();
                });
                clienteTH.Start();
            }
        }

        private void Enviar(object sender, EventArgs e)
        {
            String msg = txtEnviar.Text;
            if (!msg.StartsWith("<<cmd>>!"))
            {
                cliente.EnviarMSG(usuario + " > " + msg);
            }
            else
            {
                cliente.EnviarMSG(msg);
            }
            txtEnviar.Text = "";
        }

        private void EditarIP(object sender, EventArgs e)
        {
            EditarIP edi = new EditarIP(this);
            edi.Show();
        }

        private void EditarPuerto(object sender, EventArgs e)
        {
            EditarPuerto edi = new EditarPuerto(this);
            edi.Show();
        }

        private void EditarUsu(object sender, EventArgs e)
        {
            EditarUsuario edi = new EditarUsuario(lblUsu,cliente);
            edi.Show();
        }

        private void TPulsada(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                String msg = txtEnviar.Text;
                if (!msg.StartsWith("<<cmd>>!"))
                {
                    cliente.EnviarMSG(usuario + " > " + msg);
                }
                else
                {
                    cliente.EnviarMSG(msg);
                }
                txtEnviar.Text = "";
                e.Handled = true;
            }
        }

        private void Cerrando(object sender, FormClosingEventArgs e)
        {
            if (cliente.GetConectado())
            {
                cliente.EnviarMSG("<<cmd>>!UDcnt" + usuario);
                cliente.EnviarMSG("<<cmd>>!salir");
                cliente.SetSalir(true);
            }
        }

        private void AcercaDe(object sender, EventArgs e)
        {
            AcercaDe ad = new AcercaDe();
            ad.Show();
        }

        private void AcUsuarios(object sender, EventArgs e)
        {
            if (!usuario.Equals(lblUsu.Text)){
                usuario = lblUsu.Text;
                fichero.GrabarConfig(usuario,host,puerto.ToString());
            }
            if (cliente.acListaUsu)
            {
                listaUsuarios.Controls.Clear();
                foreach (String usr in cliente.listaUsuarios)
                {
                    listaUsuarios.Controls.Add(new Usuario(usr));
                }
                cliente.acListaUsu = false;
            }
            if (!host.Equals(hostAUX))
            {
                host = hostAUX;
                fichero.GrabarConfig(usuario, host, puerto.ToString());
            }
            if (!puerto.ToString().Equals(puertoAUX))
            {
                puerto = puertoAUX;
                fichero.GrabarConfig(usuario, host, puerto.ToString());
            }
        }

        private void ActualizarScroll(object sender, EventArgs e)
        {
            chatPrincipal.SelectionStart = chatPrincipal.Text.Length;
            chatPrincipal.ScrollToCaret();
        }
    }
}
