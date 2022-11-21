using Entidades;
using System;
using System.Windows.Forms;
using TpUtiles;

namespace Vista
{
    public partial class FrmUtiles : Form
    {
        public Cartuchera<Util> cartuchera;
        public Lapiz lapiz;
        public Goma goma;
        public Sacapunta sacapunta;
        public FrmUtiles()
        {
            InitializeComponent();
            cartuchera = new Cartuchera<Util>();
            lapiz = new Lapiz();
            goma = new Goma();
            sacapunta = new Sacapunta();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                Validaciones.ValidarDatosIngresados(txt_Precio.Text, txt_Marca.Text);
                if (cmb_TipoDeUtil.Text == "Lapiz")
                {
                    lapiz = lapiz.CargaDatosLapiz(txt_Precio.Text, txt_Marca.Text, cmb_Color.Text, cmb_TipoDeUtil.Text);
                    if (cartuchera + lapiz)
                    {
                        MessageBox.Show($"Se agrego Lapiz : {lapiz}");
                    }
                }
                else if (cmb_TipoDeUtil.Text == "Goma")
                {
                    if (cartuchera + goma)
                    {

                    }
                }
            }
            catch (CartucheraLLenaException ex)
            {
                MessageBox.Show(ex.Message, "Cartuchera LLena", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    

        private void cmb_TipoDeUtil_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmb_TipoDeUtil.SelectedIndex;
            switch (index)
            {
                
                case 0: 
                    cmb_Tipo.Items.Add("Normal");
                    cmb_Tipo.Items.Add("Grafito");
                    break;
                case 1:
                    cmb_Tipo.Items.Add("ParaTinta");
                    cmb_Tipo.Items.Add("ParaLapiz");
                    break;
                case 2:
                    cmb_Tipo.Items.Add("Portatil");
                    cmb_Tipo.Items.Add("Electrico");
                    break;
                default:
                    break;
            }
        }
    }
}
