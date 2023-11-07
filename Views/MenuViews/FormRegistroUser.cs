using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using ImplementacionFramework1.Views.MenuViews;

namespace ImplementacionFramework1
{
    public partial class FormRegistroUser : Form
    {


        public FormRegistroUser()
        {
            InitializeComponent();
            // Asigna los manejadores de eventos a los cuadros de texto
            crearUsuarioText.GotFocus += TextBox_GotFocus;
            crearUsuarioText.LostFocus += TextBox_LostFocus;
            crearClaveText.GotFocus += TextBox_GotFocus;
            crearClaveText.LostFocus += TextBox_LostFocus;
            crearNombreEmpresaText.GotFocus += TextBox_GotFocus;
            crearNombreEmpresaText.LostFocus += TextBox_LostFocus;

            SetPlaceholder(crearUsuarioText, "Nombre de usuario");
            SetPlaceholder(crearClaveText, "Contraseña");
            SetPlaceholder(crearNombreEmpresaText, "Nombre de la empresa");

            // Rellenar el ComboBox con opciones de tipo de usuario desde la base de datos
            FillTipoUsuarioComboBox();

        }

        public FormPrincipal MainForm { get; set; }
        // completa el combobox
        private void FillTipoUsuarioComboBox()
        {
            // Conexión a la base de datos
            string connectionString = "Server=localhost;Port=3306;Database=implementacion_framework2;User ID=root;Password=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Consulta para obtener tipos de usuario desde la base de datos
                string getTipoUsuarioQuery = "SELECT DISTINCT tipo_de_usuario FROM usuarios";

                using (MySqlCommand getTipoUsuarioCommand = new MySqlCommand(getTipoUsuarioQuery, connection))
                {
                    using (MySqlDataReader reader = getTipoUsuarioCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tipoUsuario = reader.GetString("tipo_de_usuario");
                            tipoUsuarioCombo.Items.Add(tipoUsuario);
                        }
                    }
                }
            }
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (IsPlaceholder(textBox))
            {
                ClearPlaceholder(textBox);
            }
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                SetPlaceholder(textBox, textBox == crearUsuarioText ? "Nombre de usuario" : "Contraseña");
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



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Asegúrate de que MainForm no sea null antes de intentar utilizarlo
            if (MainForm != null)
            {
                // Simplemente muestra la instancia de FormPrincipal que ya existe.
                MainForm.Show();
            }
            else
            {
                // Si por alguna razón MainForm es null, maneja ese caso aquí
                // (Por ejemplo, mostrando un mensaje de error o creando una nueva instancia).
                MessageBox.Show("nullo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            // Cierra el formulario actual (FormRegistroUser)
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreUsuario = crearUsuarioText.Text;
            string clave = crearClaveText.Text;
            string nombreEmpresa = crearNombreEmpresaText.Text; // Agregar el campo "nombre_empresa"
            string tipoDeUsuario = tipoUsuarioCombo.Text;



            if (nombreUsuario != "Nombre de usuario" && clave != "Contraseña" && nombreEmpresa != "Nombre de la empresa")
            {
                string connectionString = "Server=localhost;Port=3306;Database=implementacion_framework2;User ID=root;Password=;";

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string checkUserQuery = "SELECT COUNT(*) FROM usuarios WHERE nombre_usuario = @nombreUsuario";

                        using (MySqlCommand checkUserCommand = new MySqlCommand(checkUserQuery, connection))
                        {
                            checkUserCommand.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                            long existingUserCount = (long)checkUserCommand.ExecuteScalar();

                            if (existingUserCount > 0)
                            {
                                MessageBox.Show("El nombre de usuario ya está en uso. Elija otro nombre.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
                        // Genera un hash seguro de la contraseña
                        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(clave, BCrypt.Net.BCrypt.GenerateSalt());
                       

                       
                        string insertQuery = "INSERT INTO usuarios (nombre_usuario, clave, nombre_de_empresa, tipo_de_usuario, habilitado, intentos_login) VALUES (@nombreUsuario, @clave, @nombreEmpresa, 'normal', 1, 0)";

                        using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                            insertCommand.Parameters.AddWithValue("@clave", hashedPassword);
                            insertCommand.Parameters.AddWithValue("@nombreEmpresa", nombreEmpresa); // Agregar "nombre_empresa"

                            int rowsAffected = insertCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Registro exitoso en la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //// Volver al formulario principal.
                                //Form1 form1 = new Form1();
                                //form1.Show();
                                //this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo insertar el registro en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Por favor, complete todos los campos formuser.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void crearUsuarioText_TextChanged(object sender, EventArgs e)
        {

        }

        private void crearClaveText_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void crearNombreEmpresa_TextChanged(object sender, EventArgs e)
        {

        }

        private void tipoUsuarioCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cerrarSesionBtn_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual (FormPrincipal)
            this.Close();

            // Abre el formulario de inicio de sesión (Form1)
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}