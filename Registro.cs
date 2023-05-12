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
using System.Data.SQLite;

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
    
            //Para verificar campos vacios
            if (txtUsuario.Text.Trim() != "" && txtPassw.Text.Trim() != "")
            {
                try
                {
                    //Login con SQLite
                    SQLiteConnection conexion_sqlite;
                    SQLiteCommand cmd_sqlite;
                    SQLiteDataReader datareader_sqlite;

                    //Conexion a la base de datos
                    conexion_sqlite = new SQLiteConnection("Data Source=login.db;Version=3;");

                    //Abrimos la conexion
                    conexion_sqlite.Open();

                    cmd_sqlite = conexion_sqlite.CreateCommand();


                    //Insertando valores, no se inserta el id ya que es auto incrementable
                    cmd_sqlite.CommandText = string.Format("INSERT INTO tbl_Users (nom, passw) VALUES ('" + txtUsuario.Text + "', " + txtPassw.Text +")"); 

                    datareader_sqlite = cmd_sqlite.ExecuteReader();

                    while (datareader_sqlite.Read())
                    {
                        //Mostrando los datos

                        string nom = datareader_sqlite.GetString(1);
                        string passw = datareader_sqlite.GetString(2);

                    }

                    conexion_sqlite.Close();
                    MessageBox.Show("Registrado Correctamente");

                }
                catch (Exception iu)
                {

                    MessageBox.Show("Error al intentar registrarse" + iu.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor llene los campos");
            }

            //Login con archivos planos
            /*
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
