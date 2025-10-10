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
            _connStr = @"Server=4TS\SQLEXPRESS;Database=School;Trusted_Connection=True;TrustServerCertificate=True";
        }

        // 🔹 ADD STUDENT
        public void AddStudent(string fname, string lname, char gender, DateOnly birthDate)
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

            Console.WriteLine("✅ Student added successfully");
        }

        // 🔹 UPDATE STUDENT
        public void UpdateStudent(int id, string fname, string lname, char gender, DateOnly birthDate)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string sql = @"UPDATE Student 
                               SET FirstName = @fname, LastName = @lname, Gender = @gender, BirthDate = @bdate 
                               WHERE StudentId = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@bdate", birthDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine(" Student updated successfully");
        }

        // 🔹 GET ALL STUDENTS
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
                    Student temp = new Student()
                    {
                        StudentId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Gender = reader.GetString(3)[0],
                        BirthDate = DateOnly.FromDateTime(reader.GetDateTime(4))
                    };

                    students.Add(temp);
                }
            }

            return students;
        }

        // 🔹 GET STUDENT BY ID
        public Student GetStudentById(int id)
        {
            Student student = null;

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string sql = "SELECT * FROM Student WHERE StudentId = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    student = new Student()
                    {
                        StudentId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Gender = reader.GetString(3)[0],
                        BirthDate = DateOnly.FromDateTime(reader.GetDateTime(4))
                    };
                }
            }

            return student;
        }

        //DELETE STUDENTS

        public void DeleteStudent(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string sql = @"DELETE FROM Student WHERE StudentId = @StudentId";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@StudentId", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("Student deleted successfully");
        }

        // Year Filter
        public List<Student> FilterStudents(int year)
        {
            List<Student> students = new List<Student>();

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string sql = "SELECT * FROM Student Where YEAR(BIRTHDATE) > @year";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@year", year);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Student temp = new Student()
                    {
                        StudentId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Gender = reader.GetString(3)[0],
                        BirthDate = DateOnly.FromDateTime(reader.GetDateTime(4))
                    };

                    students.Add(temp);
                }
            }

            return students;
        }

        public List<StudentScores> GetStudentsScores()
        {
            List<StudentScores> scores = new List<StudentScores>();

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string sql = @"select st.STUDENTID, st.FIRSTNAME, st.LASTNAME,
                              cs.COURSENAME, sc.MARK, sc.GRADE
                                from student st
                                join SCORES sc on st.STUDENT = sc.STUDENTID
                                join COURSE cs on sc.COURSEID = cs.COURSEID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    StudentScores temp = new StudentScores()
                    {
                        StudentId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Course = reader.GetString(3),
                        Mark = reader.GetDecimal(4),
                        Grade = reader.GetString(5)
                    };

                    scores.Add(temp);
                }
            }

            return scores;
        }
    }



    // 🔹 STUDENT MODEL
    public class Student
    {
        public int? StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateOnly BirthDate { get; set; }
    }

    public class StudentScores
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }
        public decimal Mark { get; set; }
        public string Grade { get; set; }
    }
}
