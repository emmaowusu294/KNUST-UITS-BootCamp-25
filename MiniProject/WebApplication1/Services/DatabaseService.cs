using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace ConsoleApp2
{
    public class DatabaseService
    {
        string _connStr;

        public DatabaseService()
        {
            _connStr = @"Server=4TS\SQLEXPRESS;Database=SCHOOL;Trusted_Connection=True;TrustServerCertificate=True";
        }

        public void AddStudent(string fname, string lname, char gender, DateTime birthDate)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string sql = @"INSERT INTO Student (FirstName, LastName, Gender, BirthDate)
                               VALUES (@fname, @lname, @gender, @bdate)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@bdate", birthDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("✅ Student added successfully!");
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string sql = "SELECT * FROM Student";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        StudentId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Gender = Convert.ToChar(reader.GetString(3)),
                        BirthDate = reader.GetDateTime(4)
                    });
                }
            }

            return students;
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
