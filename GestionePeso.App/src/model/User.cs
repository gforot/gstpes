using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace GestionePeso.App.Model
{
    public class User : ViewModelBase
    {
        private int _age;
        private int _altezza;
        private Gender _gender;
        private string _username;

        public int Age 
        { 
            get 
            { 
                return _age; 
            }
            set 
            { 
                _age = value;
                RaisePropertyChanged("Age");
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                RaisePropertyChanged("Username");
            }
        }

        public Gender Gender 
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                RaisePropertyChanged("Gender");
            }
        }

        public int Altezza 
        {
            get
            {
                return _altezza;
            }
            set
            {
                _altezza = value;
                RaisePropertyChanged("Altezza");
            }
        }

        public User(string username, int age, Gender gender, int altezza)
        {
            _username = username;
            _age = age;
            _gender = gender;
            _altezza = altezza;
        }

        public User()
        {
            _age  = 35;
            _username = string.Empty;
            _gender = Model.Gender.Male;
            _altezza = 170;
        }

        public override string ToString()
        {
            return Username;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            { 
                return false; 
            }

            User cmp = (User)obj;
            return cmp.Username.Equals(_username);
        }

        public override int GetHashCode()
        {
            return _username.GetHashCode();
        }

        internal User Clone()
        {
            return new User(_username, _age, _gender, _altezza);
        }
    }
}
