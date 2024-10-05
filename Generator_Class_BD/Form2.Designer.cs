namespace Generator_Class_BD
{
    partial class Form2
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTablas = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvColumn = new System.Windows.Forms.DataGridView();
            this.btnPrevius = new System.Windows.Forms.Button();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblDataBase = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.btnCarpeta = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.ckbBusiness = new System.Windows.Forms.CheckBox();
            this.ckbDataAccess = new System.Windows.Forms.CheckBox();
            this.ckbMappers = new System.Windows.Forms.CheckBox();
            this.ckbInterface = new System.Windows.Forms.CheckBox();
            this.ckbEntities = new System.Windows.Forms.CheckBox();
            this.ckbServices = new System.Windows.Forms.CheckBox();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.lblGenerar = new System.Windows.Forms.Label();
            this.lblNamespace = new System.Windows.Forms.Label();
            this.lblstrConexion = new System.Windows.Forms.Label();
            this.coreCheckInterface = new System.Windows.Forms.CheckBox();
            this.coreCheckRepository = new System.Windows.Forms.CheckBox();
            this.coreCheckEntities = new System.Windows.Forms.CheckBox();
            this.chkDataCore = new System.Windows.Forms.CheckBox();
            this.chkDataModule = new System.Windows.Forms.CheckBox();
            this.chkDataController = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablas)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumn)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTablas);
            this.groupBox1.Location = new System.Drawing.Point(12, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 403);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tablas";
            // 
            // dgvTablas
            // 
            this.dgvTablas.AllowUserToAddRows = false;
            this.dgvTablas.AllowUserToDeleteRows = false;
            this.dgvTablas.AllowUserToResizeRows = false;
            this.dgvTablas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2});
            this.dgvTablas.Location = new System.Drawing.Point(13, 19);
            this.dgvTablas.MultiSelect = false;
            this.dgvTablas.Name = "dgvTablas";
            this.dgvTablas.ReadOnly = true;
            this.dgvTablas.RowHeadersVisible = false;
            this.dgvTablas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTablas.Size = new System.Drawing.Size(253, 378);
            this.dgvTablas.TabIndex = 1;
            this.dgvTablas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTablas_CellClick);
            this.dgvTablas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTablas_CellEnter);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Select";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 60;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvColumn);
            this.groupBox2.Location = new System.Drawing.Point(308, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 223);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Columnas";
            // 
            // dgvColumn
            // 
            this.dgvColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumn.Location = new System.Drawing.Point(15, 19);
            this.dgvColumn.Name = "dgvColumn";
            this.dgvColumn.Size = new System.Drawing.Size(325, 198);
            this.dgvColumn.TabIndex = 2;
            // 
            // btnPrevius
            // 
            this.btnPrevius.Location = new System.Drawing.Point(657, 487);
            this.btnPrevius.Name = "btnPrevius";
            this.btnPrevius.Size = new System.Drawing.Size(83, 23);
            this.btnPrevius.TabIndex = 7;
            this.btnPrevius.Text = "Previus";
            this.btnPrevius.UseVisualStyleBackColor = true;
            this.btnPrevius.Click += new System.EventHandler(this.btnPrevius_Click);
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerName.Location = new System.Drawing.Point(126, 9);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(66, 13);
            this.lblServerName.TabIndex = 5;
            this.lblServerName.Text = "ServerName";
            // 
            // lblDataBase
            // 
            this.lblDataBase.AutoSize = true;
            this.lblDataBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataBase.Location = new System.Drawing.Point(126, 32);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(77, 13);
            this.lblDataBase.TabIndex = 6;
            this.lblDataBase.Text = "Base de Datos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "ServerName :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Base de Datos :";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(222, 50);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Todos";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(295, 6);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(270, 20);
            this.txtRuta.TabIndex = 21;
            // 
            // btnCarpeta
            // 
            this.btnCarpeta.Location = new System.Drawing.Point(571, 3);
            this.btnCarpeta.Name = "btnCarpeta";
            this.btnCarpeta.Size = new System.Drawing.Size(95, 23);
            this.btnCarpeta.TabIndex = 1;
            this.btnCarpeta.Text = "Ubicar Carpeta";
            this.btnCarpeta.UseVisualStyleBackColor = true;
            this.btnCarpeta.Click += new System.EventHandler(this.btnCarpeta_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(746, 456);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(85, 25);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(746, 487);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(85, 23);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Exit";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ckbBusiness
            // 
            this.ckbBusiness.AutoSize = true;
            this.ckbBusiness.Location = new System.Drawing.Point(323, 338);
            this.ckbBusiness.Name = "ckbBusiness";
            this.ckbBusiness.Size = new System.Drawing.Size(101, 17);
            this.ckbBusiness.TabIndex = 22;
            this.ckbBusiness.Text = "Clases business";
            this.ckbBusiness.UseVisualStyleBackColor = true;
            // 
            // ckbDataAccess
            // 
            this.ckbDataAccess.AutoSize = true;
            this.ckbDataAccess.Location = new System.Drawing.Point(323, 362);
            this.ckbDataAccess.Name = "ckbDataAccess";
            this.ckbDataAccess.Size = new System.Drawing.Size(118, 17);
            this.ckbDataAccess.TabIndex = 23;
            this.ckbDataAccess.Text = "Clases data access";
            this.ckbDataAccess.UseVisualStyleBackColor = true;
            // 
            // ckbMappers
            // 
            this.ckbMappers.AutoSize = true;
            this.ckbMappers.Location = new System.Drawing.Point(323, 386);
            this.ckbMappers.Name = "ckbMappers";
            this.ckbMappers.Size = new System.Drawing.Size(100, 17);
            this.ckbMappers.TabIndex = 24;
            this.ckbMappers.Text = "Clases mappers";
            this.ckbMappers.UseVisualStyleBackColor = true;
            // 
            // ckbInterface
            // 
            this.ckbInterface.AutoSize = true;
            this.ckbInterface.Location = new System.Drawing.Point(323, 410);
            this.ckbInterface.Name = "ckbInterface";
            this.ckbInterface.Size = new System.Drawing.Size(106, 17);
            this.ckbInterface.TabIndex = 25;
            this.ckbInterface.Text = "Clases interfaces";
            this.ckbInterface.UseVisualStyleBackColor = true;
            // 
            // ckbEntities
            // 
            this.ckbEntities.AutoSize = true;
            this.ckbEntities.Location = new System.Drawing.Point(323, 315);
            this.ckbEntities.Name = "ckbEntities";
            this.ckbEntities.Size = new System.Drawing.Size(93, 17);
            this.ckbEntities.TabIndex = 26;
            this.ckbEntities.Text = "Clases entities";
            this.ckbEntities.UseVisualStyleBackColor = true;
            // 
            // ckbServices
            // 
            this.ckbServices.AutoSize = true;
            this.ckbServices.Location = new System.Drawing.Point(323, 434);
            this.ckbServices.Name = "ckbServices";
            this.ckbServices.Size = new System.Drawing.Size(99, 17);
            this.ckbServices.TabIndex = 27;
            this.ckbServices.Text = "Clases services";
            this.ckbServices.UseVisualStyleBackColor = true;
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(455, 312);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(193, 20);
            this.txtNamespace.TabIndex = 29;
            // 
            // lblGenerar
            // 
            this.lblGenerar.AutoSize = true;
            this.lblGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenerar.Location = new System.Drawing.Point(323, 291);
            this.lblGenerar.Name = "lblGenerar";
            this.lblGenerar.Size = new System.Drawing.Size(90, 13);
            this.lblGenerar.TabIndex = 28;
            this.lblGenerar.Text = "Type of clases";
            // 
            // lblNamespace
            // 
            this.lblNamespace.AutoSize = true;
            this.lblNamespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamespace.Location = new System.Drawing.Point(452, 289);
            this.lblNamespace.Name = "lblNamespace";
            this.lblNamespace.Size = new System.Drawing.Size(73, 13);
            this.lblNamespace.TabIndex = 30;
            this.lblNamespace.Text = "Namespace";
            // 
            // lblstrConexion
            // 
            this.lblstrConexion.AutoSize = true;
            this.lblstrConexion.Location = new System.Drawing.Point(12, 487);
            this.lblstrConexion.Name = "lblstrConexion";
            this.lblstrConexion.Size = new System.Drawing.Size(35, 13);
            this.lblstrConexion.TabIndex = 31;
            this.lblstrConexion.Text = "label3";
            this.lblstrConexion.Visible = false;
            // 
            // coreCheckInterface
            // 
            this.coreCheckInterface.AutoSize = true;
            this.coreCheckInterface.Location = new System.Drawing.Point(466, 350);
            this.coreCheckInterface.Name = "coreCheckInterface";
            this.coreCheckInterface.Size = new System.Drawing.Size(98, 17);
            this.coreCheckInterface.TabIndex = 32;
            this.coreCheckInterface.Text = "Core Interfaces";
            this.coreCheckInterface.UseVisualStyleBackColor = true;
            this.coreCheckInterface.CheckedChanged += new System.EventHandler(this.coreCheckInterface_CheckedChanged);
            // 
            // coreCheckRepository
            // 
            this.coreCheckRepository.AutoSize = true;
            this.coreCheckRepository.Location = new System.Drawing.Point(466, 373);
            this.coreCheckRepository.Name = "coreCheckRepository";
            this.coreCheckRepository.Size = new System.Drawing.Size(101, 17);
            this.coreCheckRepository.TabIndex = 33;
            this.coreCheckRepository.Text = "Core Repository";
            this.coreCheckRepository.UseVisualStyleBackColor = true;
            // 
            // coreCheckEntities
            // 
            this.coreCheckEntities.AutoSize = true;
            this.coreCheckEntities.Location = new System.Drawing.Point(466, 396);
            this.coreCheckEntities.Name = "coreCheckEntities";
            this.coreCheckEntities.Size = new System.Drawing.Size(85, 17);
            this.coreCheckEntities.TabIndex = 34;
            this.coreCheckEntities.Text = "Core Entities";
            this.coreCheckEntities.UseVisualStyleBackColor = true;
            // 
            // chkDataCore
            // 
            this.chkDataCore.AutoSize = true;
            this.chkDataCore.Location = new System.Drawing.Point(466, 419);
            this.chkDataCore.Name = "chkDataCore";
            this.chkDataCore.Size = new System.Drawing.Size(74, 17);
            this.chkDataCore.TabIndex = 35;
            this.chkDataCore.Text = "Core Data";
            this.chkDataCore.UseVisualStyleBackColor = true;
            // 
            // chkDataModule
            // 
            this.chkDataModule.AutoSize = true;
            this.chkDataModule.Location = new System.Drawing.Point(466, 442);
            this.chkDataModule.Name = "chkDataModule";
            this.chkDataModule.Size = new System.Drawing.Size(86, 17);
            this.chkDataModule.TabIndex = 36;
            this.chkDataModule.Text = "Core Module";
            this.chkDataModule.UseVisualStyleBackColor = true;
            // 
            // chkDataController
            // 
            this.chkDataController.AutoSize = true;
            this.chkDataController.Location = new System.Drawing.Point(465, 461);
            this.chkDataController.Name = "chkDataController";
            this.chkDataController.Size = new System.Drawing.Size(95, 17);
            this.chkDataController.TabIndex = 37;
            this.chkDataController.Text = "Core Controller";
            this.chkDataController.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 522);
            this.Controls.Add(this.chkDataController);
            this.Controls.Add(this.chkDataModule);
            this.Controls.Add(this.chkDataCore);
            this.Controls.Add(this.coreCheckEntities);
            this.Controls.Add(this.coreCheckRepository);
            this.Controls.Add(this.coreCheckInterface);
            this.Controls.Add(this.lblstrConexion);
            this.Controls.Add(this.lblNamespace);
            this.Controls.Add(this.txtNamespace);
            this.Controls.Add(this.lblGenerar);
            this.Controls.Add(this.ckbServices);
            this.Controls.Add(this.ckbEntities);
            this.Controls.Add(this.ckbInterface);
            this.Controls.Add(this.ckbMappers);
            this.Controls.Add(this.ckbDataAccess);
            this.Controls.Add(this.ckbBusiness);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnPrevius);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.btnCarpeta);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDataBase);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generador de Clases";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTablas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvColumn;
        private System.Windows.Forms.Button btnPrevius;
        public System.Windows.Forms.Label lblServerName;
        public System.Windows.Forms.Label lblDataBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Button btnCarpeta;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.CheckBox ckbBusiness;
        private System.Windows.Forms.CheckBox ckbDataAccess;
        private System.Windows.Forms.CheckBox ckbMappers;
        private System.Windows.Forms.CheckBox ckbInterface;
        private System.Windows.Forms.CheckBox ckbEntities;
        private System.Windows.Forms.CheckBox ckbServices;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Label lblGenerar;
        private System.Windows.Forms.Label lblNamespace;
        public System.Windows.Forms.Label lblstrConexion;
        private System.Windows.Forms.CheckBox coreCheckInterface;
        private System.Windows.Forms.CheckBox coreCheckRepository;
        private System.Windows.Forms.CheckBox coreCheckEntities;
        private System.Windows.Forms.CheckBox chkDataCore;
        private System.Windows.Forms.CheckBox chkDataModule;
        private System.Windows.Forms.CheckBox chkDataController;
    }
}