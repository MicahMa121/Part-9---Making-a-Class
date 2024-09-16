using System.Numerics;

namespace Part_9___Making_a_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new("Robert", "Ross"));
            students.Add(new("Neske", "Rolando"));
            students.Add(new("Edie", "Shifra"));

            PrintList(students);

            while (true)
            {
                Console.WriteLine("Please enter a command, enter \"help\" to check the list of commands.");
                string input = Console.ReadLine().ToLower();
                if (input == "help" )
                {
                    
                }
                else if (input == "update")
                {
                    PrintList(students);
                }
                else if (input == "detail")
                {
                    Console.WriteLine("Please enter the full name of the student with a space between first and last name.");
                    string student_detail = Console.ReadLine();
                    
                    bool found = false;
                    for (int i = 0; i < students.Count; i++)
                    {
                        if (student_detail.ToLower() == students[i].ToString().ToLower())
                        {
                            StudentDetail(students[i]);
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine(student_detail + " is not found.");
                    }
                }
                else if( input == "add")
                {
                    Console.WriteLine("Please enter first name of the new student");
                    string firstName = Console.ReadLine();
                    while (string.IsNullOrEmpty(firstName))
                    {
                        Console.WriteLine("Name cannot be empty!");
                        firstName = Console.ReadLine();
                    }
                    Console.WriteLine("Please enter last name of the new student");
                    string lastName = Console.ReadLine();
                    while (string.IsNullOrEmpty(lastName))
                    {
                        Console.WriteLine("Name cannot be empty!");
                        lastName = Console.ReadLine();
                    }
                    students.Add(new(firstName, lastName));
                    Console.WriteLine("Student " + students[students.Count-1]+" added successfully!");
                }
                else if ( input == "remove")
                {
                    Console.WriteLine("Please enter the full name of the student with a space between first and last name.");
                    string student_remove = Console.ReadLine();
                    bool found = false;
                    for (int i = 0; i < students.Count; i++)
                    {
                        if (student_remove.ToLower() == students[i].ToString().ToLower())
                        {
                            Console.WriteLine(students[i] + " is removed from the list.");
                            students.RemoveAt(i);
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine(student_remove + " is not found.");
                    }
                }
                else if ( input == "search")
                {
                    Console.WriteLine("Please enter the name of the student you want to search.");
                    string student_search = Console.ReadLine();
                    bool found = false;
                    for (int i = 0; i < students.Count; i++)
                    {
                        if (students[i].ToString().ToLower().Contains(student_search.ToLower()))
                        {
                            StudentDetail(students[i]);
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine(student_search + " is not found.");
                    }
                }
                else if ( input == "edit")
                {
                    Console.WriteLine("Please enter the name of the student you want to edit.");
                    string student_edit = Console.ReadLine();
                }
            }

        }
        public static void PrintList(List<Student> students)
        {
            Console.WriteLine("Here is the list of students:");
            int count = 0;
            foreach (Student student in students)
            {
                count++;
                Console.WriteLine(count + ". " + student);
            }
        }
        public static void StudentDetail(Student student)
        {
            Console.WriteLine("Here is the information of the student:");
            Console.WriteLine(student + "\nStudent Number:" + student.StudentNumber + "\nStudent Email:" + student.Email);
        }
    }
}
