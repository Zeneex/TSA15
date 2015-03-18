using System;
using System.Text.RegularExpressions;

namespace MobilePhone
{
    class Person
    {
        private string firstName;
        private string lastName;
        private string company;      //it's supposed to hold the person's workplace or a firm the person represents
        
        //read-write
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                ValidateName(value);
                this.firstName = value.Trim();
            }
        }

        //read-write
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                ValidateName(value);
                this.lastName = value.Trim();
            }
        }

        //read-write
        public string Company
        {
            get { return this.company; }
            set
            {
                if (value == null)
                {
                    throw new FormatException
                        ("'Company' property value can not be null");
                }
                this.company = value;
            }
        }

        //default (paramless) constructor
        public Person() : this(GSM.NA, GSM.NA)
        { }

        //full constructor
        public Person(string firstName, string lastName, string company = GSM.NA)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Company = company;
        }

        //validation logic, extracted as a private method
        private void ValidateName(string name)
        {
            if (name == null)
            {
                throw new FormatException
                    ("Name value can not be null");
            }
            if (!Regex.Match(name.Trim(), @"^[A-Z][A-Za-z]*('[A-Za-z]*)?$").Success)
            {
                throw new FormatException
                    ("Name value is not a valid name. " +
                    "Valid name begins with a capital letter and consists of letters with an optional apostrophe");
            }
        }
    }
}
