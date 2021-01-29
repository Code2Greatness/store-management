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
    public partial class DetailCmd : Form
    {
        public DetailCmd()
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
        DataSet dts = new DataSet();

        private void DetailCmd_Load(object sender, EventArgs e)
        {

            SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.commande", co);
            dtp.Fill(dts, "Mescommande");

            SqlDataAdapter dtp2 = new SqlDataAdapter("select * from dbo.produit", co);
            DataSet dt = new DataSet();
            dt.Clear();
            dtp2.Fill(dt, "Mesproduit");


            try
            {
                comboBox1.DisplayMember = "NumCom";
                comboBox1.ValueMember = "NumCom";
                comboBox1.DataSource = dts.Tables["Mescommande"];

                comboBox2.DisplayMember = "id_produit";
                comboBox2.ValueMember = "id_produit";
                comboBox2.DataSource = dt.Tables["Mesproduit"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.detail", co);
   
            dts.Clear();
            dtp.Fill(dts, "Mesdetail");

            if (textBox1.Text != "")
            {
                try
                {
                    DataRow ligne;
                    ligne = dts.Tables["Mesdetail"].NewRow();

                    ligne["NumCom"] = comboBox1.SelectedValue;
                    ligne["id_produit"] = comboBox2.SelectedValue;
                    ligne["Qte"] = textBox1.Text;

                    dts.Tables["Mesdetail"].Rows.Add(ligne);

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
            SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.detail", co);
          
            dts.Clear();
            dtp.Fill(dts, "Mesdetail");

            try
            {


                SqlCommandBuilder cmd = new SqlCommandBuilder(dtp);
                dtp.Update(dts.Tables["Mesdetail"]);
                MessageBox.Show("Bien Enregistrer");
                this.Close();


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
