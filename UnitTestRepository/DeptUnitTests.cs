using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interview;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UnitTestRepository
{

    [TestClass]
    public class DeptUnitTests
    {
        [TestMethod]
        public void TestRepositoryReturnsCorrectEnumerator()
        {
            IRepository<DeptEntity> emps = new Repository<DeptEntity>();
            Assert.IsInstanceOfType(emps.All(), typeof(IEnumerable<DeptEntity>));

        }

        [TestMethod]
        public void TestItemsAreSavedInRepository()
        {
            IRepository<DeptEntity> emps = new Repository<DeptEntity>();
            DeptEntity accountsDept = new DeptEntity
            {
                Id = 1,
                Name = "Accounts"
            };
            DeptEntity HRDept = new DeptEntity
            {
                Id = 2,
                Name = "HR"
            };
            emps.Save(accountsDept);
            emps.Save(HRDept);
            Assert.AreEqual(emps.All().Count(), 2);
        }

        [TestMethod]
        public void TestDeleteItemDeletesItemsinRepository()
        {
            IRepository<DeptEntity> emps = new Repository<DeptEntity>();
            DeptEntity accountsDept = new DeptEntity
            {
                Id = 1,
                Name = "Accounts"
            };
            DeptEntity HRDept = new DeptEntity
            {
                Id = 2,
                Name = "HR"
            };
            emps.Save(accountsDept);
            emps.Save(HRDept);
            emps.Delete(accountsDept.Id);

            Assert.AreEqual(emps.All().Count(), 1);
            Assert.AreEqual(emps.FindById(1), null);
            Assert.AreEqual(emps.FindById(2), HRDept);
        }

        [TestMethod]
        public void TestFindItemFromRepositoryReturnsItemsBasedOnId()
        {
            IRepository<DeptEntity> emps = new Repository<DeptEntity>();
            DeptEntity accountsDept = new DeptEntity
            {
                Id = 1,
                Name = "Accounts"
            };
            DeptEntity HRDept = new DeptEntity
            {
                Id = 2,
                Name = "HR"
            };
            emps.Save(accountsDept);
            emps.Save(HRDept);

            Assert.AreEqual(emps.FindById(2).Name, HRDept.Name);
        }
    }
}
