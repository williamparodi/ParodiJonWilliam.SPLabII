namespace Vista
{
    partial class FrmBaseDeDatos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_LeerBase = new System.Windows.Forms.Button();
            this.dtgv_BaseDeDatos = new System.Windows.Forms.DataGridView();
            this.btn_GuardaEnBase = new System.Windows.Forms.Button();
            this.cmb_TipoDeUtil = new System.Windows.Forms.ComboBox();
            this.btn_AgregarUtil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_BaseDeDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_LeerBase
            // 
            this.btn_LeerBase.Location = new System.Drawing.Point(519, 279);
            this.btn_LeerBase.Name = "btn_LeerBase";
            this.btn_LeerBase.Size = new System.Drawing.Size(108, 52);
            this.btn_LeerBase.TabIndex = 0;
            this.btn_LeerBase.Text = "Leer Base de Datos";
            this.btn_LeerBase.UseVisualStyleBackColor = true;
            this.btn_LeerBase.Click += new System.EventHandler(this.btn_LeerBase_Click);
            // 
            // dtgv_BaseDeDatos
            // 
            this.dtgv_BaseDeDatos.AllowUserToAddRows = false;
            this.dtgv_BaseDeDatos.AllowUserToDeleteRows = false;
            this.dtgv_BaseDeDatos.AllowUserToResizeColumns = false;
            this.dtgv_BaseDeDatos.AllowUserToResizeRows = false;
            this.dtgv_BaseDeDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_BaseDeDatos.Location = new System.Drawing.Point(12, 36);
            this.dtgv_BaseDeDatos.Name = "dtgv_BaseDeDatos";
            this.dtgv_BaseDeDatos.ReadOnly = true;
            this.dtgv_BaseDeDatos.RowTemplate.Height = 25;
            this.dtgv_BaseDeDatos.Size = new System.Drawing.Size(615, 231);
            this.dtgv_BaseDeDatos.TabIndex = 1;
            this.dtgv_BaseDeDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_BaseDeDatos_CellClick);
            // 
            // btn_GuardaEnBase
            // 
            this.btn_GuardaEnBase.Location = new System.Drawing.Point(239, 279);
            this.btn_GuardaEnBase.Name = "btn_GuardaEnBase";
            this.btn_GuardaEnBase.Size = new System.Drawing.Size(108, 52);
            this.btn_GuardaEnBase.TabIndex = 2;
            this.btn_GuardaEnBase.Text = "Guardar en Base de Datos";
            this.btn_GuardaEnBase.UseVisualStyleBackColor = true;
            this.btn_GuardaEnBase.Click += new System.EventHandler(this.btn_GuardaEnBase_Click);
            // 
            // cmb_TipoDeUtil
            // 
            this.cmb_TipoDeUtil.FormattingEnabled = true;
            this.cmb_TipoDeUtil.Items.AddRange(new object[] {
            "Lapiz",
            "Goma",
            "Sacapunta"});
            this.cmb_TipoDeUtil.Location = new System.Drawing.Point(14, 7);
            this.cmb_TipoDeUtil.Name = "cmb_TipoDeUtil";
            this.cmb_TipoDeUtil.Size = new System.Drawing.Size(121, 23);
            this.cmb_TipoDeUtil.TabIndex = 3;
            // 
            // btn_AgregarUtil
            // 
            this.btn_AgregarUtil.Location = new System.Drawing.Point(12, 279);
            this.btn_AgregarUtil.Name = "btn_AgregarUtil";
            this.btn_AgregarUtil.Size = new System.Drawing.Size(97, 43);
            this.btn_AgregarUtil.TabIndex = 4;
            this.btn_AgregarUtil.Text = "Agregar Util";
            this.btn_AgregarUtil.UseVisualStyleBackColor = true;
            this.btn_AgregarUtil.Click += new System.EventHandler(this.btn_AgregarUtil_Click);
            // 
            // FrmBaseDeDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_AgregarUtil);
            this.Controls.Add(this.cmb_TipoDeUtil);
            this.Controls.Add(this.btn_GuardaEnBase);
            this.Controls.Add(this.dtgv_BaseDeDatos);
            this.Controls.Add(this.btn_LeerBase);
            this.Name = "FrmBaseDeDatos";
            this.Text = "FrmBaseDeDatos";
            this.Load += new System.EventHandler(this.FrmBaseDeDatos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_BaseDeDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_LeerBase;
        private System.Windows.Forms.DataGridView dtgv_BaseDeDatos;
        private System.Windows.Forms.Button btn_GuardaEnBase;
        private System.Windows.Forms.ComboBox cmb_TipoDeUtil;
        private System.Windows.Forms.Button btn_AgregarUtil;
    }
}