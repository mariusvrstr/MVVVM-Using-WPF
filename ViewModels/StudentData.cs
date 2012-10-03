using System;
using MVVMExample.ViewModels.DomainModels;

namespace MVVMExample.ViewModels
{
    public class StudentData //using System.ComponentModel;
    {
        public Student Student { get; set; }

        // Default constructor
        public StudentData()
        {
            // Hard coded example pre existing data
            Student = new Student
                          {
                              SetDefault = new DelegateCommand(RestoreDefault),
                              Save = new DelegateCommand(SaveStudent, CanSaveStudent)
                          };

            Student.SetDefault.Execute(null); // Set defaults
        }

        #region Default Student Actions

            // Validate Command parameters
            internal bool CanSaveStudent(object state)
            {
                if ((Student == null) || (String.IsNullOrEmpty(Student.FirstName)) ||
                    (String.IsNullOrEmpty(Student.LastName)))
                {
                    return false;
                }
                return Student.Age >= 18;
            }

            internal void SaveStudent(object state)
            { 
                // Logic placeholder to persist student information
            }
            
            // This command populates the default student values
            internal void RestoreDefault(object state)
            {
                Student.Age = 22;
                Student.FirstName = "John";
                Student.LastName = "Doe"; 
            }

        #endregion
    }
}