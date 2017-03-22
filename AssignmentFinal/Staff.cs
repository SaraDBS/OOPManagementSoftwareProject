//Sara Silva
//Student number: 1669329


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentFinal
{
    public class Staff : Person  //The Staff class extends the Person class.
    {   
        //Properties exclusive of the Staff class.
        public int StaffId { get; set; }
        private decimal salary { get; set; }

        public decimal Salary
        {

            get { return salary; }
            set
            {
                if (value >= 0.0M)
                {
                    salary = value;
                }
                else throw new ArgumentOutOfRangeException("Error, salary cannot be negative");
            }
        }

        //Parameterless constructor.
        public Staff() { }

        //Overloading constructor from  the person class and adding Staff class properties as parameters.
        public Staff(string ppsn, string name, string address, string phone, string email, int staffid, decimal salary) : base(ppsn, name, address, phone, email){

            StaffId = staffid;
            Salary = salary;
          
        }

        //Virtual method that returns Staff monthly salary.
        public virtual decimal GetPaid()
        {
            return Math.Round(Salary /(decimal)12);
        }

        //Overriding toString() method to return all of the Staff details. Note that GetPaid() method is used here to output Staff salary per month.
        public override string ToString()
        {
            return base.ToString() + string.Format("\nStaff Id: {0}\nSalary: {1:.00} Euros per month",StaffId,GetPaid());
        }
    }
}
