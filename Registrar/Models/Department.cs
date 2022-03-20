using System.Collections.Generic;

namespace Registrar.Models
{
    public class Department
    {
        public Department()
        {
            this.JoinEntities2 = new HashSet<CourseDepartment>();
        }
        public int DepartmentId {get; set;}
        public string Name { get; set; }
        public virtual ICollection<CourseDepartment> JoinEntities2 { get; }

        public virtual ICollection<DepartmentStudent> JoinEntities3 {get; }
    }
}