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
            info.TrimEnd();
            string[] infoArray = info.Split(' ');
            int length = infoArray.Length;

            if (length < 3) throw new MissingInfoException();

            LastName = infoArray[length - 2];
            for (int i = 0; i < length - 2; i++)
            {
                GivenNames += infoArray[i];
                GivenNames += ' ';
            }
            GivenNames.TrimEnd(new char[] {' '});

            if (DateTime.TryParseExact(infoArray[length - 1], dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, 
                out _dateOfBirth)) { }

            else
            {
                Console.WriteLine("The person in line " + line_num + " is missing DOB.\n");

            }


        }

        public string getName()
        {
            return GivenNames + LastName;
        }
    }
}
