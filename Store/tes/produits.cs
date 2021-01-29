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
    public partial class produits : Form
    {
        public produits()
        {
            InitializeComponent();
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private const int cGrip = 16;
        private const int cCaption = 32;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }
        SqlConnection co = new SqlConnection(@"Data Source=DESKTOP-JD5J0V0\SQLEXPRESS;Initial Catalog=Gestion_Stock2;Integrated Security=True");
        /// <summary>
        ///
        /// </summary>
        DataSet dts = new DataSet();

        private void bunifuThinButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Recherche")
            {
                textBox1.Text = "";

            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Supp_Produit Sup_pro = new Supp_Produit();
            Sup_pro.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Ajouter_Produit ajtpro = new Ajouter_Produit();
            ajtpro.Show();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Modifier_Produit modpro = new Modifier_Produit();
            modpro.Show();
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ventes_Load(object sender, EventArgs e)
        {
          
           
            
            SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.produit", co);
            dts.Clear();
            dtp.Fill(dts, "Mesproduits");

            try
            {
                dataGridView1.DataSource = dts.Tables["Mesproduits"];
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dtp = new SqlDataAdapter("select * from produit ", co);
            dts.Clear();
            dtp.Fill(dts, "Mesproduits");

            DataView dvCl = dts.Tables["Mesproduits"].DefaultView;

            try
            {
                dvCl.RowFilter = "nom_profuit like '%" + textBox1.Text + "%'";
                dvCl.Sort = "id_produit ASC";
                dataGridView1.DataSource = dts.Tables["Mesproduits"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème à la création de la vue: " + ex.Message);
            }
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            SqlDataAdapter dtp = new SqlDataAdapter("select * from produit", co);
            dts.Clear();
            dtp.Fill(dts, "Mesproduits");

            DataView dvCl = dts.Tables["Mesproduits"].DefaultView;

            try
            {
                dvCl.RowFilter = "nom_profuit like '%" + textBox1.Text + "%'";
                dvCl.Sort = "id_produit ASC";
                dataGridView1.DataSource = dts.Tables["Mesproduits"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème à la création de la vue: " + ex.Message);
            }
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.produit", co);
            dts.Clear();
            dtp.Fill(dts, "Mesproduits");

            try
            {
                dataGridView1.DataSource = dts.Tables["Mesproduits"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }
    }
}
