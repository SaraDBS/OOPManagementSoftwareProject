//Sara Silva
//Student number: 1669329


using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentFinal
{
    public class People : ICollection<Person>   //Declaring People class which implements the ICollection interface.
    {   
        //Criating list of type Person as a People class property.
        private List<Person> list { get; set; }

        public People() {

            list = new List<Person>();
        }

        //interface properties

        public int Count { get; }

        public bool IsReadOnly { get { return false; } }

        //interface methods

        public void Add(Person item) {
            list.Add(item);
        }

        public bool Remove(Person item) {
            bool remove = false;
            for (int i = 0; i < list.Count && !remove; i++) {

                if (list[i].PPSN == item.PPSN)
                    list.Remove(list[i]);
                remove = true;
            }

            return remove;

        }

        public void Clear() {

            list.Clear();
        }
        
        public bool Contains(Person item) {

            return list.Contains(item);
        }

        //overloading Contains method

        public bool Contains(Student item) {

            return list.Contains(item);
        }

        public bool Contains(Lecturer item) {
            return list.Contains(item);
        }

        public void CopyTo(Person[] array, int index)
        {
            list.CopyTo(array, index);
        }

        public IEnumerator<Person> GetEnumerator() {

            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            return list.GetEnumerator();
        }

        //Overloading Contains method to check if the list contains the name property of a person(student or lecturer)
        public bool Contains(string name) {

            bool found = false;
            for (int i = 0; i < list.Count && !found; i++)
            {
                if (list[i].Name.Equals(name))
                    found = true;
            }

            return found;

        }
        
        public void SortByName() // When the SortByName method is called , a new SortByName object is created.
        {
            list.Sort(new SortByName());
        }
        
   }
}
