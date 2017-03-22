//Sara Silva
//Student number: 1669329


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentFinal
{
    public class Person
    {   
        //Declaring auto implemented properties of the person class

        public string PPSN { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Parameterless constructor
        public Person(){}

        // Constructor which takes properties as parameters
        public Person(string ppsn, string name, string address, string phone, string email) {

            PPSN = ppsn;
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
        }

        //Virtual method that can be overriden by derived classes.
        public virtual string ShowInfo()
        {
            return string.Format("{0} is a Person.\nPPS number:{1]",Name,PPSN);
        }

        //Overriding toString method to return all details of a person.
        public override string ToString()
        {
            return string.Format("PPSN: {0}\nName: {1}\nAddress: {2}\nPhone: {3}\nEmail: {4}",PPSN,Name,Address,Phone,Email);
        }
    }
}
