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
    public partial class stock : Form
    {
        public stock()
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

        BindingManagerBase BmbBq;
        Boolean BL = false;

        private void stock_Load(object sender, EventArgs e)
        {
            SqlDataAdapter dtp = new SqlDataAdapter("Select * from stock", co);

            dtp.Fill(dts, "Messtock");

            SqlDataAdapter dtp2 = new SqlDataAdapter("select * from dbo.fourniseur", co);
            DataSet dt2 = new DataSet();

            dtp2.Fill(dt2, "Mesfournisseur");


            try
            {
                comboBox1.DisplayMember = "codeFr";
                comboBox1.ValueMember = "codeFr";
                comboBox1.DataSource = dt2.Tables["Mesfournisseur"];


            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
            BmbBq = this.BindingContext[dts.Tables["Messtock"]];
            textBox20.DataBindings.Add("Text", dts.Tables["Messtock"], "code");
            textBox19.DataBindings.Add("Text", dts.Tables["Messtock"], "QtéEntrer");
            textBox18.DataBindings.Add("text", dts.Tables["Messtock"], "QtéSorti");
            dateTimePicker1.DataBindings.Add("text", dts.Tables["Messtock"], "dateLivraison");
            textBox1.DataBindings.Add("text", dts.Tables["Messtock"], "dateSorti");
            comboBox1.DataBindings.Add("text", dts.Tables["Messtock"], "codeFr");

            dataGridView3.DataSource = dts.Tables["Messtock"];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BmbBq.AddNew();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BmbBq.EndCurrentEdit();
            BL = true;
            dataGridView3.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BmbBq.EndCurrentEdit();
            BL = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BmbBq.RemoveAt(BmbBq.Position);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dtp = new SqlDataAdapter("Select * from stock", co);

            dtp.Fill(dts, "Messtock");
            if (BL)
            {
                DialogResult rep = MessageBox.Show("Voulez vous Appliquer les mis à jours à la source de données", "Comfirmation Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rep == DialogResult.Yes)
                {
                    SqlCommandBuilder Bld = new SqlCommandBuilder(dtp);
                    dtp.Update(dts.Tables["Messtock"]);
                    this.Close();
                    
                }
            }
            this.Close();
        }

        private void bunifuGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            BmbBq.AddNew();

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            BmbBq.EndCurrentEdit();
            BL = true;
            dataGridView3.Refresh();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

            BmbBq.EndCurrentEdit();
            BL = true;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            BmbBq.RemoveAt(BmbBq.Position);
        }
    }
}
