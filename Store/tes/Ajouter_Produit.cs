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
    public partial class Ajouter_Produit : Form
    {
        public Ajouter_Produit()
        {
            InitializeComponent();
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        SqlConnection co = new SqlConnection(@"Data Source=DESKTOP-JD5J0V0\SQLEXPRESS;Initial Catalog=Gestion_Stock2;Integrated Security=True");
        DataSet dts = new DataSet();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
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

        private void Ajouter_Produit_Load(object sender, EventArgs e)
        {
            SqlDataAdapter dtp2 = new SqlDataAdapter("select * from dbo.categorie", co);
            DataSet dt = new DataSet();
            dt.Clear();
            dtp2.Fill(dt, "Mescategories");
            try
            {
                comboBox1.DisplayMember = "id_categorie";
                comboBox1.ValueMember = "id_categorie";
                comboBox1.DataSource = dt.Tables["Mescategories"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.produit", co);
            dts.Clear();
            dtp.Fill(dts, "Mesproduits");
            FileStream fs = new FileStream(imfpic, FileMode.Open, FileAccess.Read);
            BinaryReader rd = new BinaryReader(fs);
            img = rd.ReadBytes((int)fs.Length);
            
        
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                try
                {

                    DataRow ligne;
                    ligne = dts.Tables["Mesproduits"].NewRow();
                    ligne["nom_profuit"] = textBox2.Text;
                    ligne["quantité_produit"] = textBox1.Text;
                    ligne["prix_produit"] = textBox3.Text;
                    ligne["idCatg"] = comboBox1.SelectedValue;
                    ligne["image_produit"] = img;

                    dts.Tables["Mesproduits"].Rows.Add(ligne);

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    
             

                    MessageBox.Show("Ajout Effectué");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problème : " + ex.Message);
                }
            }
            else MessageBox.Show("Saisie Incompléte");
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                co.Open();
                SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.produit", co);
                SqlCommandBuilder cmdbuild = new SqlCommandBuilder(dtp);
                dtp.Update(dts, "Mesproduits");
                MessageBox.Show("Bien Enregistrer");




                co.Close();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
