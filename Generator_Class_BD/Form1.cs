/*******************************************/
/*****       Maguna Library            *****/
/*******************************************/
/** Owner: Jeitson Guerrero Barajas       **/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Generator_Class_BD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                lblstrConexion.Text = "SERVER=.\\SQLEXPRESS;Initial Catalog=" + cbListaBD.Text + ";Integrated Security=True";
                txtUser.Enabled = false;
                txtPass.Enabled = false;
            }
            else
            {
                lblstrConexion.Text = "SERVER=" + txtServerName.Text.Trim() + ";Initial Catalog=" + cbListaBD.Text + ";USER ID=" + txtUser.Text + ";PWD=" + txtPass.Text + ";";
                txtUser.Enabled = true;
                txtPass.Enabled = true;
                txtUser.Text = "";
                txtPass.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtServerName.Focus();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (txtServerName.Text.Length == 0)
            {
                MessageBox.Show("Ingrese Nombre del Servidor");
                txtServerName.Focus();
            }
            else
            {
                DataSet ds = new DataSet();
                if (checkBox1.Checked)
                {
                    lblstrConexion.Text = "SERVER=.\\SQLEXPRESS;Initial Catalog=" + cbListaBD.Text + ";Integrated Security=True";
                }
                else
                {
                    lblstrConexion.Text = "SERVER=;Initial Catalog=;Persist Security Info=False;User ID=;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                }
                try
                {
                    List<string> list = new List<string>();
                    using (SqlConnection con = new SqlConnection(lblstrConexion.Text))
                    {
                        con.Open();

                        // Set up a command with the given query and associate
                        // this with the current connection.
                        using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                        {
                            using (IDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    list.Add(dr[0].ToString());
                                }
                            }
                        }
                    }
                    cbListaBD.DataSource = list;

                    //SqlConnection con = new SqlConnection(""+lblstrConexion.Text+"");
                    //con.Open();
                    //SqlCommand cmd = new SqlCommand();
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "sp_databases";

                    //System.Data.SqlClient.SqlDataReader SqlDR;
                    //SqlDR = cmd.ExecuteReader();

                    //List<string> tables = new List<string>();

                    //while (SqlDR.Read())
                    //{
                    //    tables.Add(SqlDR.GetString(0));
                    //    MessageBox.Show(SqlDR.GetString(0));
                    //}

                    //cbListaBD.DataSource = tables;

                    // SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    //ad.Fill(ds);
                    //con.Close();
                    //cbListaBD.DataSource = tables;
                }
                catch (SqlException x)
                {
                    MessageBox.Show("Error de SQL :" + x.Message);
                }
                catch (Exception y)
                {
                    MessageBox.Show("Error :" + y.Message);
                }
                if (cbListaBD.Items.Count > 0)
                    btnNext.Enabled = true;
            }
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.lblstrConexion.Text = lblstrConexion.Text;
            frm.lblServerName.Text = txtServerName.Text;
            frm.lblDataBase.Text = cbListaBD.Text;
            frm.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}