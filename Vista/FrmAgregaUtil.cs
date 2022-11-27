using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpUtiles;

namespace Vista
{
    public partial class FrmAgregaUtil : Form
    {
        List<Util> listaUtiles = new List<Util>();
        public FrmAgregaUtil(List<Util> listaUtiles)
        {
            InitializeComponent();
            this.listaUtiles = listaUtiles; 
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Validaciones.ValidarDatosIngresados(txt_Precio.Text,txt_Marca.Text);
                if (cmb_TipoDeUtil.Text == "Lapiz")
                {
                    Lapiz lapiz = new Lapiz();
                    lapiz = lapiz.CargaDatosLapiz(txt_Precio.Text, txt_Marca.Text, cmb_Color.Text, cmb_Tipo.Text);
                    UtilDAO.GuardaLapiz(lapiz);
                }
                else if (cmb_TipoDeUtil.Text == "Goma")
                {
                    Goma goma = new Goma();
                    goma = goma.CargaDatosGoma(txt_Precio.Text, txt_Marca.Text, cmb_Tipo.Text, cmb_Tamanio.Text);
                    UtilDAO.GuardaGoma(goma);
                }
                else
                {
                    Sacapunta sacapunta = new Sacapunta();
                    sacapunta = sacapunta.CargaDatosSacapuntas(txt_Precio.Text, txt_Marca.Text, cmb_Tipo.Text);
                    UtilDAO.GuardaSacapuntas(sacapunta);
                }
                UtilDAO.GuardaDatos(listaUtiles);
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
