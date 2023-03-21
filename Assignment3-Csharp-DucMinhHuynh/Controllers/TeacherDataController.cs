using Assignment3_Csharp_DucMinhHuynh.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using System.Web.Routing;

namespace Assignment3_Csharp_DucMinhHuynh.Controllers
{
    public class TeacherDataController : ApiController
    {
        private SchoolDbContext teacherDb = new SchoolDbContext();

        [HttpGet]
        [Route("api/TeacherData/ListTeacher/{searchKey?}")]
        public IEnumerable<Teacher> ListTeacher(string SearchKey = null)
        {
            //create instance of connection
            MySqlConnection connection = teacherDb.AccessDatabase();
            // open connection between server and database
            connection.Open();
            // establish a new cmd (query) for database
            MySqlCommand command = connection.CreateCommand();
            // implementing SQL in command
            command.CommandText = "SELECT * FROM teachers " +
                      "WHERE lower(teacherfname) LIKE lower(@inputkey) " +
                      "OR lower(teacherlname) LIKE lower(@inputkey) " +
                      "OR lower(concat(teacherfname, ' ', teacherlname)) LIKE lower(@inputkey) " +
                      "OR hiredate = @inputkeydate " +
                      "OR salary = @inputkeysal ";
            // AddWithValue method helps prevent SQL injection attacks and ensures that the values passed to the query are properly formatted and escaped.
            command.Parameters.AddWithValue("@inputkey", "%" + SearchKey + "%");
            command.Parameters.AddWithValue("@inputkeydate",  SearchKey );
            command.Parameters.AddWithValue("@inputkeysal", SearchKey);
            // Collecting all result from database server 
            MySqlDataReader result = command.ExecuteReader();
            //Create an empty List of Teacher;
            List<Teacher> teacherData = new List<Teacher> { };
            // Create loop to go through line by line of result;

            while(result.Read())
            {
                // extract data from database into temp variable
                int list_id = (int)result["teacherid"];
                string f_name = (string)result["teacherfname"];
                string l_name = (string)result["teacherlname"];
                DateTime hiring = (DateTime)result["hiredate"];
                Decimal sal = (Decimal)result["salary"];   
                // convert temp variables into Models Teacher Object
                Teacher Newteachers = new Teacher();
                Newteachers.teacherid = list_id;
                Newteachers.teacherfname = f_name;
                Newteachers.teacherlname = l_name;
                Newteachers.hiredate = hiring;
                Newteachers.salary= sal;
                // add each row of data from database into each objects in List
                teacherData.Add(Newteachers);

            }
            //close connection with database
            connection.Close();
            return teacherData;
        }

        [HttpGet]
        [Route("api/TeacherData/FindTeacher/{id}")]
        public Teacher FindTeacher(int id)
        {
            Teacher Newteacher = new Teacher();
            //create instance of connection
            MySqlConnection connection = teacherDb.AccessDatabase();
            // open connection between server and database
            connection.Open();
            // establish a new cmd (query) for database
            MySqlCommand command = connection.CreateCommand();
            // implementing SQL in command
            command.CommandText = "SELECT t.* , cl.classname FROM teachers t \r\n Right Join classes cl On cl.teacherid = t.teacherid \r\n WHERE t.teacherid = " + id;
          
            // Collecting all result from database server 
            MySqlDataReader result = command.ExecuteReader();
            //Create an empty List of Teacher;
            while (result.Read())
            {
                int find_id = (int)result["teacherid"];
                string f_name = (string)result["teacherfname"];
                string l_name = (string)result["teacherlname"];
                DateTime hiring = (DateTime)result["hiredate"];
                Decimal sal = (Decimal)result["salary"];
                string course = (string)result["classname"];
                Newteacher.teacherid = find_id;
                Newteacher.teacherfname = f_name;
                Newteacher.teacherlname = l_name;
                Newteacher.hiredate = hiring;
                Newteacher.salary = sal;
                Newteacher.coursetaught = course;
            }
            connection.Close();
            return Newteacher;
        }
    }
}
