using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace loginValidaciones
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                //Codigo para registrar un usuario, el archivo se alacenara en la carpeta debug
                TextWriter regsitro = new StreamWriter(@"C:\Users\emman\OneDrive\Documents\c# y .net\loginValidaciones\bin\Debug\" + txtUsuario.Text + ".txt", true);
                
                //Guardar contraseña dentro de archivo
                regsitro.WriteLine(txtPassw.Text);
                regsitro.Close();

                //Para verificar campos vacios
                if (txtUsuario.Text.Trim() == "" || txtPassw.Text.Trim() == "")
                {
                    MessageBox.Show("Por favor llene los campos");
                }
                else
                {
                    MessageBox.Show("Usuario Regitrado Correctamente");
                }
            }
            catch (Exception h)
            {

                MessageBox.Show("Hubo un erro" + h, "Error");
                
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
