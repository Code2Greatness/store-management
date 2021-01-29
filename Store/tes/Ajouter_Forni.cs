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
    public partial class Ajouter_fourni : Form
    {
        public Ajouter_fourni()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        SqlConnection co = new SqlConnection(@"Data Source=DESKTOP-JD5J0V0\SQLEXPRESS;Initial Catalog=Gestion_Stock2;Integrated Security=True");
        DataSet dts = new DataSet();

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
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ajouter_fourni_Load(object sender, EventArgs e)
        {
            SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.fourniseur", co);
            dts.Clear();
            dtp.Fill(dts, "Mesfournisseur");
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.fourniseur", co);
            dts.Clear();
            dtp.Fill(dts, "Mesfournisseur");

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                try
                {

                    DataRow ligne;
                    ligne = dts.Tables["Mesfournisseur"].NewRow();
                    ligne["nom_fournis"] = textBox1.Text;
                    ligne["prenom_fournis"] = textBox2.Text;
                    ligne["adresse_fournis"] = textBox7.Text;
                    ligne["tel_fournis"] = textBox3.Text;
                    ligne["pays_fournis"] = textBox6.Text;
                    ligne["ville"] = textBox5.Text;
                    ligne["email"] = textBox4.Text;


                    dts.Tables["Mesfournisseur"].Rows.Add(ligne);

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();




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
                SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.fourniseur", co);
                SqlCommandBuilder cmdbuild = new SqlCommandBuilder(dtp);
                dtp.Update(dts, "Mesfournisseur");
                MessageBox.Show("Bien Enregistrer");




                co.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Nom De Fourni")
            {
                textBox1.Text = "";

            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Prenom De Fourni")
            {
                textBox2.Text = "";

            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Telephon De Fourni")
            {
                textBox3.Text = "";

            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Email Fourni")
            {
                textBox4.Text = "";

            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {

            if (textBox5.Text == " Ville Fourni")
            {
                textBox5.Text = "";

            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Pays Du Fourni")
            {
                textBox6.Text = "";

            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {

            if (textBox7.Text == "  Adresse De Fourni")
            {
                textBox7.Text = "";

            }
        }
    }
}
