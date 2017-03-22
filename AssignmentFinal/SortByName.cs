using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentFinal
{
    public class SortByName : Comparer<Person> //Extending comparer class
    {
        //Method to be able to sort people in the list by the name property.
        public override int Compare(Person x, Person y)
        {
            if(x.Name.CompareTo(y.Name)!=0)
               return x.Name.CompareTo(y.Name);
            else return 0;
            
        }

        
    }
}
