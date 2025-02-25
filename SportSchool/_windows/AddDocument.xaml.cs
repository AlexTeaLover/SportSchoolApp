using SportSchool._models;
using SportSchool._processing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SportSchool._windows
{
    // <summary>
    // Логика взаимодействия для AddDocument.xaml
    // </summary>
    public partial class AddDocument : Window
    {
        SportSchoolDataContext _context;
        List<TextBox> _textBoxes = new();
        public AddDocument(SportSchoolDataContext context)
        {
            InitializeComponent();

            _context = context;

            _textBoxes.Add(nameTextBox);
            _textBoxes.Add(createdTextBox);
            _textBoxes.Add(descriptionTextBox);

            signedByCombBox.ItemsSource = _context.Employees.Select(e => e.Name).ToList();
            signedByCombBox.SelectedIndex = 0;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (FieldsValidator.IsValid(_textBoxes))
            {
                DateTime created;
                DateTime? expires;

                try
                {
                    created = Convert.ToDateTime(createdTextBox.Text);
                    expires = string.IsNullOrEmpty(expiresTextBox.Text) ? null : Convert.ToDateTime(expiresTextBox.Text);
                    createdTextBox.BorderBrush = Brushes.Black;
                    expiresTextBox.BorderBrush = Brushes.Black;
                }
                catch
                {
                    createdTextBox.BorderBrush = Brushes.Red;
                    expiresTextBox.BorderBrush = Brushes.Red;
                    MessageBox.Show("Дата введена некорректно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Document document = new()
                {
                    Name = nameTextBox.Text,
                    Created = Convert.ToDateTime(createdTextBox.Text),
                    Expires = string.IsNullOrEmpty(expiresTextBox.Text) ? null : Convert.ToDateTime(expiresTextBox.Text),
                    Description = descriptionTextBox.Text,
                    SignedBy = _context.Employees.Where(e => e.Name == signedByCombBox.Text).Select(e => e.Id).First(),
                };
                _context.Documents.Add(document);
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
