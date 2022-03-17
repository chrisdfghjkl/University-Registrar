using System.Collections.Generic;
using System;

namespace Registrar.Models
{
    public class Student
    {
        public Student()
        {
            this.JoinEntities = new HashSet<CourseStudent>();
            this.JoinEntities2 = new HashSet<CourseDepartmentStudent>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }

        public virtual ICollection<CourseStudent> JoinEntities { get;}
        public virtual ICollection<CourseDepartmentStudent> JoinEntities2 { get; set; }
    }
}