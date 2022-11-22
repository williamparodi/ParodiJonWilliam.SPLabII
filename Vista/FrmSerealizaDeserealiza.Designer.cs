namespace Vista
{
    partial class FrmSerealizaDeserealiza
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
            this.dtgv_ListaLapices = new System.Windows.Forms.DataGridView();
            this.lbl_ListaLapices = new System.Windows.Forms.Label();
            this.btn_SerealizarXml = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_DeserealizarXml = new System.Windows.Forms.Button();
            this.btn_DeserealizarJson = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ListaLapices)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgv_ListaLapices
            // 
            this.dtgv_ListaLapices.AllowUserToAddRows = false;
            this.dtgv_ListaLapices.AllowUserToDeleteRows = false;
            this.dtgv_ListaLapices.AllowUserToResizeColumns = false;
            this.dtgv_ListaLapices.AllowUserToResizeRows = false;
            this.dtgv_ListaLapices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_ListaLapices.Location = new System.Drawing.Point(12, 55);
            this.dtgv_ListaLapices.Name = "dtgv_ListaLapices";
            this.dtgv_ListaLapices.ReadOnly = true;
            this.dtgv_ListaLapices.RowTemplate.Height = 25;
            this.dtgv_ListaLapices.Size = new System.Drawing.Size(362, 199);
            this.dtgv_ListaLapices.TabIndex = 0;
            this.dtgv_ListaLapices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_ListaLapices_CellContentClick);
            // 
            // lbl_ListaLapices
            // 
            this.lbl_ListaLapices.AutoSize = true;
            this.lbl_ListaLapices.Location = new System.Drawing.Point(15, 25);
            this.lbl_ListaLapices.Name = "lbl_ListaLapices";
            this.lbl_ListaLapices.Size = new System.Drawing.Size(89, 15);
            this.lbl_ListaLapices.TabIndex = 1;
            this.lbl_ListaLapices.Text = "Lista de Lapices";
            // 
            // btn_SerealizarXml
            // 
            this.btn_SerealizarXml.Location = new System.Drawing.Point(12, 284);
            this.btn_SerealizarXml.Name = "btn_SerealizarXml";
            this.btn_SerealizarXml.Size = new System.Drawing.Size(88, 54);
            this.btn_SerealizarXml.TabIndex = 2;
            this.btn_SerealizarXml.Text = "Serealizar Lapiz Xml";
            this.btn_SerealizarXml.UseVisualStyleBackColor = true;
            this.btn_SerealizarXml.Click += new System.EventHandler(this.btn_SerealizarXml_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 54);
            this.button1.TabIndex = 3;
            this.button1.Text = "Serealizar Lapiz Json";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_DeserealizarXml
            // 
            this.btn_DeserealizarXml.Location = new System.Drawing.Point(380, 55);
            this.btn_DeserealizarXml.Name = "btn_DeserealizarXml";
            this.btn_DeserealizarXml.Size = new System.Drawing.Size(98, 54);
            this.btn_DeserealizarXml.TabIndex = 4;
            this.btn_DeserealizarXml.Text = "Deseralizar Lapiz Xml";
            this.btn_DeserealizarXml.UseVisualStyleBackColor = true;
            // 
            // btn_DeserealizarJson
            // 
            this.btn_DeserealizarJson.Location = new System.Drawing.Point(380, 178);
            this.btn_DeserealizarJson.Name = "btn_DeserealizarJson";
            this.btn_DeserealizarJson.Size = new System.Drawing.Size(98, 54);
            this.btn_DeserealizarJson.TabIndex = 5;
            this.btn_DeserealizarJson.Text = "Deserealizar Lapiz Json";
            this.btn_DeserealizarJson.UseVisualStyleBackColor = true;
            // 
            // FrmSerealizaDeserealiza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_DeserealizarJson);
            this.Controls.Add(this.btn_DeserealizarXml);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_SerealizarXml);
            this.Controls.Add(this.lbl_ListaLapices);
            this.Controls.Add(this.dtgv_ListaLapices);
            this.Name = "FrmSerealizaDeserealiza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serealiza y Deserealiza";
            this.Load += new System.EventHandler(this.FrmSerealizaDeserealiza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ListaLapices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgv_ListaLapices;
        private System.Windows.Forms.Label lbl_ListaLapices;
        private System.Windows.Forms.Button btn_SerealizarXml;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_DeserealizarXml;
        private System.Windows.Forms.Button btn_DeserealizarJson;
    }
}