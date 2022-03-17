using System.Collections.Generic;

namespace Registrar.Models
{
    public class Course
    {
        public Course()
        {
            this.JoinEntities = new HashSet<CourseStudent>();
            this.JoinEntities2 = new HashSet<CourseDepartmentStudent>();
        }

        public int CourseId { get; set; }
        public string Name { get; set; }
        public string CourseNumber { get; set; }
        public virtual ICollection<CourseStudent> JoinEntities { get; set; }
        public virtual ICollection<CourseDepartmentStudent> JoinEntities2 { get; set; }
        
    }
}