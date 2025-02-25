using Microsoft.EntityFrameworkCore;
using SportSchool._models;
using SportSchool._windows;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace SportSchool
{
    // <summary>
    // Interaction logic for MainWindow.xaml
    // </summary>
    public partial class MainWindow : Window
    {
        SportSchoolDataContext _context;
        List<TabItem> _tabs = new();

        public MainWindow(SportSchoolDataContext context, int id)
        {
            InitializeComponent();

            _context = context;

            userName.Text = _context.Employees.Where(e => e.Id == id).Select(e => e.Name).First();

            _tabs.Add(courseTab);
            _tabs.Add(employeeTab);
            _tabs.Add(documentTab);

            EmployeePermitions(id);
            UpdateGrids();
        }

        private void EmployeePermitions(int employeeId)
        {
            bool accessed;
            bool firstTabSelected = false;

            var tabs = _context.EmployeeRoles
                .Where(e => e.EmployeeId == employeeId)
                .Join(_context.Roles, er => er.RoleId, r => r.Id, (er, r) => new { r.Id })
                .Join(_context.RoleMenus, r => r.Id, rm => rm.RoleId, (r, rm) => new { rm.MenuId })
                .Join(_context.Menus, rm => rm.MenuId, m => m.Id, (rm, m) => new { m.Name })
                .ToList();

            foreach (var applicationTab in _tabs)
            {
                accessed = false;
                foreach (var dataBaseTab in tabs)
                {
                    if (dataBaseTab.Name.Equals(applicationTab.Header))
                    {
                        accessed = true;
                        break;
                    }
                }
                if (!accessed)
                {
                    applicationTab.Visibility = Visibility.Collapsed;
                }
                else if(!firstTabSelected)
                {
                    firstTabSelected = true;
                    applicationTab.IsSelected = true;
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (courseTab.IsSelected)
            {
                courseGrid.ItemsSource = _context.Courses
                    .Where(c => c.Name.Contains(courseName.Text)).ToList(); return;
            }

            if (employeeTab.IsSelected)
            {
                employeeGrid.ItemsSource = _context.Employees
                    .Where(c => c.Name.Contains(employeeName.Text))
                    .Where(c => c.Phone.Contains(employeePhone.Text))
                    .Where(c => c.Status.Contains(employeeStatus.Text)).ToList(); return;
            }

            if (documentTab.IsSelected)
            {
                documentGrid.ItemsSource = _context.Documents
                    .Include(d => d.SignedByNavigation)
                    .Where(d => d.Name.Contains(documentName.Text))
                    .Where(d => d.SignedByNavigation.Name.Contains(signedByTextBox.Text)).ToList(); return;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateClearButtons();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int counter = 0;

            if (courseTab.IsSelected)
            {
                foreach (var feild in courseGrid.SelectedItems)
                {
                    var course = feild as Course;
                    if (course != null)
                    {
                        _context.Courses.Remove(course);
                        counter++;
                    }
                }
            }
            else if (employeeTab.IsSelected)
            {
                foreach (var feild in employeeGrid.SelectedItems)
                {
                    var employee = feild as Employee;
                    if (employee != null)
                    {
                        _context.Employees.Remove(employee);
                        counter++;
                    }
                }
            }
            else if (documentTab.IsSelected)
            {
                foreach (var feild in documentGrid.SelectedItems)
                {
                    var document = feild as Document;
                    if (document != null)
                    {
                        _context.Documents.Remove(document);
                        counter++;
                    }
                }
            }

            MessageBox.Show($"Успешно удалено {counter} запись(ей)", "Успешное удаление", MessageBoxButton.OK, MessageBoxImage.Information);
            _context.SaveChanges();
            UpdateClearButtons();
            UpdateGrids();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (courseTab.IsSelected)
            {
                AddCourse addCourse = new(_context);
                addCourse.ShowDialog();
            }
            else if (employeeTab.IsSelected)
            {
                AddEmployee addEmployee = new(_context);
                addEmployee.ShowDialog();
            }
            else if (documentTab.IsSelected)
            {
                AddDocument addDocument = new(_context);
                addDocument.ShowDialog();
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            UpdateGrids();
        }

        private void UpdateClearButtons()
        {
            if (courseTab.IsSelected) { courseName.Clear(); return; }
            if (employeeTab.IsSelected) { employeeName.Clear(); employeePhone.Clear(); return; }
            if (documentTab.IsSelected) { documentName.Clear(); signedByTextBox.Clear(); return; }
        }

        private void UpdateGrids()
        {
            courseGrid.ItemsSource = _context.Courses.ToList();
            employeeGrid.ItemsSource = _context.Employees.ToList();
            documentGrid.ItemsSource = _context.Documents.Include(d => d.SignedByNavigation).ToList();
        }
    }
}