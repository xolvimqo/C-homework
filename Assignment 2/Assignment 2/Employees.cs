using System;
using System.Collections;

namespace Assignment_2
{
    public class Employees:ICollection
    {
        public string CollectionName;
        public ArrayList empArray = new ArrayList(); // array object

        // Methods
        public Employee this[int index]
        {
            get { return (Employee)empArray[index]; }
        }

        public void CopyTo(Array a, int index)
        {
            empArray.CopyTo(a, index);
        }

        public int Count
        {
            get { return empArray.Count; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public IEnumerator GetEnumerator()
        {
            return empArray.GetEnumerator();
        }

        public void Add(Employee newEmployee)
        {
            empArray.Add(newEmployee);
        }
    }
}
