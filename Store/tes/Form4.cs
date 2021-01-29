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

namespace tes
{
    internal partial class clientforniss : Form
    {
        public clientforniss()
        {
            InitializeComponent();
        }

        SqlConnection co = new SqlConnection(@"Data Source=DESKTOP-JD5J0V0\SQLEXPRESS;Initial Catalog=Gestion_Stcock;Integrated Security=True");
        DataSet dts = new DataSet();
      
  
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                AJOUTER_MODIFIER_CLIENT AJTCLI = new AJOUTER_MODIFIER_CLIENT();
                AJTCLI.Show();
            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    Ajout_Fourniss fourn = new Ajout_Fourniss();
                    fourn.Show();
                }
            }
       

         
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

                Modifier_client modcli = new Modifier_client();
                modcli.Show();
            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    modifier_Fournisseur ff = new modifier_Fournisseur();
                    ff.Show();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clientforniss_Load(object sender, EventArgs e)
        {
           
                SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.Client", co);
                dts.Clear();
                dtp.Fill(dts, "MesClients");

             SqlDataAdapter dtp2 = new SqlDataAdapter("select * from fourniseur", co);
                    DataSet dts2 = new DataSet();
                    dts2.Clear();
                    dtp2.Fill(dts2, "Mesfournisseur");

                try
                {
                    dataGridView1.DataSource = dts.Tables["MesClients"];
                     dataGridView2.DataSource = dts2.Tables["Mesfournisseur"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problème : " + ex.Message);
                }

           
                
                   
                
            
            

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            dataGridView1.DataSource = dts.Tables["MesClients"];
        }

        private void bunifuGradientPanel1_EnabledChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dts.Tables["MesClients"];
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                suppClient supp = new suppClient();
                supp.Show();
            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    supp_fournisseurcs pp = new supp_fournisseurcs();
                    pp.Show();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.Client", co);
            dts.Clear();
            dtp.Fill(dts, "MesClients");

            try
            {
                dataGridView1.DataSource = dts.Tables["MesClients"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

                SqlDataAdapter dtp = new SqlDataAdapter("select * from Client ", co);
                dts.Clear();
                dtp.Fill(dts, "MesClient");

                DataView dvCl = dts.Tables["Mesclient"].DefaultView;

                try
                {
                    dvCl.RowFilter = "nom_client like '%" + textBox1.Text + "%'";
                    dvCl.Sort = "codecl ASC";
                    dataGridView1.DataSource = dts.Tables["Mesclient"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problème à la création de la vue: " + ex.Message);
                }
            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    SqlDataAdapter dtp2 = new SqlDataAdapter("select * from fourniseur ", co);
                    DataSet dts2 = new DataSet();
                    dts2.Clear();
                    dtp2.Fill(dts2, "Mesfourniseur");

                    DataView dvfr = new DataView();
                      dvfr =  dts2.Tables["Mesfourniseur"].DefaultView;

                    try
                    {
                        dvfr.RowFilter = "nom_fournis like '%" + textBox1.Text + "%'";
                        dvfr.Sort = "codeFr ASC";
                        dataGridView1.DataSource = dts2.Tables["Mesfourniseur"];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Problème à la création de la vue: " + ex.Message);
                    }
                }
            }
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            SqlDataAdapter dtp = new SqlDataAdapter("select * from Client", co);
            dts.Clear();
            dtp.Fill(dts, "MesClient");

            DataView dvCl = dts.Tables["Mesclient"].DefaultView;

            try
            {
                dvCl.RowFilter = "nom_client like '%" + textBox1.Text + "%'";
                dvCl.Sort = "codecl ASC";
                dataGridView1.DataSource = dts.Tables["Mesclient"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème à la création de la vue: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
