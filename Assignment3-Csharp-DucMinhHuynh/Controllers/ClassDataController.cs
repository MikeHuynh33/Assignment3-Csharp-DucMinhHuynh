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
    public class ClassDataController : ApiController
    {
        private SchoolDbContext teacherDb = new SchoolDbContext();

        [HttpGet]
        [Route("api/ClassData/ListClasses")]
        public IEnumerable<Classes> ListClasses()
        {
            MySqlConnection connection = teacherDb.AccessDatabase();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM classes ";
            MySqlDataReader result = command.ExecuteReader();
            List <Classes> ClassesData = new List<Classes> { };

            while(result.Read())
            {
                int id = (int)result["classid"];
                string classCode = (string)result["classcode"];
                DateTime startdate = (DateTime)result["startdate"];
                DateTime enddate = (DateTime)result["finishdate"];
                string classname = (string)result["classname"];

                Classes newclass = new Classes();

                newclass.classid = id;
                newclass.classname = classname;
                newclass.startdate = startdate;
                newclass.enddate = enddate;
                newclass.classcode = classCode;

                ClassesData.Add(newclass);
            }
            connection.Close();
            return ClassesData;
        }
        [HttpGet]
        [Route("api/ClassData/FindClasses/{id}")]
        public Classes FindClasses(int id)
        {
            MySqlConnection connection = teacherDb.AccessDatabase();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM classes where classid = " + id ;
            MySqlDataReader result = command.ExecuteReader();
            Classes newclass = new Classes();

            while(result.Read())
            {
                int class_id = (int)result["classid"];
                string classCode = (string)result["classcode"];
                DateTime startdate = (DateTime)result["startdate"];
                DateTime enddate = (DateTime)result["finishdate"];
                string classname = (string)result["classname"];
                newclass.classid = class_id;
                newclass.classname = classname;
                newclass.startdate = startdate;
                newclass.enddate = enddate;
                newclass.classcode = classCode;

            }
            connection.Close();
            return newclass;
        }
    }
}
