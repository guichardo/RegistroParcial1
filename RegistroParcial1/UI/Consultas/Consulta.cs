using RegistroParcial1.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroParcial1.UI.Consultas
{
    public partial class Consulta : Form
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private bool SetError(int error)
        {
            bool paso = false;
            int ejm = 0;

            if (error == 1 && int.TryParse(CriteriotextBox.Text, out ejm) == false)
            {
                CriterioerrorProvider.SetError(CriteriotextBox, "Debe Ingresar un Numero");
                paso = true;
            }
            if (error == 2 && int.TryParse(CriteriotextBox.Text, out ejm) == true)
            {
                CriterioerrorProvider.SetError(CriteriotextBox, "Debe Ingresar un caracter");
                paso = true;
            }
            return paso;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
      
            System.Linq.Expressions.Expression<Func<Grupos, bool>> filtro = x => true;

            int id, cant, grup, inte;
            switch (filtrarcomboBox.SelectedIndex)
            {
                case 0://ID
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.GrupoId == id && 
                        (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);

                    break;
                case 1:// Descripcion
                    filtro = x => x.Descripcion.Contains(CriteriotextBox.Text) &&
                        (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 2:// Cantidad
                    cant = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.Cantidad == cant &&
                        (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 3://Grupos
                    grup = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.Grupo == grup &&
                        (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 4:// Integrantes
                    inte = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.Integrantes == inte &&
                        (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
            }


            ConsultadataGridView.DataSource = BLL.GruposBLL.GetList(filtro);
        }
    }
}
