using CumulativeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CumulativeProject.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// creates object of teacherDatacontroller class and access the value of teacher.
        /// </summary>
        /// <param name="serchkey">it takes the value from dynamically from form element in list.cshtml page.</param>
        /// <returns>returns teachers maching with serch and if not provided the serch key it will display whole list of teachers vailable in the database</returns>
        public ActionResult List(string serchkey = null)
        {

            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> teachers =  controller.ListTeacher(serchkey);


            return View(teachers);
        }
        /// <summary>
        /// it itakes the id value provided from ancor tag in the list.cshtml page and displyaes the data based on that. it takes
        /// the id and sends it to findteacher function using teacherdata controler which provides the data of teacher and it now returns to the 
        /// show.cshtml page.
        /// </summary>
        /// <param name="id">teaks id of teacher</param>
        /// <returns>data of the teacher based on id.</returns>
        public ActionResult Show(int id = -1)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }
    }
}