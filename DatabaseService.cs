using System;
using System.Data.SqlClient;

namespace BootCamp25
{
    public class DatabaseService
    {
        private string _connStr;

        public DatabaseService()
        {
            // Use @ string literal to avoid escape sequence issues
            _connStr = @"Server=4TS\SQLEXPRESS;Database=SCHOOL;Trusted_Connection=True";
        }

        // Add a new Student
        public int AddStudent(string fname, string lname, int age)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string sql = @"INSERT INTO STUDENT (FirstName, LastName, Age) 
                               VALUES (@fname, @lname, @age);";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@age", age);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        // Add a new Course
        public int AddCourse(string courseName, int credits)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string sql = @"INSERT INTO COURSE (CourseName, Credits) 
                               VALUES (@cname, @credits);";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cname", courseName);
                cmd.Parameters.AddWithValue("@credits", credits);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Add a new Teacher
        public int AddTeacher(string fname, string lname, string department)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string sql = @"INSERT INTO TEACHER (FirstName, LastName, Department) 
                               VALUES (@fname, @lname, @dept);";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@dept", department);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Enroll a student in a course
        public int EnrollStudent(int studentId, int courseId)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string sql = @"INSERT INTO ENROLLMENT (StudentID, CourseID) 
                               VALUES (@sid, @cid);";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sid", studentId);
                cmd.Parameters.AddWithValue("@cid", courseId);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Add a Class (assign a teacher to a course)
        public int AddClass(int courseId, int teacherId, string schedule)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string sql = @"INSERT INTO CLASS (CourseID, TeacherID, Schedule) 
                       VALUES (@courseId, @teacherId, @schedule);";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@courseId", courseId);
                cmd.Parameters.AddWithValue("@teacherId", teacherId);
                cmd.Parameters.AddWithValue("@schedule", schedule);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }


        //NOW RETRIEVE DATA

        public void GetAllStudents()
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string sql = "SELECT StudentID, FirstName, LastName, Age FROM STUDENT";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\n📋 List of Students:");
                Console.WriteLine("-----------------------------------");

                while (reader.Read())
                {
                    int id = (int)reader["StudentID"];
                    string fname = reader["FirstName"].ToString();
                    string lname = reader["LastName"].ToString();
                    int age = (int)reader["Age"];

                    Console.WriteLine($"ID: {id} | Name: {fname} {lname} | Age: {age}");
                }

                reader.Close();
            }
        }


    }
}
