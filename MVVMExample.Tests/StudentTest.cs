using MVVMExample.ViewModels;
using MVVMExample.ViewModels.DomainModels;
using NUnit.Framework;

namespace MVVMExample.Tests
{
    [TestFixture(18)]
    public class TestStudent
    {
        private int MinAllowedAge { get; set; }

        public TestStudent(int minAllwed)
        {
            MinAllowedAge = minAllwed;
        }

        #region Test if save is allowed

            [TestCase(18, "Marius", "Vorster")]  // Test A
            [TestCase(22, null, "Vorster")]      // Test B
            [TestCase(12, "Marius", "Vorster")]  // Test C
            public void TestCanSave(int age, string name, string surname)
            {
                var vm = new StudentData();
                // Build test object
                vm.Student = new Student
                                 {
                                     FirstName = name,
                                     LastName = surname,
                                     Age = age
                                 };

                bool result = vm.CanSaveStudent(new object());

                // This pre-validates the object to determine the expected result is
                bool expectedResult = (((vm.Student.Age >= MinAllowedAge)) &&
                    (!(string.IsNullOrEmpty(vm.Student.FirstName))) &&
                    (!(string.IsNullOrEmpty(vm.Student.LastName)))); 

                Assert.AreEqual(expectedResult, result);
            }

        #endregion
    }
}
