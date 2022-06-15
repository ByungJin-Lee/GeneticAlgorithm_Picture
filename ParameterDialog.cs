using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureGA
{
    public partial class ParameterDialog : Form
    {
        public int Population { get; set; }
        public int GenLimit { get; set; }
        public int ImgScale { get; set; }

        public ParameterDialog(int population, int genLimit, int imgScale)
        {
            InitializeComponent();
            this.Population = population;
            this.GenLimit = genLimit;
            this.ImgScale = imgScale;
        }

        private void ParameterDialog_Load(object sender, EventArgs e)
        {
            nud_population.Value = Population;
            nud_genLimit.Value = GenLimit;
            nud_imgScale.Value = ImgScale;
        }

        private void nud_population_ValueChanged(object sender, EventArgs e)
        {
         
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Population = (int) nud_population.Value;
            GenLimit = (int) nud_genLimit.Value;
            ImgScale = (int) nud_imgScale.Value;
        }
    }
}
