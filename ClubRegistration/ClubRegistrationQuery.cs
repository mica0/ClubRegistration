﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubRegistration
{
    internal class ClubRegistrationQuery
    {
        private SqlConnection sqlConnect = new SqlConnection();
        private SqlCommand sqlCommand = new SqlCommand();
        private SqlDataAdapter sqlAdapter = new SqlDataAdapter();
        private SqlDataReader sqlReader;

        public DataTable dataTable;
        public BindingSource bindingSource;

        public string connectionString;
        public string _FirstName, _MiddleName, _LastName, _Gender, _Program;
        public int _Age;

        
        public ClubRegistrationQuery()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\vcaga\OneDrive\Desktop\Micaela Files\3RD YR\Event\ClubRegistration\ClubRegistration\ClubDB.mdf"";Integrated Security=True";

            sqlConnect = new SqlConnection(connectionString);
            dataTable = new DataTable();
            bindingSource = new BindingSource();

        }
        public bool DisplayList()
        {
            string ViewClubMember = "SELECT StudentId, FirstName, MiddleName, LastName, Age, Gender, Program FROM ClubMembers";

            sqlAdapter = new SqlDataAdapter(ViewClubMember, sqlConnect);
            dataTable.Clear();
            sqlAdapter.Fill(dataTable);
            bindingSource.DataSource = dataTable;
            return true;
        }
        public bool RegisterStudent(int ID, long StudentID,
           string FirstName, string MiddleName, string LastName,
           int Age, string Gender, string Program)
        {
            using (sqlCommand = new SqlCommand(@"INSERT INTO ClubMembers 
                (ID, Studentid, FirstName, MiddleName, LastName, Age, Gender, Program) 
                VALUES(@ID, @StudentID, @FirstName, @MiddleName, 
                @LastName, @Age, @Gender, @Program)", sqlConnect))
            {
                sqlConnect.ConnectionString = connectionString;
                sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                sqlCommand.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = StudentID;
                sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
                sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = MiddleName;
                sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
                sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
                sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = Gender;
                sqlCommand.Parameters.Add("@Program", SqlDbType.VarChar).Value = Program;

                sqlConnect.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();

                return true;

            }

        }
    }
}
