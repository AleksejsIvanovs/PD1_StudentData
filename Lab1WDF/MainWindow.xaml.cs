using System.Windows;
using System.IO;
using ClassLibraryLab1;
namespace Lab1WDF
{
    public partial class MainWindow : Window
    {
        private StudentsData studentsData = new StudentsData();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UpdateOutput()
        {
            txtStudentsOutput.Clear();
            foreach (var student in studentsData.Students)
            { 
                txtStudentsOutput.AppendText($"Student_Id: {student.StudentId} Student_Name: {student.StudentName} Student_Surname: {student.StudentSurname} Student_Group: {student.StudentGroup}\n");
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = txtStudentName.Text;
            string surname = txtStudentSurname.Text;
            string group = txtStudentGroup.Text;
            string id = txtStudentId.Text;

            Student newStudent = new Student(name, surname, id, group);
            studentsData.Add(newStudent);

            txtStudentName.Text = "";
            txtStudentSurname.Text = "";
            txtStudentId.Text = "";
            txtStudentGroup.Text = "";

            UpdateOutput();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            studentsData.Save();
            MessageBox.Show("Data has been saved successfully.");
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            string filename = StudentsData.DefaultFilename;

            if (!File.Exists(filename))
            {
                MessageBox.Show("File does not exist.");
                return;
            }

            studentsData.Load();

            if (studentsData.Students == null || studentsData.Students.Count == 0)
            {
                MessageBox.Show("The file is empty or contains no students.");
                return;
            }

            UpdateOutput();
            MessageBox.Show("Data has been loaded successfully.");
        }
    }
}