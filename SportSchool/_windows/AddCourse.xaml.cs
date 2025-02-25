using SportSchool._models;
using SportSchool._processing;
using System.Windows;
using System.Windows.Controls;

namespace SportSchool._windows
{
    /// <summary>
    /// Логика взаимодействия для AddCourse.xaml
    /// </summary>
    public partial class AddCourse : Window
    {
        SportSchoolDataContext _context;
        List<TextBox> _textBoxes = new();
        public AddCourse(SportSchoolDataContext context)
        {
            InitializeComponent();

            _context = context;
            _textBoxes.Add(nameTextBox);
            _textBoxes.Add(durationTextBox);
            _textBoxes.Add(descriptionTextBox);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (FieldsValidator.IsValid(_textBoxes))
            {
                Course course = new() { Name = nameTextBox.Text, Description = descriptionTextBox.Text, Duration = durationTextBox.Text };
                _context.Courses.Add(course);
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