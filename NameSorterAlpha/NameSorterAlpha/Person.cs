using System;
using System.Globalization;

namespace NameSorter 
{
    public class Person
    {        
        public  string GivenNames;
        public string LastName;
        public DateTime _dateOfBirth;     

        private readonly string[] dateFormat = { "dd-MM-yy", "dd/MM/yy" };

        public Person(string info)
        {
            info = info.TrimEnd();
            string[] infoArray = info.Split(' ');
            int length = infoArray.Length;
            if (info == "")
            {
                throw new MissingPersonException();
            }

            if (DateTime.TryParseExact(infoArray[length - 1], dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out _dateOfBirth)) { }

            else
            {
                throw new MissingBDayException();
            }

            if (length < 3) throw new MissingLastNameException();

            LastName = infoArray[length - 2];
            for (int i = 0; i < length - 2; i++)
            {
                GivenNames += infoArray[i];
                GivenNames += ' ';
            }
            GivenNames = GivenNames.TrimEnd();
        }

        public string getName()
        {
            return GivenNames + LastName;
        }
    }
}
