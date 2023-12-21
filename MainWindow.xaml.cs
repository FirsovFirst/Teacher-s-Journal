using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Teacher_s_Journal.Models;
using Teacher_s_Journal.Services;

namespace Teacher_s_Journal
{
    public partial class MainWindow : Window
    {
        private BindingList<Student> _students;

        private FileIOService _fileIOService;

        private string path = $"{Environment.CurrentDirectory}\\Database.json";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(path);

            try
            {
                _students = _fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            dataGrid.ItemsSource = _students;
            _students.ListChanged += _students_ListChanged;
        }

        private void _students_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemDeleted)
            {
                try
                {
                    _fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
    }
}