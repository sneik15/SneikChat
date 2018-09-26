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
    public partial class EditarPuerto : Form
    {
        VentanaPrincipal pri;
        public EditarPuerto(VentanaPrincipal prin)
        {
            InitializeComponent();
            pri = prin;
        }

        private void Aceptar(object sender, EventArgs e)
        {
            try
            {
                pri.puertoAUX = int.Parse(txtPuerto.Text);
            }
            catch
            {
                pri.puertoAUX = 25566;
                MessageBox.Show("Puerto no valido, use el siguiente formato: 25566", "Atención",
                  MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            Close();
        }

        private void Cancelar(object sender, EventArgs e)
        {
            Close();
        }
    }
}
