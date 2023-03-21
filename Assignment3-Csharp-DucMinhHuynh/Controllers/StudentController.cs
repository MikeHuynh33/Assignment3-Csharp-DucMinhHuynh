using Assignment3_Csharp_DucMinhHuynh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment3_Csharp_DucMinhHuynh.Controllers;
public class StudentController : Controller
 {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            StudentDataController studentDataController = new StudentDataController();
            IEnumerable<Student> Studentdatas = studentDataController.ListStudents();
            
            return View(Studentdatas);
        }
          
        public ActionResult Details(string StudentName = null)
        {
            StudentDataController studentDataController = new StudentDataController();
            Student data = studentDataController.Findstudent(StudentName);
            return View(data);  
        }
 }
