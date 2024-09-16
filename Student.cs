using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_9___Making_a_Class
{
    public class Student
    {
        private Random _gen = new Random();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public int StudentNumber { get; set; }
        public Student(string firstname, string lastname) 
        { 
            FirstName = firstname;
            LastName = lastname;
            GenerateNumber();
            GenerateEmail();
        }
        public override string ToString()
        {
            return FirstName + " "+LastName;
        }
        private void GenerateEmail()
        {
            Email = FirstName.Substring(0,3)+ LastName.Substring(0, 3)+StudentNumber.ToString().Substring(3,3)+"@ICSU4.com";
        }
        private void GenerateNumber()
        {
            StudentNumber = _gen.Next(1000) + 555000;
        }
    }
}
