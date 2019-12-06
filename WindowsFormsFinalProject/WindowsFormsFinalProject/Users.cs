using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WindowsFormsFinalProject
{
    public class Users : ICollection
    {
        public string CollectionName;
        public ArrayList userArray = new ArrayList();

        // Methods
        public User this[int index]
        {
            get { return (User)userArray[index]; }
        }

        public int Count
        {
            get { return userArray.Count; }
        }

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public void CopyTo(Array array, int index)
        {
            userArray.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return userArray.GetEnumerator();
        }

        public void Add(User newUser)
        {
            userArray.Add(newUser);
        }
    }
}
