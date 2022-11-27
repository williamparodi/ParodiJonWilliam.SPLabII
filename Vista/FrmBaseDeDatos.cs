using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using Entidades;
using TpUtiles;

namespace Vista
{
    public partial class FrmBaseDeDatos : Form
    {
        private int fila; 
        static  Cartuchera<Util> cartuchera = new Cartuchera<Util>();
       
        public FrmBaseDeDatos()
        {
            InitializeComponent();
            cartuchera = new Cartuchera<Util>();
        }

        private void FrmBaseDeDatos_Load(object sender, EventArgs e)
        {
            dtgv_BaseDeDatos.DataSource = null;
            cmb_TipoDeUtil.SelectedIndex= 0;
        }

        private void btn_LeerBase_Click(object sender, EventArgs e)
        {
            try
            {
                dtgv_BaseDeDatos.DataSource = UtilDAO.LeerDatosLapiz();
                dtgv_BaseDeDatos.Refresh();
                dtgv_BaseDeDatos.Update();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_GuardaEnBase_Click(object sender, EventArgs e)
        {
            Lapiz lapiz2 = new Lapiz(66,"lalal",EColor.Negro,ETipoLapiz.Grafito);
            try
            {
                switch (cmb_TipoDeUtil.Text)
                {
                    case "Lapiz":
                        UtilDAO.GuardaLapiz(lapiz2);
                        dtgv_BaseDeDatos.Refresh();
                        dtgv_BaseDeDatos.Update();
                        break;
                    case "Goma":
                        //UtilDAO.GuardaGoma();
                        dtgv_BaseDeDatos.Refresh();
                        dtgv_BaseDeDatos.Update();
                        break;
                    case "Sacapunta":
                        //UtilDAO.GuardaSacapuntas();
                        dtgv_BaseDeDatos.Refresh();
                        dtgv_BaseDeDatos.Update();
                        break;
                    default:
                        break;
                }
            }
            catch(Exception ex ) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgv_BaseDeDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.fila = e.RowIndex;

            if(fila != -1)
            {
                
            }
        }

        public bool HardcodeaListaDeVarios()
        {
            bool retorno = false;
            Lapiz lapiz = new Lapiz(56,"El mejor",EColor.Rojo,ETipoLapiz.Normal);
            Sacapunta sacapunta = new Sacapunta(60, "Faber Castell", ETipoSacapuntas.Electrico);
            Goma goma = new Goma(60,"Gomiya",ETipoGoma.ParaLapiz,ETamanio.Numero1);

            if(cartuchera + sacapunta && cartuchera +goma && cartuchera + lapiz)
            {
                retorno = true;
            }

            return retorno;
        }

        private void btn_AgregarUtil_Click(object sender, EventArgs e)
        {
            FrmAgregaUtil frmAgregaUtil = new FrmAgregaUtil(cartuchera.ListaUtiles);
               
            if(frmAgregaUtil.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Util agregado a la base", "Se agrego Util", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }   

}
