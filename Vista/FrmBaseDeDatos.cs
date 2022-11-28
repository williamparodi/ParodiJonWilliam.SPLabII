using Entidades;
using System;
using System.Windows.Forms;
using TpUtiles;

namespace Vista
{
    public partial class FrmBaseDeDatos : Form
    {
        private int fila;
        static Cartuchera<Util> cartuchera = new Cartuchera<Util>();

        public FrmBaseDeDatos()
        {
            InitializeComponent();
            cartuchera = new Cartuchera<Util>();
        }

        private void FrmBaseDeDatos_Load(object sender, EventArgs e)
        {
            dtgv_BaseDeDatos.DataSource = null;
            cmb_TipoDeUtil.SelectedIndex = 0;
        }

        private void btn_LeerBase_Click(object sender, EventArgs e)
        {
            try
            {
                RefrescaLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_AgregarUtil_Click(object sender, EventArgs e)
        {
            FrmAgregaUtil frmAgregaUtil = new FrmAgregaUtil();

            if (frmAgregaUtil.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Util agregado a la base", "Se agrego Util", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefrescaLista();
            }

        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgv_BaseDeDatos.SelectedRows.Count > 0)
                {
                    Util util = (Util)dtgv_BaseDeDatos.CurrentRow.DataBoundItem;
                    UtilDAO.BorraDatos(util);

                    MessageBox.Show("Se elimino el util seleccionado", "Borrado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescaLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgv_BaseDeDatos.SelectedRows.Count > 0)
                {
                    Util util = (Util)dtgv_BaseDeDatos.CurrentRow.DataBoundItem;
                    //Metodo EDitar

                    MessageBox.Show("Se edito el util seleccionado", "Edicion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescaLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefrescaLista()
        {
            dtgv_BaseDeDatos.DataSource = UtilDAO.LeerDatosLapiz();
            dtgv_BaseDeDatos.Refresh();
            dtgv_BaseDeDatos.Update();
        }

        //No se si borrarla
        public bool HardcodeaListaDeVarios()
        {
            bool retorno = false;
            Lapiz lapiz = new Lapiz(56, "El mejor", EColor.Rojo, ETipoLapiz.Normal);
            Sacapunta sacapunta = new Sacapunta(60, "Faber Castell", ETipoSacapuntas.Electrico);
            Goma goma = new Goma(60, "Gomiya", ETipoGoma.ParaLapiz, ETamanio.Numero1);

            if (cartuchera + sacapunta && cartuchera + goma && cartuchera + lapiz)
            {
                retorno = true;
            }

            return retorno;
        }
    }

}
