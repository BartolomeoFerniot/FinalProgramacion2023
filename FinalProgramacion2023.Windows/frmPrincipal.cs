using FinalProgramacion2023.Datos;
using FinalProgramacion2023.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = FinalProgramacion2023.Entidades.Color;

namespace FinalProgramacion2023.Windows
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            List<Cuadrilatero> listaa = new List<Cuadrilatero>();
            listaa = repo.GetLista();
            foreach (var cuadrilatero in listaa)
            {
                DataGridViewRow r = ConstruirFila();
                SetearDatos(r, cuadrilatero);
                AgregarFila(r);
            }
            txtCantidad.Text = repo.GetCantidad().ToString();
        }
        Repositorio repo = new Repositorio();

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmCuadrilatero frm = new frmCuadrilatero();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            Cuadrilatero c = frm.GetCuadrilatero();
            DataGridViewRow r = ConstruirFila();
            SetearDatos(r, c);
            AgregarFila(r);
            repo.Agregar(c);
            txtCantidad.Text = repo.GetCantidad().ToString();
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearDatos(DataGridViewRow r, Cuadrilatero cuadrilatero)
        {
            r.Cells[colLado1.Index].Value = cuadrilatero.ladoA;
            r.Cells[colLado2.Index].Value = cuadrilatero.ladoB;
            r.Cells[colRelleno.Index].Value = cuadrilatero.colorRelleno;
            r.Cells[colBorde.Index].Value = cuadrilatero.formatoBorde;
            r.Cells[colPerimetro.Index].Value = cuadrilatero.GetPerimetro();
            r.Cells[colArea.Index].Value = cuadrilatero.GetArea();
            r.Cells[colTipo.Index].Value = cuadrilatero.TipoDeCuadrilatero();

            r.Tag = cuadrilatero;
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Cuadrilatero cuad = r.Tag as Cuadrilatero;
            repo.Borrar(cuad);
            txtCantidad.Text = repo.GetCantidad().ToString();
            dgvDatos.Rows.Remove(r);
            MessageBox.Show("Registro eliminado");
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dgvDatos.SelectedRows[0];
            Cuadrilatero cuad = r.Tag as Cuadrilatero;
            frmCuadrilatero frm = new frmCuadrilatero() { Text = "Editar Cuadrilatero" };
            frm.SetCuadrilatero(cuad);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            cuad = frm.GetCuadrilatero();
            SetearDatos(r, cuad);
            repo.Editar(cuad);
            MessageBox.Show("Cuadrilatero modificado");
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            ManejadorArchivoSecuencial.GuardarEnArchivoSecuencial(repo.GetLista());
            Application.Exit();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
