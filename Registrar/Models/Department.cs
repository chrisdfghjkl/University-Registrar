using System.Collections.Generic;

namespace Registrar.Models
{
    public class Department
    {
        public Department()
        {
            this.JoinEntities2 = new HashSet<CourseDepartmentStudent>();
        }
        public int DepartmentId {get; set;}
        public string Name { get; set; }
        public virtual ICollection<CourseDepartmentStudent> JoinEntities2 { get; }
    }
}