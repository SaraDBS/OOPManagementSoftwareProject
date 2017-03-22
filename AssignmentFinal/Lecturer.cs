//Sara Silva
//Student number: 1669329


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentFinal
{
    public class Lecturer : Staff  //The Lecturer class extends the Staff class
    {
        private string[] subjectsTaught;
        //Property exclusive of the Lecturer class
        public string[] SubjectsTaught
        {
            get { return subjectsTaught; }
            set
            {
                if (value == null|| value.Length == 0)
                    throw new ArgumentNullException("Error: lecturer must teach at least one subject!");
                else
                    subjectsTaught = value;
            }
        }//Using an array of strings as a property to store the Subjects taught by each lecturer since there can be more than one.

        //Parameterless constructor
        public Lecturer() { }

        //Overloading the Staff class constructor which is already overloading the Person class constructor and adding SubjectsTaught property as parameter.
        public Lecturer(string ppsn, string name, string address, string phone, string email, int staffid, decimal salary,string [] subjects) : base(ppsn, name, address, phone, email,staffid,salary) {

            SubjectsTaught = subjects;
        }

        //Overriding GetPaid() method from the Staff class to add a christmas bonus specific for lecturers and return average montlhy earnings.
        public override decimal GetPaid()
        {
            decimal christmasbonus = 500;
            //return Math.Round((Salary /(decimal)12)+christmasbonus);
            return base.GetPaid() + christmasbonus;
        }

        //Virtual method ShowInfo() which is defined in the Person class that is parent of the Staff class is overriden here by the Lecturer class due to inheritance hierarchy.
        public override string ShowInfo()
        {
            return string.Format("{0} is a Lecturer.\nLecturer Id:{1}", Name, StaffId);
        }

        //Overriding ToString() method to return all lecturer details.
        public override string ToString()
        {
            return base.ToString() + string.Format("\nSubjects Taught: {0}", SubjectsTaught);
        }

        //Overriding equals method to return true if the subjects taught and lecturer id are the same.
        public override bool Equals(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();
            Lecturer lecturer = obj as Lecturer;
            if (lecturer == null)
                throw new ArgumentNullException();

            return (this.SubjectsTaught == lecturer.SubjectsTaught) && (this.StaffId == lecturer.StaffId);
        }

        //Overriding GetHashCode() since equals method was overriden.
        public override int GetHashCode()
        {
            return this.SubjectsTaught.GetHashCode();
        }

       
    }
}
