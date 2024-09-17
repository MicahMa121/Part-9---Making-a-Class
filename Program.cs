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
                Console.WriteLine("Please enter a command");
                string input = Console.ReadLine().ToLower();
                if (input == "help" )
                {
                    Console.WriteLine("Available Commands:\nupdate - show the updated list of student" +
                        "\ndetail - check detail of a specific student" +
                        "\nadd - add an student to the list" +
                        "\nremove - remove an existing student from the list" +
                        "\nsearch - search for existing students " +
                        "\nedit - change information of a specific student in the list" +
                        "\nsort - sort the list in alphabetical order of the last name" +
                        "\nquit - exit the program");
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
                    Student student = null;

                    bool found = false;
                    for (int i = 0; i < students.Count; i++)
                    {
                        if (student_edit.ToLower() == students[i].ToString().ToLower())
                        {
                            StudentDetail(students[i]);
                            student = students[i];
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine(student_edit + " is not found.");
                    }
                    else
                    {
                        Console.WriteLine("What do you want to change about this student's info? (FirstName, LastName, StudentNumber, Email)");
                        string edit = Console.ReadLine().ToLower();
                        if (edit == "firstname")
                        {
                            Console.WriteLine("The current first name is " + student.FirstName + ", please enter the updated first name");
                            student.FirstName = Console.ReadLine();
                            StudentDetail(student);
                        }
                        else if (edit == "lastname")
                        {
                            Console.WriteLine("The current last name is " + student.LastName + ", please enter the updated last name");
                            student.LastName = Console.ReadLine();
                            StudentDetail(student);
                        }
                        else if (edit == "studentnumber")
                        {
                            Console.WriteLine("The current student number is " + student.StudentNumber + ".");
                            student.GenerateNumber();
                            Console.WriteLine("The new student number is " + student.StudentNumber + ".");
                        }
                        else if (edit == "email")
                        {
                            Console.WriteLine("The current student Email is " + student.Email + ".");
                            student.GenerateEmail();
                            Console.WriteLine("The new student Email is " + student.Email + ".");
                        }
                        else
                        {
                            Console.WriteLine("Input Error");
                        }
                    }
                }
                else if (input== "sort")
                {
                    students.Sort();
                    Console.WriteLine("List Sorted.");
                }
                else if (input == "quit")
                {
                    Console.WriteLine("Thank you for using this program!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Input Error\nEnter \'help\' to see the list of commands");
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
