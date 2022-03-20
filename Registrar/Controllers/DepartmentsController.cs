using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using System.Collections.Generic;
using System.Linq;

namespace Registrar.Controllers
{
  public class DepartmentsController : Controller
  {
    private readonly RegistrarContext _db;

    public DepartmentsController(RegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Department> model = _db.Department.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Department department)
    {
      _db.Department.Add(department);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisDepartment = _db.Department
        .Include(department => department.JoinEntities2)
        .ThenInclude(join => join.Course)
        .Include(department => department.JoinEntities3)
        .ThenInclude(join => join.Student)
        .FirstOrDefault(department => department.DepartmentId == id);
      return View(thisDepartment);
    }
    public ActionResult Edit(int id)
    {
      var thisDepartment = _db.Department.FirstOrDefault(department => department.DepartmentId == id);
      return View(thisDepartment);
    }

    [HttpPost]
    public ActionResult Edit(Department department)
    {
      _db.Entry(department).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddCourse(int id)
    {
      var thisDepartment = _db.Department.FirstOrDefault(department => department.DepartmentId == id);
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
      return View(thisDepartment);
    }

    [HttpPost]
    public ActionResult AddCourse(Department department, int CourseId)
    {
      if (CourseId != 0)
      {
        _db.CourseDepartment.Add(new CourseDepartment() { CourseId = CourseId, DepartmentId = department.DepartmentId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

        public ActionResult AddStudent(int id)
    {
      var thisDepartment = _db.Department.FirstOrDefault(department => department.DepartmentId == id);
      ViewBag.StudentId = new SelectList(_db.Students, "StudentId", "Name");
      return View(thisDepartment);
    }

    [HttpPost]
    public ActionResult AddStudent(Department department, int StudentId)
    {
      if (StudentId != 0)
      {
        _db.DepartmentStudent.Add(new DepartmentStudent() { StudentId = StudentId, DepartmentId = department.DepartmentId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisDepartment = _db.Department.FirstOrDefault(department => department.DepartmentId == id);
      return View(thisDepartment);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDepartment = _db.Department.FirstOrDefault(department => department.DepartmentId == id);
      _db.Department.Remove(thisDepartment);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}