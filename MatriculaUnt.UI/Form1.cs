using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatriculaUnt.BL;
using MatriculaUnt.Entities;

namespace MatriculaUnt.UI
{
    public partial class Form1 : Form
    {
        string temp = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var AlumnosBL = new AlumnosBL();
            var result = await AlumnosBL.ObtenerAlumnos();
            // Llenar la Grilla
            dataGridView1.DataSource = result;
            ConfiguracionGrilla();
        }

        public void ConfiguracionGrilla()
        {
            dataGridView1.Columns["i_IdAlumnos"].HeaderText = "ID";
            dataGridView1.Columns["v_NombresApellidos"].HeaderText = "Nombres Apellidos";
            dataGridView1.Columns["v_Dni"].HeaderText = "DNI";
            dataGridView1.Columns["v_Carrera"].HeaderText = "Carrera";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            PasarDataTable(dt);
            var row = dt.NewRow();
            row["i_IdAlumnos"] = 0;
            row["Estado"] = EstadoFila.conCambios;

            dt.Rows.Add(row);
            var dt1 = PasarAlumnosDto(dt);
            dataGridView1.DataSource = dt1;
        }

        public void PasarDataTable(DataTable dt)
        {
            dt.Columns.Add("i_IdAlumnos", typeof(System.Int32));
            dt.Columns.Add("v_NombresApellidos", typeof(System.String));
            dt.Columns.Add("v_Dni", typeof(System.String));
            dt.Columns.Add("v_Carrera", typeof(System.String));
            dt.Columns.Add("Estado", typeof(EstadoFila));

            foreach (DataGridViewRow rowGrid in dataGridView1.Rows)
            {
                var row = dt.NewRow();
                row["i_IdAlumnos"] = Convert.ToInt32(rowGrid.Cells[0].Value);
                row["v_NombresApellidos"] = Convert.ToString(rowGrid.Cells[1].Value);
                row["v_Dni"] = Convert.ToString(rowGrid.Cells[2].Value);
                row["v_Carrera"] = Convert.ToString(rowGrid.Cells[3].Value);
                row["Estado"] = (EstadoFila)rowGrid.Cells[4].Value;
                dt.Rows.Add(row);
            }
        }

        public List<AlumnoDto> PasarAlumnosDto(DataTable dt)
        {
            var listAlumnosDto = (from DataRow dr in dt.Rows
                                  select new AlumnoDto()
                                  {
                                      i_IdAlumnos = Convert.ToInt32(dr["i_IdAlumnos"]),
                                      v_NombresApellidos = dr["v_NombresApellidos"].ToString(),
                                      v_Dni = dr["v_Dni"].ToString(),
                                      v_Carrera = dr["v_Carrera"].ToString(),
                                      Estado = (EstadoFila)Enum.Parse(typeof(EstadoFila), dr["Estado"].ToString(), true)
                                  }).ToList();
            return listAlumnosDto;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var data = dataGridView1.DataSource as List<AlumnoDto>;
            data = data.Where(w => w.Estado == EstadoFila.conCambios).ToList();

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            temp = dataGridView1.CurrentCell.Value.ToString();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = dataGridView1.CurrentCell.Value.ToString();
            if (cellValue != temp)
            {
                dataGridView1.Rows[e.RowIndex].Cells["Estado"].Value = EstadoFila.conCambios;
            }
        }
    }
}
