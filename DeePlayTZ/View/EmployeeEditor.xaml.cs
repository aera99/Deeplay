using DeePlayTZ.Model.Data;
using DeePlayTZ.Model.Data.Entitys;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace DeePlayTZ.View
{
    /// <summary>
    /// Логика взаимодействия для EmployeeEditor.xaml
    /// </summary>
    public partial class EmployeeEditor : Window, INotifyPropertyChanged
    {
        // конструктор для добавления нового сотрудника
        public EmployeeEditor()
        {
            InitializeComponent();
            this.Focus();
            this.DataContext = this;
            TitleTxt = "Добавление нового сотрудника";
            SelectGender = Gender.Man;
            PositionsView = DataBaseTools.GetPositions();
            DepartmentsView = DataBaseTools.GetDepartments();
            SelectedPosition = PositionsView[0];
            SelectedDepartment = DepartmentsView[0];

            AddEmployee = new DelegateCommand(() => Accept());
        }

        // конструктор для редактирования сотрудника
        public EmployeeEditor(Employee oldEmployee)
        {
            InitializeComponent();
            this.Focus();
            this.DataContext = this;
            TitleTxt = "Редактирование сотрудника";
            SelectGender = Gender.Man;
            PositionsView = DataBaseTools.GetPositions();
            DepartmentsView = DataBaseTools.GetDepartments();
            SelectedPosition = PositionsView[0];
            SelectedDepartment = DepartmentsView[0];
            Employee = oldEmployee;

            AddEmployee = new DelegateCommand(() => Accept());
        }

        private List<Position> positionsView;
        private List<Department> departmentsView;
        private Gender selectGender;

        public string TitleTxt { get; set; }
        public Employee Employee { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public List<Position> PositionsView
        {
            get => positionsView;
            set
            {
                positionsView = value;
                OnPropertyChanged("PositionsView");
            }
        }
        public List<Department> DepartmentsView
        {
            get => departmentsView;
            set
            {
                departmentsView = value;
                OnPropertyChanged("DepartmentsView");
            }
        }
        public Position SelectedPosition { get; set; }
        public Department SelectedDepartment { get; set; }
        public Gender SelectGender
        {
            get => selectGender;
            set
            {
                if (selectGender == value) return;
                selectGender = value;
                OnPropertyChanged("SelectGender");
                OnPropertyChanged("IsMan");
                OnPropertyChanged("IsWoman");
            }
        }
        public bool IsMan
        {
            get { return SelectGender == Gender.Man; }
            set { SelectGender = value ? Gender.Man : SelectGender; }
        }
        public bool IsWoman
        {
            get { return SelectGender == Gender.Woman; }
            set { SelectGender = value ? Gender.Woman : SelectGender; }
        }

        public DelegateCommand AddEmployee { get; }

        public void Accept()
        {
            char sex = 'Ж';
            if (SelectGender == Gender.Man) sex = 'М';
            if (FirstName == null || LastName == null || MiddleName == null)
            {
                MessageBox.Show("Вы ошиблись в вводе!");
                return;
            }
            try
            {
                if (TitleTxt == "Добавление нового сотрудника")
                {
                    this.Employee = new Employee()
                    {
                        FirstName = this.FirstName,
                        LastName = this.LastName,
                        MiddleName = this.MiddleName,
                        Sex = sex,
                        Position = SelectedPosition,
                        Department = SelectedDepartment
                    };
                    DataBaseTools.AddEmployee(Employee);
                }
                else
                {
                    Employee.FirstName = this.FirstName;
                    Employee.LastName = this.LastName;
                    Employee.MiddleName = this.MiddleName;
                    Employee.Sex = sex;
                    Employee.Position = SelectedPosition;
                    Employee.Department = SelectedDepartment;
                    DataBaseTools.UpdateEmployee(Employee);
                }
                DialogResult = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Вы ошиблись в вводе!");
            }
        }

        #region INPC
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
