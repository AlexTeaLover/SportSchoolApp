using System.Windows;
using SportSchool._models;

namespace SportSchool
{
    // <summary>
    // Логика взаимодействия для Authentication.xaml
    // </summary>

    public partial class Authentication : Window
    {
        SportSchoolDataContext _context = new();
        public Authentication()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in _context.Employees.ToList())
            {
                if (item.Login.Equals(loginTextBox.Text) && item.Password.Equals(passwordBox.Password))
                {
                    MainWindow mainWindow = new(_context, item.Id);
                    mainWindow.Show();
                    this.Close();
                    return;
                }
            }
            MessageBox.Show("Логин и/или пароль некорректен", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
