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
using System.IO;

namespace tes
{
    public partial class Modifier_Produit : Form
    {
        public Modifier_Produit()
        {
            InitializeComponent();
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        SqlConnection co = new SqlConnection(@"Data Source=DESKTOP-JD5J0V0\SQLEXPRESS;Initial Catalog=Gestion_Stock2;Integrated Security=True");
        DataSet dts = new DataSet();
        DataView dv = new DataView();
        DataView dv1 = new DataView();
        string imfpic = "";

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
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "   Nom Du Produit")
            {
                textBox2.Text = "";

            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "   QUANTITE")
            {
                textBox1.Text = "";

            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "   PRIX")
            {
                textBox3.Text = "";

            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "   Nom Du Produit";

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "   QUANTITE";

            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

            if (textBox3.Text == "")
            {
                textBox3.Text = "   PRIX";

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Modifier_Produit_Load(object sender, EventArgs e)
        {
            dv1.AllowEdit = true;
            SqlDataAdapter dtp = new SqlDataAdapter("select * from produit", co);
            dts.Clear();
            dtp.Fill(dts, "Mesproduits");


            try
            {
                comboBox1.DisplayMember = "id_produit";
                comboBox1.ValueMember = "id_produit";
                comboBox1.DataSource = dts.Tables["Mesproduits"];



                dv = new DataView(dts.Tables["Mesproduits"], "", "", DataViewRowState.ModifiedCurrent);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* SqlDataAdapter dtp2 = new SqlDataAdapter("select * from dbo.produit where id_produit =" + comboBox1.SelectedValue, co);
            DataSet dts2 = new DataSet();
            dtp2.Fill(dts2, "pro");*/
            try
            {
                dv1 = new DataView(dts.Tables["Mesproduits"], "id_produit =" + comboBox1.SelectedValue, "", DataViewRowState.CurrentRows);
                textBox2.Text = dv1[0].Row["nom_profuit"].ToString();
                textBox1.Text = dv1[0].Row["quantité_produit"].ToString();
                textBox3.Text = dv1[0].Row["prix_produit"].ToString();
                byte[] img = ((byte[])dv1[0].Row["image_produit"]);

                if (img == null)
                {
                    pictureBox2.Image = null;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox2.Image = Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
          
            /*byte[] img = (byte[])(dts.Tables["Mesproduits"].Rows[0]["image_produit"]);

            if (img == null)
            {
                pictureBox2.Image = null;
            }
            else
            {
                MemoryStream ms = new MemoryStream(img);
                pictureBox2.Image = Image.FromStream(ms);
            }*/
            
            
           
          


        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
         /*   byte[] img = null;
            SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.produit", co);
            dts.Clear();
            dtp.Fill(dts, "Mesproduits");*/
           /* FileStream fs = new FileStream(imfpic, FileMode.Open, FileAccess.Read);
            BinaryReader rd = new BinaryReader(fs);
            img = rd.ReadBytes((int)fs.Length);*/
           /* SqlDataAdapter dtp2 = new SqlDataAdapter("select * from dbo.produit where id_produit = " + comboBox1.SelectedValue, co);
            DataSet dts2 = new DataSet();
            dtp2.Fill(dts2, "pro");

            byte[] img = (byte[])dts2.Tables["pro"].Rows[0][5];
            MemoryStream ms = new MemoryStream(img);
            pictureBox2.Image = Image.FromStream(ms);*/

            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            byte[] img = ms.ToArray();

            SqlDataAdapter dtp2 = new SqlDataAdapter("select * from dbo.produit where id_produit = " + comboBox1.SelectedValue, co);
            DataSet dts2 = new DataSet();
            dtp2.Fill(dts2, "pro");
            SqlParameter pr = new SqlParameter();
           

            try
            {
                dv1 = new DataView(dts.Tables["Mesproduits"], "id_produit =" + comboBox1.SelectedValue, "", DataViewRowState.CurrentRows);
                dv1[0].BeginEdit();
                dv1[0]["nom_profuit"] = textBox2.Text;
                dv1[0]["quantité_produit"] = textBox1.Text;
                dv1[0].Row["prix_produit"] = textBox3.Text;
                dv1[0].Row["image_produit"] = img;

                dv1[0].EndEdit();
                MessageBox.Show("Modification Effectuée");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter dtp = new SqlDataAdapter("select * from produit", co);
                dtp.Fill(dts, "Mesproduits");
                SqlCommandBuilder BldBq = new SqlCommandBuilder(dtp);
                dtp.Update(dts, "Mesproduits");

                MessageBox.Show("Enregistrer Effectuée");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "JPG Files(*.jpg)|*.jpg|all files(*.*)|*.*";
            fd.ShowDialog();
            imfpic = fd.FileName.ToString();
            pictureBox2.ImageLocation = imfpic;
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
