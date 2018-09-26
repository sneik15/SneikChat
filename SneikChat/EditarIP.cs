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
    public partial class EditarIP : Form
    {
        private VentanaPrincipal prin;
        public EditarIP(VentanaPrincipal host)
        {
            InitializeComponent();
            prin= host;
        }

        private void Aceptar(object sender, EventArgs e)
        {
            prin.hostAUX = txtIP.Text;
            Close();
        }

        private void Cancelar(object sender, EventArgs e)
        {
            Close();
        }
    }
}
