//Sara Silva
//Student number: 1669329


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentFinal
{
    public class Student : Person  //The student class extends the base Person class.
    {   
        // Properties exclusive of the Student Class
        public int StudentId { get; set; }
        //public StudentStatus Status { get; set; } //Enum property StudentStatus
        private StudentStatus status;
        public StudentStatus Status
        {
            get
            {

                return status;
            }


            set
            {

                if (value == StudentStatus.undergraduate || value == StudentStatus.postgraduate)
                {
                    status = value;
                }
                else throw new ArgumentException(String.Format("Error: {0} is invalid Student Status", value), "value");

            }
        }
        

        //Parameterless constructor
        public Student() { }

        //Overloading constructor from the person class and adding Student class properties as parameters.
        public Student(string ppsn, string name, string address, string phone, string email, int studentid, StudentStatus status) : base(ppsn, name, address, phone, email) {

            StudentId = studentid;
            Status = status;
        }

        //Overriding Person class virtual method ShowInfo() to return "is a student" affirmation and student number. 
        //This method is used when searching for student by id. If Id is found, information for student is displayed.
        public override string ShowInfo()
        {
            return string.Format("{0} is a Student.\nStudent Number:{1}",Name,StudentId);
        }

        //Overriding toString() method to return all Student details.
        public override string ToString()
        {
            return base.ToString() + string.Format("\nStudentId: {0}\nStatus: {1}",StudentId,Status);
        }

        //Overriding equals method to return true if student status and student id are equal.
        public override bool Equals(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();
            Student student = obj as Student;
            if (student == null)
                throw new ArgumentNullException();

            return (this.StudentId == student.StudentId) && (this.Status == student.Status);
        }

        //Overriding GetHashCode() since Equals method was overriden.
        public override int GetHashCode()
        {
            return this.StudentId.GetHashCode();
        }
    }
}
