using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SneikChat
{
    public partial class EditarUsuario : Form
    {
        Label usuario;
        ManejadorServer cliente;
        public EditarUsuario(Label user,ManejadorServer clientep)
        {
            InitializeComponent();
            usuario = user;
            cliente = clientep;
        }

        private void Cancelar(object sender, EventArgs e)
        {
            Close();
        }

        private void Aceptar(object sender, EventArgs e)
        {
            usuario.Text = txtUsuario.Text;
            if (cliente.GetConectado())
            {
                cliente.SetNomUser(usuario.Text);
            }
            else
            {
                cliente.SetNomUserSC(usuario.Text);
            }
            Close();
        }
    }
}
