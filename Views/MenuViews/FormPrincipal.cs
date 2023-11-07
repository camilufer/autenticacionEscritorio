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

namespace ImplementacionFramework1.Views.MenuViews
{
    public partial class FormPrincipal : Form
    {

        private string nombreUsuarioLogueado;
        private string nombreEmpresaLogueado;
        public FormPrincipal(string nombreUsuario, string nombreEmpresa)
        {
            InitializeComponent();
            nombreUsuarioLogueado = nombreUsuario;
            labelUsuarioLogueado.Text = "Bienvenido(a): " + nombreUsuarioLogueado;

            nombreEmpresaLogueado = nombreEmpresa;
            labelNombreEmpresa.Text = nombreEmpresaLogueado;

        }


        public void ShowFormRegistroUser()
        {
            FormRegistroUser registroForm = new FormRegistroUser();
            registroForm.MainForm = this; // Pasas la referencia al FormRegistroUser
            this.Hide();
            registroForm.Show();
        }

        private void menuCajaButton_Click(object sender, EventArgs e)
        {

        }

        private void inventarioButton_Click(object sender, EventArgs e)
        {

        }

        private void menuVentasButton_Click(object sender, EventArgs e)
        {

        }

        private void gestionUsuarioButton_Click(object sender, EventArgs e)
        {


            // Creas una instancia de FormRegistroUser
            FormRegistroUser formRegistroUser = new FormRegistroUser();

            // Antes de mostrarlo, estableces esta instancia de FormPrincipal como la MainForm de FormRegistroUser
            formRegistroUser.MainForm = this;

            // Opcionalmente, ocultas FormPrincipal si deseas que solo se muestre FormRegistroUser
            this.Hide();

            // Finalmente, muestras FormRegistroUser
            formRegistroUser.Show();
        }

        private void labelUsuarioLogueado_Click(object sender, EventArgs e)
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

        private void labelNombreEmpresa_Click(object sender, EventArgs e)
        {

        }
    }
}
