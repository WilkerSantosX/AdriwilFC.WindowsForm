using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdriwilFC
{
    public partial class formHome : Form
    {
        public formHome()
        {
            InitializeComponent();
        }

        private void btnEquipe_Click(object sender, EventArgs e)
        {
            string Tecnico = txtNome.Text;
            string Time = txtTime.Text;

            formEquipe escalarTime = new formEquipe(Tecnico, Time);
            escalarTime.Show();
            Close();
        }

        private void formHome_Load(object sender, EventArgs e)
        {

        }
    }
}
