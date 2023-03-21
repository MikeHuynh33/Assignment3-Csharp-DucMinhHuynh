using Assignment3_Csharp_DucMinhHuynh.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace Assignment3_Csharp_DucMinhHuynh.Controllers
{
    
    public class StudentDataController : ApiController
    {

        private SchoolDbContext teacherDb = new SchoolDbContext();

        [HttpGet]
        [Route("api/StudentData/ListStudents")]
        public IEnumerable<Student> ListStudents()
        {
            //create instance of connection
            MySqlConnection connection = teacherDb.AccessDatabase();
            // open connection between server and database
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            // implementing SQL in command
            command.CommandText = "SELECT * FROM students ";
            // Collecting all result from database server 
            MySqlDataReader result = command.ExecuteReader();
            //Create an empty List of Teacher;
            List<Student> studentData = new List<Student> { };
            // Create loop to go through line by line of result;

            while(result.Read())
            {
                // extract data from database into temp variable             
                string f_name = (string)result["studentfname"];
                string l_name = (string)result["studentlname"];
                DateTime date = (DateTime)result["enroldate"];
                string s_number = (string)result["studentnumber"];
                ////// convert temp variables into Models Teacher Object
                Student newstudent = new Student();
                newstudent.studentFName = f_name;
                newstudent.studentLName = l_name;
                newstudent.studentNumber = s_number;
                newstudent.enrolDate = date;
                // add each row of data from database into each objects in List
                studentData.Add(newstudent);
            }
            //close connection with database
            connection.Close();
            return studentData;
        }
        [HttpGet]
        [Route("api/StudentData/Findstudent/{studentName}")]
        public Student Findstudent(string studentName)
        {
            //create instance of connection
            MySqlConnection connection = teacherDb.AccessDatabase();
            // open connection between server and database
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            // implementing SQL in command;
            command.CommandText = "SELECT * FROM students Where lower(studentfname) LIKE lower(@keyinput)";
            command.Parameters.AddWithValue("@keyinput", "%" + studentName + "%");
            // Collecting all result from database server; 
            MySqlDataReader result = command.ExecuteReader();      
            Student newstudent = new Student();
            //Create an empty List of Teacher;
            while (result.Read())
            {
                // extract data from database into temp variable             
                string f_name = (string)result["studentfname"];
                string l_name = (string)result["studentlname"];
                DateTime date = (DateTime)result["enroldate"];
                string s_number = (string)result["studentnumber"];
                // convert temp variables into Models Teacher Object
                newstudent.studentFName = f_name;
                newstudent.studentLName = l_name;
                newstudent.studentNumber = s_number;
                newstudent.enrolDate = date;
            }
            //close connection with database
            connection.Close();
            return (newstudent);
        }
    }
}
