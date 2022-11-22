using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpUtiles;

namespace Vista
{
    public partial class FrmSerealizaDeserealiza : Form
    {
        Cartuchera<Lapiz> cartuchera;
        List<Lapiz> listaLapiz;
        Lapiz lapiz;
        private int fila;
        public FrmSerealizaDeserealiza()
        {
            InitializeComponent();
            cartuchera = new Cartuchera<Lapiz>();
            lapiz= new Lapiz();
            listaLapiz= new List<Lapiz>();
        }

        private void btn_SerealizarXml_Click(object sender, EventArgs e)
        {
            try
            {
                lapiz.Precio = cartuchera.ListaUtiles[fila].Precio;
                lapiz.Color = cartuchera.ListaUtiles[fila].Color;
                lapiz.Marca = cartuchera.ListaUtiles[fila].Marca;
                lapiz.TipoDeLapiz = cartuchera.ListaUtiles[fila].TipoDeLapiz;
                listaLapiz.Add(lapiz);
                lapiz.SerializaLapizXml("lapiz.xml", listaLapiz);
                MessageBox.Show("Lapiz serealizado");
            }
            catch(ExceptionArchivo ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void FrmSerealizaDeserealiza_Load(object sender, EventArgs e)
        {
            cartuchera.ListaUtiles = HardcodeaLista();
            dtgv_ListaLapices.DataSource = null;
            dtgv_ListaLapices.DataSource = cartuchera.ListaUtiles;
        }

        public List<Lapiz> HardcodeaLista()
        {
            Lapiz lapiz1= new Lapiz(10,"Faber Castell",EColor.Azul,ETipoLapiz.Normal);
            Lapiz lapiz2 = new Lapiz(25,"Larro",EColor.Amarillo,ETipoLapiz.Grafito);
            Lapiz lapiz3 = new Lapiz(166,"Jovi",EColor.Rojo,ETipoLapiz.Normal);
            Lapiz lapiz4 = new Lapiz(35,"Filgo",EColor.Negro,ETipoLapiz.Normal);
            Lapiz lapiz5 = new Lapiz(36,"Plexy",EColor.Rojo,ETipoLapiz.Grafito);
            List<Lapiz> auxLista= new List<Lapiz>();
            auxLista.Add(lapiz1);
            auxLista.Add(lapiz2);
            auxLista.Add(lapiz3);
            auxLista.Add(lapiz4);
            auxLista.Add(lapiz5);

            return auxLista;
        }

        private void dtgv_ListaLapices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.fila = e.RowIndex;
            if (fila != -1)
            {
                if (cartuchera.ListaUtiles[fila] is not null)
                {
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(lapiz is not null) 
                {
                    lapiz.Precio = cartuchera.ListaUtiles[fila].Precio;
                    lapiz.Color = cartuchera.ListaUtiles[fila].Color;
                    lapiz.Marca = cartuchera.ListaUtiles[fila].Marca;
                    lapiz.TipoDeLapiz = cartuchera.ListaUtiles[fila].TipoDeLapiz;
                    lapiz.SerializaLapizJson(lapiz);
                    MessageBox.Show("Lapiz serealizado en fromato Json");
                }
            }
            catch (ExceptionArchivo ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
