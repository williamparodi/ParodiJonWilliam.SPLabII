using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btn_Utiles_Click(object sender, EventArgs e)
        {
            FrmUtiles frmUtiles = new FrmUtiles();
            frmUtiles.ShowDialog();
            this.Close();
        }

        private void btn_SerealizaDeserealiza_Click(object sender, EventArgs e)
        {
            FrmSerealizaDeserealiza frmSerealizaDeserealiza = new FrmSerealizaDeserealiza();
            frmSerealizaDeserealiza.ShowDialog();
            this.Close();
        }
    }
}
