using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace loginValidaciones
{
    public partial class inicio : Form
    {
        public inicio()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //Sirve para cuando haga click en el boton registro ir al form de registro
            this.Hide();
            InicioSesion ventanaIS = new InicioSesion();
            ventanaIS.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //Sirve para cuando haga click en el boton inicio de sesion ir al form de inicio de sesion
            this.Hide();
            Registro registro = new Registro();
            registro.Show();
        }
    }
}
