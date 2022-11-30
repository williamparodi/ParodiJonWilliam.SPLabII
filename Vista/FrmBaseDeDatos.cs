using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TpUtiles;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace Vista
{
    public partial class FrmBaseDeDatos : Form
    {
        CancellationTokenSource tokenSource;
        CancellationToken token;
        public FrmBaseDeDatos()
        {
            tokenSource= new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            InitializeComponent();
            
        }

        private void FrmBaseDeDatos_Load(object sender, EventArgs e)
        {
            dtgv_BaseDeDatos.DataSource = null;
            cmb_TipoDeUtil.SelectedIndex = 0;
            pic_ImagenBorrar.Image = null;
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
            try
            {
                FrmAgregaUtil frmAgregaUtil = new FrmAgregaUtil();

                if (frmAgregaUtil.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Util agregado a la base", "Se agrego Util", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescaLista();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgv_BaseDeDatos.SelectedRows.Count > 0)
                {
                    Util utilABorrar = (Util)dtgv_BaseDeDatos.CurrentRow.DataBoundItem;
                    UtilDAO.BorraDatos(utilABorrar);
                    MessageBox.Show("Se elimino el util seleccionado", "Borrado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Task.Run(() =>
                    {
                        MuestraImagen();
                    },this.token);
                }
                else
                {
                    throw new Exception("Haga click en un producto para borrar");
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
                   
                    FrmAgregaUtil frmAgregaUtil = new FrmAgregaUtil(util);

                    if (frmAgregaUtil.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Util modificado en la base", "Se modifico Util", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefrescaLista();
                    }

                    RefrescaLista();
                }
                else
                {
                    throw new Exception("Haga click en un producto para editar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefrescaLista()
        {
            LeeDatos(cmb_TipoDeUtil.Text);
            dtgv_BaseDeDatos.Refresh();
            dtgv_BaseDeDatos.Update();
        }


        public void LeeDatos(string texto)
        {
            List<Util> list = new List<Util>();
            try
            {
                switch (texto)
                {
                    case "Lapiz":
                        dtgv_BaseDeDatos.DataSource = UtilDAO.LeerDatosLapiz();
                        break;
                    case "Goma":
                        dtgv_BaseDeDatos.DataSource = UtilDAO.LeerDatosGoma();
                        break;
                    case "Sacapunta":
                        dtgv_BaseDeDatos.DataSource = UtilDAO.LeerDatosSacapuntas();
                        break;
                    default:
                        throw new ExceptionArchivo("Error al leer la base");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmb_TipoDeUtil_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescaLista();
            
        }

        public void MuestraImagen()
        {
            while (!tokenSource.IsCancellationRequested)// mientras no se pida la cancelacion
            {
                Bitmap image = new Bitmap(@"C:\Users\Willy\source\repos\TpUtiles\Vista\Resources\Trash_can_opens.gif");
                Thread.Sleep(1000);
                if (this.pic_ImagenBorrar.InvokeRequired)
                {
                    Action action = new Action(() =>
                    {
                        this.pic_ImagenBorrar.Image = image;
                    });
                    this.pic_ImagenBorrar.BeginInvoke(action);
                }
                else
                {
                    if(this.pic_ImagenBorrar.Image != null)
                    {
                        this.pic_ImagenBorrar.Image = image;
                    }
                   
                }
            }
        }

        private void btn_CancelarAnimacion_Click(object sender, EventArgs e)
        {
            
            this.pic_ImagenBorrar.Image.Dispose();
            this.pic_ImagenBorrar.Image= null;
            this.tokenSource.Cancel();
        }
    }

   
}
