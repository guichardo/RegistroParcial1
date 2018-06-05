using RegistroParcial1.UI.Consultas;
using RegistroParcial1.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroParcial1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.MdiParent = this;
            registro.Show();
        }


        private void gruposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Consulta consulta = new Consulta();
            consulta.MdiParent = this;
            consulta.Show();

        }

        private void GrupostoolStripButton_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.MdiParent = this;
            registro.Show();
        }
    }
}
