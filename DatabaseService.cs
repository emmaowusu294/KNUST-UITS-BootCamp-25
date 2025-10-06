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


        public List<string> GetAllEnrollmentsDetailed()
        {
            List<string> result = new List<string>();

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                            string sql = @"
                SELECT 
                    S.StudentID,
                    S.FirstName + ' ' + S.LastName AS StudentName,
                    C.CourseName,
                    T.FirstName + ' ' + T.LastName AS TeacherName,
                    T.Department,
                    CL.Schedule,
                    E.EnrollmentDate
                FROM ENROLLMENT E
                INNER JOIN STUDENT S ON E.StudentID = S.StudentID
                INNER JOIN COURSE C ON E.CourseID = C.CourseID
                INNER JOIN (
                    SELECT CourseID, MIN(Schedule) AS Schedule
                    FROM CLASS
                    GROUP BY CourseID
                ) CL ON C.CourseID = CL.CourseID
                INNER JOIN TEACHER T ON T.TeacherID = (
                    SELECT TOP 1 TeacherID FROM CLASS WHERE CLASS.CourseID = C.CourseID
                )
                ORDER BY S.StudentID;";


                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string student = reader["StudentName"].ToString();
                    string course = reader["CourseName"].ToString();
                    string teacher = reader["TeacherName"].ToString();
                    string dept = reader["Department"].ToString();
                    string schedule = reader["Schedule"].ToString();
                    string date = Convert.ToDateTime(reader["EnrollmentDate"]).ToShortDateString();

                    result.Add($"{student} is enrolled in '{course}' taught by {teacher} ({dept}) on {schedule} — enrolled on {date}");
                }

                reader.Close();
            }

            return result;
        }


        public void UpdateStudent(int id, string firstName, string lastName, int age)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string query = "UPDATE STUDENT SET FirstName=@FirstName, LastName=@LastName, Age=@Age WHERE StudentID=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "✅ Student updated successfully!" : "⚠️ Student not found.");
            }
        }

        // ❌ DELETE: Remove a student by ID
        public void DeleteStudent(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string query = "DELETE FROM STUDENT WHERE StudentID=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "🗑️ Student deleted successfully!" : "⚠️ Student not found.");
            }
        }

    }
}
