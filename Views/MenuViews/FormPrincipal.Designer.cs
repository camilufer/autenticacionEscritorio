namespace ImplementacionFramework1.Views.MenuViews
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuCajaButton = new System.Windows.Forms.Button();
            this.inventarioButton = new System.Windows.Forms.Button();
            this.menuVentasButton = new System.Windows.Forms.Button();
            this.gestionUsuarioButton = new System.Windows.Forms.Button();
            this.labelUsuarioLogueado = new System.Windows.Forms.Label();
            this.cerrarSesionBtn = new System.Windows.Forms.Button();
            this.labelNombreEmpresa = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelNombreEmpresa);
            this.panel1.Controls.Add(this.cerrarSesionBtn);
            this.panel1.Controls.Add(this.labelUsuarioLogueado);
            this.panel1.Controls.Add(this.gestionUsuarioButton);
            this.panel1.Controls.Add(this.menuVentasButton);
            this.panel1.Controls.Add(this.inventarioButton);
            this.panel1.Controls.Add(this.menuCajaButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 347);
            this.panel1.TabIndex = 0;
            // 
            // menuCajaButton
            // 
            this.menuCajaButton.Location = new System.Drawing.Point(256, 125);
            this.menuCajaButton.Name = "menuCajaButton";
            this.menuCajaButton.Size = new System.Drawing.Size(124, 82);
            this.menuCajaButton.TabIndex = 1;
            this.menuCajaButton.Text = "Menu Caja";
            this.menuCajaButton.UseVisualStyleBackColor = true;
            this.menuCajaButton.Click += new System.EventHandler(this.menuCajaButton_Click);
            // 
            // inventarioButton
            // 
            this.inventarioButton.Location = new System.Drawing.Point(85, 225);
            this.inventarioButton.Name = "inventarioButton";
            this.inventarioButton.Size = new System.Drawing.Size(124, 82);
            this.inventarioButton.TabIndex = 2;
            this.inventarioButton.Text = "Inventario";
            this.inventarioButton.UseVisualStyleBackColor = true;
            this.inventarioButton.Click += new System.EventHandler(this.inventarioButton_Click);
            // 
            // menuVentasButton
            // 
            this.menuVentasButton.Location = new System.Drawing.Point(256, 225);
            this.menuVentasButton.Name = "menuVentasButton";
            this.menuVentasButton.Size = new System.Drawing.Size(124, 82);
            this.menuVentasButton.TabIndex = 3;
            this.menuVentasButton.Text = "Menu Ventas";
            this.menuVentasButton.UseVisualStyleBackColor = true;
            this.menuVentasButton.Click += new System.EventHandler(this.menuVentasButton_Click);
            // 
            // gestionUsuarioButton
            // 
            this.gestionUsuarioButton.Location = new System.Drawing.Point(85, 125);
            this.gestionUsuarioButton.Name = "gestionUsuarioButton";
            this.gestionUsuarioButton.Size = new System.Drawing.Size(124, 82);
            this.gestionUsuarioButton.TabIndex = 4;
            this.gestionUsuarioButton.Text = "Gestion Usuario";
            this.gestionUsuarioButton.UseVisualStyleBackColor = true;
            this.gestionUsuarioButton.Click += new System.EventHandler(this.gestionUsuarioButton_Click);
            // 
            // labelUsuarioLogueado
            // 
            this.labelUsuarioLogueado.AutoSize = true;
            this.labelUsuarioLogueado.Location = new System.Drawing.Point(21, 19);
            this.labelUsuarioLogueado.Name = "labelUsuarioLogueado";
            this.labelUsuarioLogueado.Size = new System.Drawing.Size(35, 13);
            this.labelUsuarioLogueado.TabIndex = 7;
            this.labelUsuarioLogueado.Text = "label2";
            this.labelUsuarioLogueado.Click += new System.EventHandler(this.labelUsuarioLogueado_Click);
            // 
            // cerrarSesionBtn
            // 
            this.cerrarSesionBtn.Location = new System.Drawing.Point(406, 19);
            this.cerrarSesionBtn.Name = "cerrarSesionBtn";
            this.cerrarSesionBtn.Size = new System.Drawing.Size(53, 38);
            this.cerrarSesionBtn.TabIndex = 8;
            this.cerrarSesionBtn.Text = "cerrar sesion";
            this.cerrarSesionBtn.UseVisualStyleBackColor = true;
            this.cerrarSesionBtn.Click += new System.EventHandler(this.cerrarSesionBtn_Click);
            // 
            // labelNombreEmpresa
            // 
            this.labelNombreEmpresa.AutoSize = true;
            this.labelNombreEmpresa.Location = new System.Drawing.Point(21, 52);
            this.labelNombreEmpresa.Name = "labelNombreEmpresa";
            this.labelNombreEmpresa.Size = new System.Drawing.Size(35, 13);
            this.labelNombreEmpresa.TabIndex = 9;
            this.labelNombreEmpresa.Text = "label1";
            this.labelNombreEmpresa.Click += new System.EventHandler(this.labelNombreEmpresa_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 362);
            this.Controls.Add(this.panel1);
            this.Name = "FormPrincipal";
            this.Text = "FormPrincipal";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button menuVentasButton;
        private System.Windows.Forms.Button inventarioButton;
        private System.Windows.Forms.Button menuCajaButton;
        public System.Windows.Forms.Button gestionUsuariosButton;
        public System.Windows.Forms.Button gestionUsuarioButton;
        private System.Windows.Forms.Label labelUsuarioLogueado;
        private System.Windows.Forms.Button cerrarSesionBtn;
        private System.Windows.Forms.Label labelNombreEmpresa;
    }
}