using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationSchoolTp4.Models;
using WebApplicationSchoolTp4.Models.Repositories;

namespace WebApplicationSchoolTp4.Controllers
{

    public class TeacherController : Controller
    {
        readonly ITeacherRepository teacherrepository;
        readonly ISchoolRepository schoolrepository;
        public TeacherController(ITeacherRepository teacherrepository, ISchoolRepository schoolrepository)
        {
            this.teacherrepository = teacherrepository;
            this.schoolrepository = schoolrepository;
        }
        // GET: StudentController
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.SchoolID = new SelectList(schoolrepository.GetAll(), "SchoolID", "SchoolName");
            return View(teacherrepository.GetAll());
        }
        public ActionResult Search(string name, int? schoolid)
        {
            var result = teacherrepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = teacherrepository.FindByName(name);
            else
            if (schoolid != null)
                result = teacherrepository.GetTeachersBySchoolID(schoolid);
            ViewBag.SchoolID = new SelectList(schoolrepository.GetAll(), "SchoolID", "SchoolName");
            return View("Index", result);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(teacherrepository.GetById(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.SchoolID = new SelectList(schoolrepository.GetAll(), "SchoolID", "SchoolName");
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher t)
        {
            try
            {
                ViewBag.SchoolID = new SelectList(schoolrepository.GetAll(), "SchoolID", "SchoolName", t.SchoolID);
                teacherrepository.Add(t);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SchoolID = new SelectList(schoolrepository.GetAll(), "SchoolID", "SchoolName");
            return View(teacherrepository.GetById(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher t)
        {
            try
            {
                ViewBag.SchoolID = new SelectList(schoolrepository.GetAll(), "SchoolID", "SchoolName");
                teacherrepository.Edit(t);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(teacherrepository.GetById(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Teacher t)
        {
            try
            {
                teacherrepository.Delete(t);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
