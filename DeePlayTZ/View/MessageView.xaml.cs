using System.Windows;

namespace DeePlayTZ.View
{
    /// <summary>
    /// Логика взаимодействия для MessageView.xaml
    /// </summary>
    public partial class MessageView : Window
    {
        public MessageView(string message)
        {
            InitializeComponent();
            DataContext = this;
            Message = message;
            this.Focus();
        }

        public string Message { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
