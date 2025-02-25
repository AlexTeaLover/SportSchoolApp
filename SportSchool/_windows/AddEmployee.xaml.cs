using SportSchool._models;
using SportSchool._processing;
using System.Windows;
using System.Windows.Controls;

namespace SportSchool._windows
{
    // <summary>
    // Логика взаимодействия для AddEmployee.xaml
    // </summary>
    public partial class AddEmployee : Window
    {
        SportSchoolDataContext _context;
        List<TextBox> _textBoxes = new();
        public AddEmployee(SportSchoolDataContext context)
        {
            InitializeComponent();

            _context = context;

            _textBoxes.Add(nameTextBox);
            _textBoxes.Add(phoneTextBox);
            _textBoxes.Add(loginTextBox);
            _textBoxes.Add(passwordTextBox);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (FieldsValidator.IsValid(_textBoxes))
            {
                Employee employee = new()
                {
                    Name = nameTextBox.Text,
                    Phone = phoneTextBox.Text,
                    Login = loginTextBox.Text,
                    Password = passwordTextBox.Text,
                    Status = statusTextBox.Text
                };
                _context.Employees.Add(employee);
                _context.SaveChanges();
                MessageBox.Show("Данные успешно внесенны", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполнены не все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
