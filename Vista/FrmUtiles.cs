using Entidades;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using TpUtiles;

namespace Vista
{
    public partial class FrmUtiles : Form
    {
        private Cartuchera<Util> cartuchera;
        private Lapiz lapiz;
        private Goma goma;
        private Sacapunta sacapunta;
        private SaveFileDialog saveFileDialog;
        private string path;
        private string carpetaDefalut;
        public FrmUtiles()
        {
            InitializeComponent();
            cartuchera = new Cartuchera<Util>();
            lapiz = new Lapiz();
            goma = new Goma();
            sacapunta = new Sacapunta();
            saveFileDialog = new SaveFileDialog();
            carpetaDefalut = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.InitialDirectory = carpetaDefalut;//mmm
            saveFileDialog.Filter = "Archivo de texto|*.txt";
            saveFileDialog.Title = "Save a Text File";
            path = string.Empty;
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
          
            try
            {
                Validaciones.ValidarDatosIngresados(txt_Precio.Text, txt_Marca.Text);
                if (cmb_TipoDeUtil.Text == "Lapiz")
                {
                    lapiz = lapiz.CargaDatosLapiz(txt_Precio.Text, txt_Marca.Text, cmb_Color.Text, cmb_Tipo.Text);
                    if (cartuchera + lapiz)
                    {
                        MessageBox.Show($"Se agrego Lapiz : {lapiz}");
                    }
                }
                else if (cmb_TipoDeUtil.Text == "Goma")
                {
                    goma = goma.CargaDatosGoma(txt_Precio.Text, txt_Marca.Text, cmb_Tipo.Text, cmb_Tamanio.Text);
                    if (cartuchera + goma)
                    {
                        MessageBox.Show($"Se agrego Goma : {goma}");
                    }
                }
                else
                {
                    sacapunta = sacapunta.CargaDatosSacapuntas(txt_Precio.Text, txt_Marca.Text, cmb_Tipo.Text);
                    if(cartuchera + sacapunta)
                    {
                        MessageBox.Show($"Se agrego sacapuntas : {sacapunta}");
                    }
                }
                if(cartuchera.PrecioTotal >500)
                {
                    GuardarTicket();
                    cartuchera.EventoPrecio += NotificacionPrecio;
                }
                //Evento mas de $500
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

        static void NotificacionPrecio(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        private void LeerTicket()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                try
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        //obtengo el nombre del archivo
                        this.path = ofd.FileName;

                        using (StreamReader streamReader = new StreamReader(this.path))
                        {
                            this.path = streamReader.ReadToEnd();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MostrarVentanaDeError(ex);
                }
            }
        }

        private void GuardarTicket()
        {
            try
            {
                saveFileDialog.FileName = "tickets.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(this.path))
                    {
                        
                        this.path = saveFileDialog.FileName;
                        using (StreamWriter streamWriter = new StreamWriter(this.path, true))
                        {
                            streamWriter.WriteLine(cartuchera.MuestraCartuchera(cartuchera.ListaUtiles));
                        }
                    }
                    else  
                    {
                        using (StreamWriter streamWriter = new StreamWriter(this.path))
                        {
                            streamWriter.WriteLine(cartuchera.MuestraCartuchera(cartuchera.ListaUtiles));
                        }
                        MessageBox.Show("Se agrego informacion al archivo tickets");
                    }
                }

            }
            catch (Exception ex)
            {
                MostrarVentanaDeError(ex);
            }
        }

        private void MostrarVentanaDeError(Exception ex)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Error: {ex.Message}");
            stringBuilder.AppendLine("Detalle:");
            stringBuilder.AppendLine(ex.StackTrace);

            MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_VerCartuchera_Click(object sender, EventArgs e)
        {
            rtx_Cartuchera.Text= string.Empty;
            rtx_Cartuchera.Text = cartuchera.MuestraCartuchera(cartuchera.ListaUtiles);
        }
    }
}
