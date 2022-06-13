using DeePlayTZ.Model.Data;
using DeePlayTZ.Model.Data.Entitys;
using DeePlayTZ.View;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;

namespace DeePlayTZ.ViewModel
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel()
        {
            PositionsView = DataBaseTools.GetPositions();
            DepartmentsView = DataBaseTools.GetDepartments();
            AllEmployees = DataBaseTools.GetEmployees();
            EmployeesFilterPosition = DataBaseTools.GetEmployeesByPosition(SelectedPosition);
            EmployeesFilterDepartment = DataBaseTools.GetEmployeesByDepartment(SelectedDepartment);

            AddEmployee = new DelegateCommand(() => AddNewEmployee());
            Update = new DelegateCommand(() => UpdateEmployee());
            Delete = new DelegateCommand(() => DeleteEmployee());
            Promotion = new DelegateCommand(() => PromotionEmployee());
        }

        private List<Position> positionsView;
        private List<Department> departmentsView;
        private List<Employee> allEmployees;
        private List<Employee> employeesFilterPosition;
        private List<Employee> employeesFilterDepartment;
        private Position selectedPosition;
        private Department selectedDepartment;

        public List<Position> PositionsView
        {
            get => positionsView;
            set => SetProperty(ref positionsView, value);
        }
        public List<Department> DepartmentsView
        {
            get => departmentsView;
            set => SetProperty(ref departmentsView, value);
        }
        public List<Employee> AllEmployees
        {
            get => allEmployees;
            set => SetProperty(ref allEmployees, value);
        }
        public List<Employee> EmployeesFilterPosition
        {
            get => employeesFilterPosition;
            set => SetProperty(ref employeesFilterPosition, value);
        }
        public List<Employee> EmployeesFilterDepartment
        {
            get => employeesFilterDepartment;
            set => SetProperty(ref employeesFilterDepartment, value);
        }

        //выбранные в MainWindow сотрудник , должность и отдел
        public Employee SelectedEmployee { get; set; }
        public Position SelectedPosition
        {
            get => selectedPosition;
            set
            {
                SetProperty(ref selectedPosition, value);
                UpdateFilterPositionView();
            }
        }
        public Department SelectedDepartment
        {
            get => selectedDepartment;
            set
            {
                SetProperty(ref selectedDepartment, value);
                UpdateFilterDepartmentView();
            }
        }

        public DelegateCommand AddEmployee { get; }
        public DelegateCommand Update { get; }
        public DelegateCommand Delete { get; }
        public DelegateCommand Promotion { get; }

        #region Обновление данных в DataGrid MainWindow
        private void UpdateAllView()
        {
            UpdateAllEmployeesView();
            UpdateFilterPositionView();
            UpdateFilterDepartmentView();
        }
        private void UpdateAllEmployeesView()
        {
            MainWindow.AllEmployeesView.ItemsSource = DataBaseTools.GetEmployees();
            MainWindow.AllEmployeesView.Items.Refresh();
        }
        private void UpdateFilterPositionView()
        {
            MainWindow.FilterPositionView.ItemsSource = DataBaseTools.GetEmployeesByPosition(SelectedPosition);
            MainWindow.FilterPositionView.Items.Refresh();
        }
        private void UpdateFilterDepartmentView()
        {
            MainWindow.FilterDepartmentView.ItemsSource = DataBaseTools.GetEmployeesByDepartment(SelectedDepartment);
            MainWindow.FilterDepartmentView.Items.Refresh();
        }
        #endregion

        private void Message(string msg)
        {
            MessageView messageView = new MessageView(msg);
            messageView.Show();
        }

        //методы для доблавения , удаления , повышения и редактирования сотрудников
        private void AddNewEmployee()
        {
            EmployeeEditor editor = new();
            if (editor.ShowDialog() == true) UpdateAllView();
        }
        private void UpdateEmployee()
        {
            if (SelectedEmployee != null)
            {
                EmployeeEditor editor = new(SelectedEmployee);
                if (editor.ShowDialog() == true) UpdateAllView();
                return;
            }
            Message("Ошибка! Выберите сотрудника.");
        }
        private void DeleteEmployee()
        {
            if (SelectedEmployee != null)
            {
                DataBaseTools.DeleteEmployee(SelectedEmployee);
                UpdateAllView();
                return;
            }
            Message("Ошибка! Выберите сотрудника.");
        }
        private void PromotionEmployee()
        {
            if (SelectedEmployee == null)
            {
                Message("Ошибка! Выберите сотрудника.");
                return;
            }
            if (SelectedEmployee.PositionId == 1)
            {
                Message("Выше должности чем у выбранного сотрудника не существует!");
                return;
            }
            DataBaseTools.PromotionEmployee(SelectedEmployee);
            Message($"Вы успешно повысили в должности сотрудника " +
                $"{SelectedEmployee.FirstName} {SelectedEmployee.LastName} {SelectedEmployee.MiddleName}");
            UpdateAllView();
        }
    }
}
