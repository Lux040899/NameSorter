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

        private const string dateFormat = "dd-MM-yy";

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

            try
            {
                _dateOfBirth = DateTime.ParseExact(infoArray[length - 1], dateFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                Console.WriteLine("The person in line " + line_num + " is missing DOB");
            }

           
            
        }

        public string getName()
        {
            return GivenNames + LastName;
        }
    }
}
