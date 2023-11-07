using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;
using ImplementacionFramework1.Views.MenuViews;

namespace ImplementacionFramework1
{
    public partial class Form1 : Form
    {
        private int intentosFallidos = 0;
        private const int intentosMaximos = 3;
        public Form1()
        {
            InitializeComponent();

            // cadena de conexión
            string connectionString = "Server=localhost;Port=3306;Database=implementacion_framework2;User ID=root;Password=;";

            // conexión a la base de datos
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Conexión exitosa a la base de datos.");

                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error de conexión a la base de datos: " + ex.Message);
            }

            // Asigna los manejadores de eventos a los cuadros de texto
            textBox2.GotFocus += TextBox2_GotFocus;
            textBox2.LostFocus += TextBox2_LostFocus;

            textBox3.GotFocus += TextBox3_GotFocus;
            textBox3.LostFocus += TextBox3_LostFocus;

            SetPlaceholder(textBox2, "Usuario");
            SetPlaceholder(textBox3, "Contraseña");

        }

        private void TextBox2_GotFocus(object sender, EventArgs e)
        {
            if (IsPlaceholder(textBox2))
            {
                ClearPlaceholder(textBox2);
            }
        }

        private void TextBox2_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                SetPlaceholder(textBox2, "Usuario");
            }
        }

        private void TextBox3_GotFocus(object sender, EventArgs e)
        {
            if (IsPlaceholder(textBox3))
            {
                ClearPlaceholder(textBox3);
                textBox3.PasswordChar = '*'; // Para ocultar la contraseña
            }
        }

        private void TextBox3_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                SetPlaceholder(textBox3, "Contraseña");
                textBox3.PasswordChar = '\0'; // Mostrar el texto de ejemplo en lugar de caracteres ocultos
            }
        }

        private bool IsPlaceholder(TextBox textBox)
        {
            return textBox.Text == textBox.Tag as string;
        }

        private void ClearPlaceholder(TextBox textBox)
        {
            textBox.Text = "";
            textBox.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = System.Drawing.SystemColors.GrayText; 
            textBox.Tag = placeholder;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private string ObtenerNombreDeUsuario(string nombreUsuario)
        {
            string connectionString = "Server=localhost;Port=3306;Database=implementacion_framework2;User ID=root;Password=;";

            string nombreUsuarioLogueado = null;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT nombre_usuario FROM usuarios WHERE nombre_usuario = @nombreUsuario";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nombreUsuarioLogueado = reader["nombre_usuario"].ToString();
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error de conexión a la base de datos: " + ex.Message);
                //error de conexión aquí
            }

            return nombreUsuarioLogueado;
        }


        private string ObtenerNombreDeEmpresa(string nombreUsuario)
        {
            string connectionString = "Server=localhost;Port=3306;Database=implementacion_framework2;User ID=root;Password=;";

            string nombreEmpresa = string.Empty;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT nombre_de_empresa FROM usuarios WHERE nombre_usuario = @nombreUsuario";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nombreEmpresa = reader["nombre_de_empresa"].ToString();
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error de conexión a la base de datos: " + ex.Message);
                // error de conexión 
            }

            return nombreEmpresa;
        }

        private void iniciarSesion_Click(object sender, EventArgs e)
        {
            string nombreUsuario = textBox2.Text;
            string clave = textBox3.Text;

            if (!string.IsNullOrWhiteSpace(nombreUsuario) && !string.IsNullOrWhiteSpace(clave) && (nombreUsuario != "Usuario" && clave != "Contraseña"))
            {
                string connectionString = "Server=localhost;Port=3306;Database=implementacion_framework2;User ID=root;Password=;";

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        // Consulta para verificar si el usuario existe
                        string checkUserQuery = "SELECT COUNT(*) FROM usuarios WHERE nombre_usuario = @nombreUsuario";

                        using (MySqlCommand checkUserCommand = new MySqlCommand(checkUserQuery, connection))
                        {
                            checkUserCommand.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                            long existingUserCount = (long)checkUserCommand.ExecuteScalar();

                            if (existingUserCount == 0)
                            {
                                MessageBox.Show("El usuario no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                               
                                // actualizamos intentos_login ya que el usuario no existe
                                string updateLoginAttemptsQuery = "UPDATE usuarios SET intentos_login = intentos_login + 1 WHERE nombre_usuario = @nombreUsuario";

                                using (MySqlCommand updateLoginAttemptsCommand = new MySqlCommand(updateLoginAttemptsQuery, connection))
                                {
                                    updateLoginAttemptsCommand.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                                    updateLoginAttemptsCommand.ExecuteNonQuery();
                                }

                                return;
                            }

                        }

                        // Consulta para obtener el campo "habilitado" de la base de datos
                        string getHabilitadoQuery = "SELECT habilitado FROM usuarios WHERE nombre_usuario = @nombreUsuario";

                        using (MySqlCommand getHabilitadoCommand = new MySqlCommand(getHabilitadoQuery, connection))
                        {
                            getHabilitadoCommand.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                            int habilitado = (int)getHabilitadoCommand.ExecuteScalar();

                            if (habilitado == 0)
                            {
                                MessageBox.Show("Cuenta deshabilitada. Contacta al administrador.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return; // Salir de la función y bloquear el inicio de sesión
                            }
                        }

                        // Consulta para obtener la contraseña cifrada almacenada en la base de datos
                        string getPasswordQuery = "SELECT clave FROM usuarios WHERE nombre_usuario = @nombreUsuario";
                        using (MySqlCommand getPasswordCommand = new MySqlCommand(getPasswordQuery, connection))
                        {
                            getPasswordCommand.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                            string storedHashedPassword = getPasswordCommand.ExecuteScalar() as string;

                            if (BCrypt.Net.BCrypt.Verify(clave, storedHashedPassword))
                            {
                                // Consultar el tipo de usuario
                                string getUserTypeQuery = "SELECT tipo_de_usuario FROM usuarios WHERE nombre_usuario = @nombreUsuario";
                                using (MySqlCommand getUserTypeCommand = new MySqlCommand(getUserTypeQuery, connection))
                                {
                                    getUserTypeCommand.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                                    string userType = (string)getUserTypeCommand.ExecuteScalar();


                                    // Obtener el nombre de la empresa desde la base de datos
                                    string nombreEmpresaLogueado = ObtenerNombreDeEmpresa(nombreUsuario);
                                    // recupera el nombre de usuario desde la base de datos
                                    string nombreUsuarioLogueado = ObtenerNombreDeUsuario(nombreUsuario);

                                    
                                    FormPrincipal formPrincipal = new FormPrincipal(nombreUsuarioLogueado, nombreEmpresaLogueado);

                                    formPrincipal.Show();

                                    // dependiendo del tipo de usuario, habilita o deshabilita el botón gestionUsuarios
                                    if (userType == "admin")
                                    {
                                        formPrincipal.gestionUsuarioButton.Visible = true;
                                    }
                                    else
                                    {
                                        formPrincipal.gestionUsuarioButton.Visible = false;
                                    }

                                    // Oculta el Form1 después de iniciar sesión correctamente
                                    this.Hide();
                                }
                            }

                            else
                            {
                               
                                intentosFallidos++; // Incrementar los intentos fallidos

                                if (intentosFallidos < intentosMaximos - 1)
                                {
                                    MessageBox.Show($"Contraseña incorrecta. Te quedan {intentosMaximos - intentosFallidos} intentos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else if (intentosFallidos == intentosMaximos - 1)
                                {
                                    MessageBox.Show("Contraseña incorrecta. Te queda 1 intento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else if (intentosFallidos >= intentosMaximos)
                                {
                                    MessageBox.Show("Cuenta bloqueada. Contacta al administrador.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    // actualizamos el campo "habilitado" en la base de datos a 0
                                    string updateHabilitadoQuery = "UPDATE usuarios SET habilitado = 0 WHERE nombre_usuario = @nombreUsuario";
                                    using (MySqlCommand updateHabilitadoCommand = new MySqlCommand(updateHabilitadoQuery, connection))
                                    {
                                        updateHabilitadoCommand.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                                        updateHabilitadoCommand.ExecuteNonQuery();
                                    }
                                }

                                string updateLoginAttemptsQuery = "UPDATE usuarios SET intentos_login = intentos_login + 1 WHERE nombre_usuario = @nombreUsuario";
                                using (MySqlCommand updateLoginAttemptsCommand = new MySqlCommand(updateLoginAttemptsQuery, connection))
                                {
                                    updateLoginAttemptsCommand.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                                    updateLoginAttemptsCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error de conexión a la base de datos: " + ex.Message);
                    MessageBox.Show("Error de conexión a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos en el Form1.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        } 
    }
}