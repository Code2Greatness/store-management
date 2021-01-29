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
    public partial class AJOUTER_MODIFIER_CLIENT : Form
    {
       

        public AJOUTER_MODIFIER_CLIENT()
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
        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void AJOUTER_MODIFIER_CLIENT_Load(object sender, EventArgs e)
        {
            SqlDataAdapter dtp = new SqlDataAdapter("select codecl,nom_client,prenom_client,adresse_client,tel_client,pays_client,ville, email from dbo.Client", co);
            dts.Clear();
            dtp.Fill(dts, "MesClients");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Nom De Client")
            {
                textBox1.Text = "";

            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Prenom De Client")
            {
                textBox2.Text = "";

            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "Adresse De Client")
            {
                textBox7.Text = "";

            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Email Client")
            {
                textBox4.Text = "";

            }
        }



        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Ville Client")
            {
                textBox5.Text = "";

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Pays Du Client")
            {
                textBox6.Text = "";

            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            
            if (textBox3.Text == "Telephone De Client")
            {
                textBox3.Text = "";

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Nom De Client";

            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Prenom De Client";

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Telephone De Client";

            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "Adresse De Client";

            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Email Client";

            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Ville Client";

            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "Pays Du Client";

            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                co.Open();
                SqlDataAdapter dtp = new SqlDataAdapter("select codecl,nom_client,prenom_client,adresse_client,tel_client,pays_client,ville, email from dbo.Client", co);
                SqlCommandBuilder cmdbuild = new SqlCommandBuilder(dtp);
                dtp.Update(dts, "MesClients");
                MessageBox.Show("Bien Enregistrer");
              
           
              

                co.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dtp = new SqlDataAdapter("select codecl,nom_client,prenom_client,adresse_client,tel_client,pays_client,ville, email from dbo.Client", co);
            dts.Clear();
            dtp.Fill(dts, "MesClients");

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                try
                {

                    DataRow ligne;
                    ligne = dts.Tables["MesClients"].NewRow();
                    ligne["nom_client"] = textBox1.Text;
                    ligne["prenom_client"] = textBox2.Text;
                    ligne["adresse_client"] = textBox7.Text;
                    ligne["tel_client"] = textBox3.Text;
                    ligne["pays_client"] = textBox6.Text;
                    ligne["ville"] = textBox5.Text;
                    ligne["email"] = textBox4.Text;
                   
                   
                    dts.Tables["MesClients"].Rows.Add(ligne);

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
    }
}
