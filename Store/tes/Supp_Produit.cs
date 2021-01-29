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
    public partial class Supp_Produit : Form
    {
        public Supp_Produit()
        {
            InitializeComponent();
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        SqlConnection co = new SqlConnection(@"Data Source=DESKTOP-JD5J0V0\SQLEXPRESS;Initial Catalog=Gestion_Stock2;Integrated Security=True");
        DataSet dts = new DataSet();
        DataView dv = new DataView();
        DataView dv1 = new DataView();

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
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
          dv1[0].Delete();
        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dv1 = new DataView(dts.Tables["Mesproduits"], "id_produit=" + comboBox1.SelectedValue, "", DataViewRowState.CurrentRows);
            textBox1.Text = dv1[0].Row["nom_profuit"].ToString();
            textBox2.Text = dv1[0].Row["quantité_produit"].ToString();

       
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.produit", co);
            if (dv.Count != 0)
            {
                DialogResult res = MessageBox.Show("Voulez vous Appliquer les suppressions", "Comfirmation Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    SqlCommandBuilder bldbq = new SqlCommandBuilder(dtp);
                    dtp.Update(dts, "Mesproduits");
                }
            }

        }

        private void Supp_Produit_Load(object sender, EventArgs e)
        {
            dv1.AllowDelete = true;
            SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.produit", co);
            dts.Clear();
            dtp.Fill(dts, "Mesproduits");


            try
            {
                comboBox1.DisplayMember = "id_produit";
                comboBox1.ValueMember = "id_produit";
                comboBox1.DataSource = dts.Tables["Mesproduits"];



                dv = new DataView(dts.Tables["Mesproduits"], "", "", DataViewRowState.Deleted);
                dataGridView2.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
