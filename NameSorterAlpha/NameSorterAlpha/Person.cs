using System;
using System.Globalization;

namespace NameSorter 
{
    class Person
    {        
        public  string GivenNames;
        public string LastName;
        public DateTime _dateOfBirth;
        int line_num;

        private readonly string[] dateFormat = { "dd-MM-yy", "dd/MM/yy" };

        public Person(string info, int line_num)
        {
            this.line_num = line_num;
            string[] infoArray = info.Split(' ');
            int length = infoArray.Length;

            if (info == "")
            {
                throw new MissingPersonException();
            }

            info.TrimEnd();

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
            GivenNames.TrimEnd(new char[] {' '});
        }

        public string getName()
        {
            return GivenNames + LastName + " " + _dateOfBirth.ToString("dd-MM-yy");
        }
    }
}
