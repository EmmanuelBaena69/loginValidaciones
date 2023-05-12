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
using static System.Collections.Specialized.BitVector32;
using System.Data.SQLite;

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
                SQLiteConnection conexion_sqlite;
                SQLiteCommand cmd_sqlite;
                SQLiteDataReader datareader_sqlite;

                //Conexion a la base de datos
                conexion_sqlite = new SQLiteConnection("Data Source=login.db;Version=3;Compress=True;");

                //Abrimos la conexion
                conexion_sqlite.Open();

                cmd_sqlite = conexion_sqlite.CreateCommand();

                cmd_sqlite.CommandText = string.Format("SELECT * FROM tbl_Users WHERE nom = '{0}' AND passw = '{1}'", txtUsuario.Text, txtPassw.Text);

                int count = Convert.ToInt32(cmd_sqlite.ExecuteScalar());

                if (count > 0) 
                {
                    this.Hide();
                    meme img = new meme();
                    img.Show();
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

                conexion_sqlite.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error al registrar usuario" + error.Message);
            }

            /*
             //Login con archivos planos
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
                    //Para ir a pantalla meme
                    this.Hide();
                    meme img = new meme();
                    img.Show();
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
            }*/
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
