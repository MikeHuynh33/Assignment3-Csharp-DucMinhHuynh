using Assignment3_Csharp_DucMinhHuynh.Controllers;
using Assignment3_Csharp_DucMinhHuynh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class TeacherController : Controller
{
    // GET: Teacher
    public ActionResult Index()
    {
        return View();
    }

    // GET: Teacher/List
    public ActionResult List(string SearchKey = null)
    {
        TeacherDataController controller = new TeacherDataController();
        IEnumerable<Teacher> Teachers = controller.ListTeacher(SearchKey);
        return View(Teachers);
    }

    public ActionResult Show(int id) {
        TeacherDataController controller = new TeacherDataController();
        Teacher teacher = controller.FindTeacher(id);
        return View(teacher);
    }
}