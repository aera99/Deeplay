using System.Collections.Generic;

namespace DeePlayTZ.Model.Data.Entitys
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Employee> Employees { get; set; } = new();

        public override string ToString()
        {
            return Name;
        }
    }
}
