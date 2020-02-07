using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter 
{
    class Person
    {        
        public  string GivenNames;
        public string LastName;
        public DateTime _dateOfBirth;

        private const string dateFormat = "dd-MM-yy";

        public Person(string info)
        {
            info.TrimEnd();
            string[] infoArray = info.Split(' ');
            int length = infoArray.Length;

            _dateOfBirth = DateTime.ParseExact(infoArray[length - 1], dateFormat, CultureInfo.InvariantCulture);
            LastName = infoArray[length - 2];
            for (int i = 0; i < length - 2; i++)
            {
                GivenNames += infoArray[i];
                GivenNames += ' ';
            }
            GivenNames.TrimEnd();

        }

        public string getName()
        {
            return this.GivenNames + this.LastName;
        }
    }
}
