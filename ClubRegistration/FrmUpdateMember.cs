using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubRegistration
{
    public partial class FrmUpdateMember : Form
    {
        public FrmUpdateMember()
        {
            InitializeComponent();
        }
        string value;
        private ClubRegistrationQuery ClassRegQue;
        SqlCommand cmd;
        SqlDataReader rdr;

        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            Programcb.Items.Add ("BS Information Technology");
            Programcb.Items.Add ("BS Computer Science");
            Programcb.Items.Add ("BS Information Systems");
            Programcb.Items.Add ("BS in Accountancy");
            Programcb.Items.Add ("BS in Hospitality Management");
            Programcb.Items.Add ("BS in Tourism Management");
            Gendercb.Items.Add ("Female");
            Gendercb.Items.Add ("Male");

            ClassRegQue = new ClubRegistrationQuery();
            using (SqlConnection sqlConn = new SqlConnection(ClassRegQue.connectionString)) { 
                sqlConn.Open();
                string query = "SELECT StudentId From ClubMembers";
                cmd = new SqlCommand (query, sqlConn);
                rdr = cmd.ExecuteReader ();

                while (rdr.Read()) {
                    IDcb.Items.Add(rdr.GetValue(0));
                }
                rdr.Close();
                sqlConn.Close();
            }
            IDcb.SelectedIndex = 0;
        }

        private void IDcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            value = IDcb.SelectedItem.ToString();

            ClassRegQue = new ClubRegistrationQuery();

            using (SqlConnection sqlConn = new SqlConnection(ClassRegQue.connectionString))
            { 
                sqlConn.Open();
                string query = "SELECT * FROM ClubMembers WHERE StudentID = '" + value + "'";
                cmd = new SqlCommand (query, sqlConn);
                rdr = cmd.ExecuteReader ();

                while (rdr.Read())
                {
                    txtFirst.Text = " " + rdr.GetValue(2);
                    txtMiddle.Text = " " + rdr.GetValue(3);
                    txtLast.Text = " " + rdr.GetValue(4);
                    txtAge.Text = " " + rdr.GetValue(5);
                    Gendercb.Text = " " + rdr.GetValue(6);
                    Programcb.Text = " " + rdr.GetValue(7);
                }
                rdr.Close();
                sqlConn.Close();
            
            }
        }

        private void Confirmbtn_Click(object sender, EventArgs e)
        {
            ClassRegQue = new ClubRegistrationQuery();

            using (SqlConnection sqlConn = new SqlConnection(ClassRegQue.connectionString))
            { 
                sqlConn.Open();
                string updateQuery = "UPDATE ClubMembers SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, Age = @Age, Gender = @Gender, Program = @Program WHERE StudentId = '" + value + "'";
                cmd = new SqlCommand (updateQuery, sqlConn);
                cmd.Parameters.AddWithValue("@FirstName", txtFirst.Text);
                cmd.Parameters.AddWithValue("@MiddleName", txtMiddle.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLast.Text);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                cmd.Parameters.AddWithValue("@Gender", Gendercb.Text);
                cmd.Parameters.AddWithValue("@Program", Programcb.Text);
                cmd.ExecuteNonQuery();
                sqlConn.Close ();
                this.Dispose();

            }
        }
    }
}
