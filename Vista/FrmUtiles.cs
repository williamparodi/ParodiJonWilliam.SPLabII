using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpUtiles;

namespace Vista
{
    public partial class FrmUtiles : Form 
    {
        public Cartuchera<Util> cartuchera;
        public Lapiz lapiz1 = new Lapiz(656,"Faber Castell",EColor.Rojo,ETipoLapiz.Grafito);
        public FrmUtiles()
        {
            InitializeComponent();
            cartuchera = new Cartuchera<Util>();
            cartuchera.ListaUtiles.Add(lapiz1);
            this.dtgv_Cartuchera.DataSource = null;
            this.dtgv_Cartuchera.DataSource = cartuchera.ListaUtiles;
        }

        private void dtgv_Cartuchera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                   
        }
    }
}
