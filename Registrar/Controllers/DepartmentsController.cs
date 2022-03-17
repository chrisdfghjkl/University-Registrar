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