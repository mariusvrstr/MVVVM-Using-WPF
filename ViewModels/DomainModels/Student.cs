using System;
using System.ComponentModel;

namespace MVVMExample.ViewModels.DomainModels
{
    public class Student : INotifyPropertyChanged //using System.ComponentModel;
    {
        #region Property Changed

            public event PropertyChangedEventHandler PropertyChanged;

            // Create the OnPropertyChanged method to raise the event 
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }

        #endregion

        #region Student Specific Properties            

            private string _firstName;

            public string FirstName
            {
                get { return _firstName; }
                set
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                    OnPropertyChanged("FullName");
                }
            }

            private string _lastName;
            public string LastName
            {
                get { return _lastName; }
                set
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                    OnPropertyChanged("FullName");
                }
            }

            private int _age;
            public int Age
            {
                get { return _age; }
                set
                {
                    _age = value;
                    OnPropertyChanged("Age");
                    OnPropertyChanged("FullName");
                }
            }

            public string FullName
            {
                get { return ToString(); }
            }

            public DelegateCommand SetDefault { get; set; }
            public DelegateCommand Save { get; set; }

        #endregion

        public override string ToString() // Student object to string
        {
            return String.Format("{0} {1} is {2} years old", FirstName, LastName, Age);
        }
    }
}