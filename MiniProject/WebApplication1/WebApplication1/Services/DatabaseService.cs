using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleApp2
{
    public class DatabaseService
    {
        string _connStr;

        public DatabaseService()
        {
            _connStr = @"Server=4TS\SQLEXPRESS;Database=School;Trusted_Connection=True;TrustServerCertificate=True";
        }

        public void AddStudent(string fname, string lname,
            char gender, DateOnly birthDate)
        {
            SqlConnection conn = new SqlConnection(_connStr);
            string sql = @"INSERT INTO Student (FirstName, LastName, Gender, BirthDate) 
                            VALUES (@fname, @lname, @gender, @bdate)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@bdate", birthDate);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine("Student added successfully");
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            SqlConnection conn = new SqlConnection(_connStr);
            string sql = "SELECT * FROM Student";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Student temp = new Student();
                temp.StudentId = reader.GetInt32(0);
                temp.FirstName = reader.GetString(1);
                temp.LastName = reader.GetString(2);
                temp.Gender = reader.GetString(3)[0];
                temp.BirthDate = DateOnly.FromDateTime(reader.GetDateTime(4));

                students.Add(temp);
            }

            conn.Close();

            return students;


        }
    }

    public class Student
    {
        public int? StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public Char Gender{ get; set; }
        public DateOnly BirthDate{ get; set; }
    }
}
