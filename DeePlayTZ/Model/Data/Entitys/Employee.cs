using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeePlayTZ.Model.Data.Entitys
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public char Sex { get; set; }
        [ForeignKey("Position")]
        public int PositionId { get; set; }
        public Position? Position { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        [NotMapped]
        public Position EmployeePosition
        {
            get => DataBaseTools.GetPositionById(PositionId);
        }
        [NotMapped]
        public Department EmployeeDepartment
        {
            get => DataBaseTools.GetDepartmentById(DepartmentId);
        }
        [NotMapped]
        public string UniqueInformation
        {
            get => DataBaseTools.GetUniqueInformation(this);
        }
        [NotMapped]
        public string FullName
        {
            get => $"{FirstName} {LastName} {MiddleName}";
        }
    }
}
