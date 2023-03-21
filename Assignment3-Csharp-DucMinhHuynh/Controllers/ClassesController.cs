using Assignment3_Csharp_DucMinhHuynh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3_Csharp_DucMinhHuynh.Controllers
{
    public class ClassesController : Controller
    {
        // GET: Classes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            ClassDataController classData  = new ClassDataController();
            IEnumerable<Classes> classes = classData.ListClasses();
            return View(classes);
        }

        public ActionResult Details(int id)
        {
            ClassDataController classData = new ClassDataController();
            Classes newclasses = classData.FindClasses(id);
            return View(newclasses);
        }
    }
}