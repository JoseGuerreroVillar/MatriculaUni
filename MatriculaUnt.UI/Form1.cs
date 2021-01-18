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

namespace MatriculaUnt.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnVerAlumnos_Click(object sender, EventArgs e)
        {
            var AlumnosBL = new AlumnosBL();
            var result = await AlumnosBL.ObtenerAlumnos();
            dataGridView1.DataSource = result;
        }
    }
}
