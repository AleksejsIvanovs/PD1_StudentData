using ClassLibraryLab1;

class Program
{
    static void Main(string[] args)
    {
        StudentsData studentsData = new StudentsData();
        studentsData.Add(new Student("Aleksejs", "Ivanovs", "1", "DDBD"));
        studentsData.Add(new Student("Peter", "Vasiljevs", "2", "DDBI"));

        studentsData.Save();
        studentsData.Load();

        foreach (var student in studentsData.Students)
        {
            Console.WriteLine(student);
        }
    }
}