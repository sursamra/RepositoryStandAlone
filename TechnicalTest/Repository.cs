using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class Repository<T> : IRepository<T> where T : IStoreable
    {
        HashSet<T> data = new HashSet<T>();
        public IEnumerable<T> All()
        {
            return data.AsEnumerable<T>();
        }

        public void Delete(IComparable id)
        {
            T item = FindById(id);
            data.Remove(item);
        }

        public T FindById(IComparable id)
        {
            return data.FirstOrDefault(a => a.Id.CompareTo(id) == 0);
        }

        public void Save(T item)
        {
            data.Add(item);
        }
    }
}
