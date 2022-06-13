using DeePlayTZ.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DeePlayTZ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DataGrid AllEmployeesView;
        public static DataGrid FilterPositionView;
        public static DataGrid FilterDepartmentView;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            AllEmployeesView = ViewAllEmployees;
            FilterPositionView = ViewFilterPosition;
            FilterDepartmentView = ViewFilterDepartment;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
