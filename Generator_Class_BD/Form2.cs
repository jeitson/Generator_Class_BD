using Generator_Class_BD.Generator.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Generator_Class_BD
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        string fileName = "";
        String constructor = "";
        String variables = "";
        string vidPk = "";
        string vTypePk = "";

        private void btnPrevius_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dgvTablas.DataSource = GetTables().Tables[0];
            txtRuta.Text = @"C:\";
        }

        public DataSet GetTables()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con = new SqlConnection(lblstrConexion.Text + $"Initial Catalog={lblDataBase.Text};");
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select table_name From INFORMATION_SCHEMA.Tables where table_type='BASE TABLE'";
                da.SelectCommand = cmd;
                con.Close();
                da.Fill(ds);
            }
            catch (SqlException x)
            {
                MessageBox.Show("Error de SQL :" + x.Message);
            }
            catch (Exception y)
            {
                MessageBox.Show("Error :" + y.Message);
            }
            return ds;
        }

        public DataSet GetColumns(string TableName)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con = new SqlConnection(lblstrConexion.Text + $"Initial Catalog={lblDataBase.Text};");
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select COLUMN_NAME,DATA_TYPE,IS_NULLABLE,CHARACTER_MAXIMUM_LENGTH From INFORMATION_SCHEMA.columns where table_name=@TableName";
                cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 50).Value = TableName;
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (SqlException x)
            {
                MessageBox.Show("Error de SQL :" + x.Message);
            }
            catch (Exception y)
            {
                MessageBox.Show("Error :" + y.Message);
            }
            return ds;
        }

        public void GetPKey(string TableName)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(lblstrConexion.Text + $"Initial Catalog={lblDataBase.Text};");
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select b.column_name,a.data_type,a.IS_NULLABLE,a.CHARACTER_MAXIMUM_LENGTH From INFORMATION_SCHEMA.columns as a, INFORMATION_SCHEMA.KEY_COLUMN_USAGE as b where a.table_name=@TableName and constraint_name='PK_" + TableName + "' and a.column_name=b.column_name";
                cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 50).Value = TableName;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    vidPk = dr.GetString(0);
                    vTypePk = dr.GetString(1);
                }
            }
            catch (SqlException x)
            {
                MessageBox.Show("Error de SQL :" + x.Message);
            }
            catch (Exception y)
            {
                MessageBox.Show("Error :" + y.Message);
            }
        }

        private void dgvTablas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvColumn.DataSource = GetColumns(dgvTablas.Rows[e.RowIndex].Cells[1].Value.ToString()).Tables[0];
        }

        private void dgvTablas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvTablas.Rows[e.RowIndex].Cells[0].Value == null)
                    dgvTablas.Rows[e.RowIndex].Cells[0].Value = true;
                else if (Boolean.Parse(dgvTablas.Rows[e.RowIndex].Cells[0].Value.ToString()) == true)
                    dgvTablas.Rows[e.RowIndex].Cells[0].Value = false;
                else if (Boolean.Parse(dgvTablas.Rows[e.RowIndex].Cells[0].Value.ToString()) == false)
                    dgvTablas.Rows[e.RowIndex].Cells[0].Value = true;


            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                foreach (DataGridViewRow row in dgvTablas.Rows)
                {
                    row.Cells[0].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvTablas.Rows)
                {
                    row.Cells[0].Value = false;
                }
            }
        }

        private void btnCarpeta_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            bool mapperGenerated = false;
            foreach (DataGridViewRow row in dgvTablas.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (Boolean.Parse(row.Cells[0].Value.ToString()))
                    {
                        string name = row.Cells[1].Value.ToString();
                        if (ckbEntities.Checked)
                            GenerateEntity.Start(txtNamespace.Text, name, txtRuta.Text, GetColumns(name));

                        if (ckbDataAccess.Checked)
                            GenerateDataAccess.Start(txtNamespace.Text, name, txtRuta.Text);

                        if (ckbMappers.Checked)
                        {
                            GenerateDataAccessMapper.Start(txtNamespace.Text, name, txtRuta.Text, GetColumns(name));
                            GenerateDataContext.Start(txtNamespace.Text, name, txtRuta.Text, dgvTablas);
                            GenerateMetadata.Start(name, txtRuta.Text, GetColumns(name));
                        }

                        if (ckbBusiness.Checked)
                            GenerateBusiness.Start(txtNamespace.Text, name, txtRuta.Text);

                        if (ckbInterface.Checked)
                            GenerateInterface.Start(txtNamespace.Text, name, txtRuta.Text);

                        if (coreCheckInterface.Checked)
                            GenerateCoreIRepository.Start(txtNamespace.Text, name, txtRuta.Text);

                        if (coreCheckRepository.Checked)
                            GenerateCoreRepository.Start(txtNamespace.Text, name, txtRuta.Text);

                        if (coreCheckEntities.Checked)
                            GenerateCoreEntity.Start(txtNamespace.Text, name, txtRuta.Text, GetColumns(name));

                        if (chkDataCore.Checked)
                        {
                            GenerateCoreDataAccessMapper.Start(txtNamespace.Text, name, txtRuta.Text, GetColumns(name));
                            mapperGenerated = true;
                        }


                        GetPKey(name);
                        string columnName = TransformHelper.TransformField(vidPk);
                        string tipo = "Guid";
                        if (!columnName.CompareString("Id"))
                            tipo = "string";

                        string tipoPlantilla = Plantilla.ConvertirTipo(vTypePk, string.Empty);
                        if (!tipoPlantilla.CompareString("string"))
                            tipo = tipoPlantilla;

                        if (chkDataModule.Checked)
                        {
                            GenerateCoreServices.Start(txtNamespace.Text, name, txtRuta.Text, columnName, tipo);
                            GenerateCoreInterfaceServices.Start(txtNamespace.Text, name, txtRuta.Text, columnName, tipo);
                        }

                        if (chkDataController.Checked)
                            GenerateCoreController.Start(txtNamespace.Text, name, txtRuta.Text, columnName, tipo);
                    }
                }
            }

            if (mapperGenerated)
                GenerateCoreDataAccessConfigureBase.Start(txtNamespace.Text, txtRuta.Text);

            MessageBox.Show("Termino el Proceso");
        }

        private void txtClaseConexion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57))
            {
                e.Handled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void coreCheckInterface_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}