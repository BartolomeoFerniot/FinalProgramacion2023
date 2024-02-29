using FinalProgramacion2023.Datos;
using FinalProgramacion2023.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = FinalProgramacion2023.Entidades.Color;

namespace FinalProgramacion2023.Windows
{
    public partial class frmCuadrilatero : Form
    {
        public frmCuadrilatero()
        {
            InitializeComponent();
        }
        private Cuadrilatero cuadrilatero;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatosComboRelleno();
        }

        private void CargarDatosComboRelleno()
        {
            cboRelleno.DataSource = Enum.GetValues(typeof(Color));
            cboRelleno.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (cuadrilatero == null)
                {
                    cuadrilatero = new Cuadrilatero();
                }

                {
                    cuadrilatero.ladoA = double.Parse((string)txtLadoA.Text);
                    cuadrilatero.ladoB = double.Parse((string)txtLadoB.Text);
                    cuadrilatero.colorRelleno = cboRelleno.Text;
                    if (rbtLineal.Checked)
                    {
                        cuadrilatero.formatoBorde = "Lineal";
                    }
                    if (rbtRayas.Checked)
                    {
                        cuadrilatero.formatoBorde = "Rayas";
                    }
                    if (rbtPuntos.Checked)
                    {
                        cuadrilatero.formatoBorde = "Puntos";
                    }

                }
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Datos mal ingresados");
            }
        }

        double nroo1;
        double nroo2;
        private bool ValidarDatos()
        {
            bool valido = true;

            if (string.IsNullOrEmpty(txtLadoA.Text))
            {
                valido = false;
            }
            if (string.IsNullOrEmpty(txtLadoB.Text))
            {
                valido = false;
            }
            if (!double.TryParse(txtLadoA.Text, out double nroo1))
            {
                valido = false;
               
            }
            else if (nroo1 <= 0)
            {
                valido = false;
            }
            if (!double.TryParse(txtLadoB.Text, out double nroo2))
            {
                valido = false;
                
            }
            else if (nroo2 <= 0)
            {
                valido = false;
            }


            return valido;
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Cuadrilatero GetCuadrilatero()
        {
            return cuadrilatero;
        }

        public void SetCuadrilatero(Cuadrilatero cuad)
        {
            cuadrilatero = cuad;
        }

        private void frmCuadrilatero_Load(object sender, EventArgs e)
        {

        }
    }
}
