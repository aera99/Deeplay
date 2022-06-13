using DeePlayTZ.Model.Data.ContextFolder;
using DeePlayTZ.Model.Data.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace DeePlayTZ.Model.Data
{
    public static class DataBaseTools
    {
        #region получение коллекций
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new();
            using (var db = new DataContext())
            {
                employees = db.Employees.ToList();
            }
            return employees;
        }
        public static List<Position> GetPositions()
        {
            List<Position> positions = new();
            using (var db = new DataContext())
            {
                positions = db.Positions.ToList();
            }
            return positions;
        }
        public static List<Department> GetDepartments()
        {
            List<Department> departments = new();
            using (var db = new DataContext())
            {
                departments = db.Departments.ToList();
            }
            return departments;
        }
        // получение коллекции по выбранной должности/отдела
        public static List<Employee> GetEmployeesByPosition(Position position)
        {
            List<Employee> employees = new();
            if (position != null)
            {
                using (var db = new DataContext())
                {
                    var empl = db.Employees.Where(e => e.PositionId == position.Id);
                    if (empl != null) return employees = empl.ToList();
                }
            }
            return employees;
        }
        public static List<Employee> GetEmployeesByDepartment(Department department)
        {
            List<Employee> employees = new();
            if (department != null)
            {
                using (var db = new DataContext())
                {
                    var empl = db.Employees.Where(e => e.DepartmentId == department.Id);
                    if (empl != null) return employees = empl.ToList();
                }
            }
            return employees;
        }
        #endregion
        public static void AddDepartment(Department department)
        {
            if (department != null)
            {
                using (var db = new DataContext())
                {
                    db.Departments.Add(department);
                    db.SaveChanges();
                }
            }
        }
        public static void AddPosition(Position position)
        {
            if (position != null)
            {
                using (var db = new DataContext())
                {
                    db.Positions.Add(position);
                    db.SaveChanges();
                }
            }
        }
        public static void AddEmployee(Employee oldEmployee)
        {
            if (oldEmployee != null)
            {
                using (var db = new DataContext())
                {
                    Position pos = db.Positions.FirstOrDefault(p => p.Id == oldEmployee.Position.Id);
                    Department dep = db.Departments.FirstOrDefault(p => p.Id == oldEmployee.Department.Id);
                    oldEmployee.Department = dep;
                    oldEmployee.Position = pos;
                    db.Employees.Add(oldEmployee);
                    db.SaveChanges();
                }
            }
        }
        public static void DeleteEmployee(Employee employee)
        {
            if (employee != null)
            {
                using (var db = new DataContext())
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                }
            }
        }
        public static void PromotionEmployee(Employee employee)
        {
            using (var db = new DataContext())
            {
                if (employee != null && employee.PositionId != 1)
                {
                    employee.PositionId -= 1;
                    db.Employees.Update(employee);
                    db.SaveChanges();
                }
            }
        }
        public static void UpdateEmployee(Employee oldEmployee)
        {
            if (oldEmployee != null)
            {
                using (var db = new DataContext())
                {
                    Employee employee = db.Employees.FirstOrDefault(p => p.Id == oldEmployee.Id);
                    Position pos = db.Positions.FirstOrDefault(p => p.Id == oldEmployee.Position.Id);
                    Department dep = db.Departments.FirstOrDefault(p => p.Id == oldEmployee.Department.Id);
                    if (employee != null)
                    {
                        employee.FirstName = oldEmployee.FirstName;
                        employee.LastName = oldEmployee.LastName;
                        employee.MiddleName = oldEmployee.MiddleName;
                        employee.Sex = oldEmployee.Sex;
                        employee.Position = pos;
                        employee.Department = dep;
                        db.SaveChanges();
                    }
                }
            }
        }

        #region получение должности/отдела по id
        public static Position GetPositionById(int id)
        {
            using (DataContext db = new())
            {
                Position pos = db.Positions.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }
        public static Department GetDepartmentById(int id)
        {
            using (DataContext db = new())
            {
                Department pos = db.Departments.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }
        #endregion
        //получение уникальной информации по типу сотрудника
        public static string GetUniqueInformation(Employee employee)
        {
            if (employee == null) return null;

            using (DataContext db = new())
            {
                switch (employee.PositionId)
                {
                    case 1: return "Директор компании DeePlay";
                    case 2: return $"Руководит отделом {employee.EmployeeDepartment}";
                    case 3: return $"Контролирует отдел {employee.EmployeeDepartment}";
                    case 4:
                        {
                            var FIOManager = db.Employees.FirstOrDefault(e => e.PositionId == 2 & e.DepartmentId == employee.DepartmentId);
                            if (FIOManager != null) return $"Руководитель {FIOManager.FullName}";
                            return "На данный момент руководителя нет";
                        }
                    default: return "";
                }
            }
        }
    }
}
