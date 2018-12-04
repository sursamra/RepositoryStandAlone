using Interview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestRepository
{
    public class EmployeeEntity : IStoreable
    {
        public IComparable Id { get; set; }
        public string Name { get; set; }
    }

    public class DeptEntity : IStoreable
    {
        public IComparable Id { get; set; }
        public string Name { get; set; }
    }
}
