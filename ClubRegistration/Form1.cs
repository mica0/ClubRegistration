using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubRegistration
{
    public partial class FrmClubRegistration : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;
        private long StudentId;

    public void RefreshListOfClubMembers() 
        {
            
                clubRegistrationQuery.DisplayList();
            if (Membersdatagrid != null) 
            {
                Membersdatagrid.DataSource = clubRegistrationQuery.bindingSource;
            }
               
            
        }
    private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[] {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };
            try
            {
                if (ListOfProgram.Length == 6)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        Programcb.Items.Add(ListOfProgram[i].ToString());
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (IndexOutOfRangeException p)
            {
                MessageBox.Show(p.Message);

            }
            string[] ListOfGender = new string[]
                {
                    "Female",
                    "Male"
                };
            for (int i = 0; i < 2; i++)
            {
                Gendercb.Items.Add(ListOfGender[i].ToString());
            }
            RefreshListOfClubMembers();



        }

        private void Registerbtn_Click(object sender, EventArgs e)
        {
            ID = RegistrationID();
            StudentId = Convert.ToInt64(txtID.Text);
            FirstName = txtFirst.Text;
            MiddleName = txtMiddle.Text;
            LastName = txtLast.Text;
            Age = Convert.ToInt32(txtAge.Text);
            Gender = Gendercb.Text;
            Program = Programcb.Text;

            clubRegistrationQuery.RegisterStudent(ID, StudentId, FirstName, MiddleName, LastName, Age, Gender, Program);
            Clear();
            RefreshListOfClubMembers();
        }
    private void Updatebtn_Click(object sender, EventArgs e)
        {
            FrmUpdateMember update = new FrmUpdateMember();
            update.ShowDialog();
        }


        public FrmClubRegistration()
        {
            clubRegistrationQuery = new ClubRegistrationQuery();
            RefreshListOfClubMembers();

            InitializeComponent();

        }
        
        private void Refreshbtn_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

        
        public int RegistrationID() { 
            count++;
            return count;   
        }

        public void Clear()
        {
            txtID.Clear();
            txtFirst.Clear();
            txtMiddle.Clear();
            txtLast.Clear();
            txtAge.Clear();
            Gendercb.SelectedIndex = -1;
            Programcb.SelectedIndex = -1;
        }


    }
}
