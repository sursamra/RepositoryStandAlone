using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interview;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UnitTestRepository
{
   
    [TestClass]
    public class EmployeeUnitTests
    {
        [TestMethod]
        public void TestRepositoryReturnsCorrectEnumerator()
        {
            IRepository<EmployeeEntity> emps = new Repository<EmployeeEntity>();
            Assert.IsInstanceOfType(emps.All(), typeof(IEnumerable<EmployeeEntity>));        

        }

        [TestMethod]
        public void TestItemsAreSavedInRepository()
        {
            IRepository<EmployeeEntity> emps = new Repository<EmployeeEntity>();
            EmployeeEntity johnEmp = new EmployeeEntity
            {
                Id = 1,
                Name = "John"
            };
            EmployeeEntity marryEmp = new EmployeeEntity
            {
                Id = 2,
                Name = "Marry"
            };
            emps.Save(johnEmp);
            emps.Save(marryEmp);
            Assert.AreEqual(emps.All().Count(), 2);
        }

        [TestMethod]
        public void TestDeleteItemDeletesItemsinRepository()
        {
            IRepository<EmployeeEntity> emps = new Repository<EmployeeEntity>();
            EmployeeEntity johnEmp = new EmployeeEntity
            {
               Id = 1,
                Name = "John"
            };
            EmployeeEntity marryEmp = new EmployeeEntity
            {
                Id = 2,
                Name = "Marry"
            };
            emps.Save(johnEmp);
            emps.Save(marryEmp);
            emps.Delete(johnEmp.Id);

            Assert.AreEqual(emps.All().Count(), 1);
            Assert.AreEqual(emps.FindById(1), null);
            Assert.AreEqual(emps.FindById(2), marryEmp);
        }

        [TestMethod]
        public void TestFindItemFromRepositoryReturnsItemsBasedOnId()
        {
            IRepository<EmployeeEntity> emps = new Repository<EmployeeEntity>();
            EmployeeEntity johnEmp = new EmployeeEntity
            {
                Id = 1,
                Name = "John"
            };
            EmployeeEntity marryEmp = new EmployeeEntity
            {
                Id = 2,
                Name = "Marry"
            };
            emps.Save(johnEmp);
            emps.Save(marryEmp);        
           
            Assert.AreEqual(emps.FindById(2).Name, marryEmp.Name);
        }
    }
}
