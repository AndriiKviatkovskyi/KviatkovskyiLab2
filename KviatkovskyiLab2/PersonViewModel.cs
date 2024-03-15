using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KviatkovskyiLab2
{
    internal class PersonViewModel
    {

        private PersonModel _person;

        public PersonViewModel()
        {
            _person = new PersonModel("", "");
        }

        public string FirstName
        {
            get { return _person.FirstName; }
            set {  _person.FirstName = value; }
        }

        public string LastName
        {
            get { return _person.LastName; }
            set { _person.LastName = value; }
        }

        public string Email
        {
            get { return _person.Email ?? ""; }
            set { _person.Email = value; }
        }

        public DateTime Birthdate
        {
            get { return _person.Birthdate ?? DateTime.Today; }
            set { _person.Birthdate = value; }
        }

        public int Age
        {
            get { return _person.Age ?? -1; }
        }

        public bool IsAdult
        {
            get { return _person.IsAdult ?? false; }
        }

        public string ZodiacWestern
        {
            get { return _person.ZodiacWestern ?? string.Empty; }
        }

        public string ZodiacChinese
        {
            get { return _person.ZodiacChinese ?? string.Empty; }
        }

        public bool IsBirthday
        {
            get { return _person.IsBirthday ?? false; }
        }

        public PersonModel Person
        {
            get { return _person ?? new PersonModel("", "");}
            set { _person = value; }
        }

    }
}
