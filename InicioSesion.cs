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
    public partial class InicioSesion : Form
    {
        int intento = 0;
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                //Sirve para buscar el archivo en la carpeta debug y leerlo de lo contrario mostrara error
                TextReader Sesion = new StreamReader(txtUsuario.Text + ".txt");

                //Para verificar campos vacios
                if (txtUsuario.Text.Trim() == "" || txtPassw.Text.Trim() == "")
                {
                    MessageBox.Show("Por favor llene los campos");
                }

                //Verifica si el usuario y la contraseña coinciden 
                if (Sesion.ReadLine() == txtPassw.Text)
                {
                    MessageBox.Show("Ha Iniciado Sesion");
                }
                else
                {
                    //Contador para numero de intentos y cuando se supere el numero
                    //de intentos permitidos sacar al usuario sospechoso
                    intento++;
                    if (intento >= 3)
                    {
                        Application.Exit();
                    }

                    MessageBox.Show("Nombre de usuario o contraseña incorrectas");
                }

            }
            catch (Exception)
            {
                //Error si no se ha registrado (No encontraria el archivo en la carpeta)
                MessageBox.Show("El usuario no ha sido registrado");
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Para ir al Menu
            this.Hide();
            inicio back = new inicio();
            back.Show();
        }
    }
}
