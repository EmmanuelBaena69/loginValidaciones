using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginValidaciones
{
    public partial class meme : Form
    {
        public meme()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            //Para ir al inicio de sesion
            this.Hide();
            InicioSesion back = new InicioSesion();
            back.Show();
        }
    }
}
