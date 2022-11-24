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
        private Cartuchera<Util> cartuchera;
        private List<Util> listaUtilesASubir;
        private List<Util> listaUtiles;
        private Lapiz lapiz = new Lapiz();
        private Goma goma = new Goma();
        private Sacapunta sacapunta = new Sacapunta();
        public FrmBaseDeDatos()
        {
            InitializeComponent();
            cartuchera = new Cartuchera<Util>();
            listaUtilesASubir = new List<Util>();
            listaUtiles = new List<Util>();
        }

        private void FrmBaseDeDatos_Load(object sender, EventArgs e)
        {
            HardcodeaListaDeVarios();
            dtgv_BaseDeDatos.DataSource = null;
            dtgv_BaseDeDatos.DataSource = cartuchera.ListaUtiles;
        }

        private void btn_LeerBase_Click(object sender, EventArgs e)
        {
            try
            {
                cartuchera.ListaUtiles = UtilDAO.LeerDatos();
                dtgv_BaseDeDatos.DataSource = cartuchera.ListaUtiles;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btn_GuardaEnBase_Click(object sender, EventArgs e)
        {
            try
            {
                UtilDAO.GuardaDatos(listaUtilesASubir);      
            }
            catch(Exception ex ) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgv_BaseDeDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            
            if(fila != -1)
            {
                if(cartuchera.ListaUtiles is not null)
                {
                    if (cartuchera.ListaUtiles[fila] is Lapiz)
                    {
                        listaUtilesASubir.Add(cartuchera.ListaUtiles[fila]);   
                    }
                }
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
    }   

}
