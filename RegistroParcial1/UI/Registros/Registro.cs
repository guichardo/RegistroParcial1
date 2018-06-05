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

namespace RegistroParcial1.UI.Registros
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        public Grupos LlenarClases()
        {
            Grupos grup = new Grupos();

            grup.GrupoId = Convert.ToInt32(IdnumericUpDown.Value);
            grup.Descripcion = DescripciontextBox.Text;
            grup.Fecha = FechadateTimePicker.Value;
            grup.Cantidad = Convert.ToInt32(CantidadnumericUpDown.Value);
            grup.Grupo = Convert.ToInt32(GruposnumericUpDown.Value);
            grup.Integrantes = Convert.ToInt32(IntegrantesnumericUpDown.Value);

            return grup;

        }

        public bool Validar(int validar)
        {

            bool paso = false;

            if(validar == 1 && IdnumericUpDown.Value == 0)
            {
                GeneralerrorProvider.SetError(IdnumericUpDown, "Introduzca un ID");
                paso = true;

            }
            if(validar == 2 && DescripciontextBox.Text == string.Empty)
            {

                GeneralerrorProvider.SetError(DescripciontextBox, "Introduzca el nombre del grupo");
                paso = true;

            }
            if(validar == 1 && CantidadnumericUpDown.Value == 0)
            {

                GeneralerrorProvider.SetError(CantidadnumericUpDown, "Introduzca una cantidad de estudiantes");

            }
            if(validar == 1 && GruposnumericUpDown.Value == 0)
            {

                GeneralerrorProvider.SetError(GruposnumericUpDown, "Introduzca la cantidad de grupos");
            }

            return paso;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if (Validar(2))
            {

                MessageBox.Show("Llenar todos los campos marcados");
                return;
            }

            GeneralerrorProvider.Clear();

            if (IdnumericUpDown.Value == 0)
                paso = BLL.GruposBLL.Guardar(LlenarClases());
            else
                paso = BLL.GruposBLL.Modificar(LlenarClases());

            if (paso)

                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            GeneralerrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Grupos grupos = BLL.GruposBLL.Buscar(id);

            if (grupos != null)
            {

                DescripciontextBox.Text = grupos.Descripcion;
                FechadateTimePicker.Text = grupos.Fecha.ToString();
                CantidadnumericUpDown.Value = grupos.Cantidad;
                GruposnumericUpDown.Value = grupos.Grupo;
                IntegrantesnumericUpDown.Value = grupos.Integrantes = (grupos.Cantidad / grupos.Grupo);


            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            GeneralerrorProvider.Clear();
            DescripciontextBox.Clear();
            IdnumericUpDown.Value = 0;
            CantidadnumericUpDown.Value = 0;
            GruposnumericUpDown.Value = 0;
            IntegrantesnumericUpDown.Value = 0;

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            GeneralerrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.GruposBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void IntegrantesnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            IntegrantesnumericUpDown.Value = (CantidadnumericUpDown.Value / GruposnumericUpDown.Value);
        }

        private void CantidadnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (GruposnumericUpDown.Value != 0)
                {

                    IntegrantesnumericUpDown.Value = (CantidadnumericUpDown.Value / GruposnumericUpDown.Value);

                }
            }
            catch (Exception)
            {
                throw;

            }

        }

        private void GruposnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CantidadnumericUpDown.Value != 0)
                {

                    IntegrantesnumericUpDown.Value = (CantidadnumericUpDown.Value / GruposnumericUpDown.Value);


                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }

    }
