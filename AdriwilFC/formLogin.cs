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
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            formHome inicio = new formHome();
            Hide();
            inicio.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegras_Click(object sender, EventArgs e)
        {
            FormRegras regras = new FormRegras();
            regras.Show();
        }
    }
}
