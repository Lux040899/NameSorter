using System;
using System.Globalization;
using System.Threading.Tasks;


namespace NameSorter 
{
    public class Person
    {        
        private  string _givenNames;
        private string _lastName;
        private DateTime _dateOfBirth;
        private SetGender Gender;

        private readonly string[] dateFormat = { "dd-MM-yy", "dd/MM/yy" };

        public Person(string info)
        {

            info = info.TrimEnd();
            string[] infoArray = info.Split(' ');
            int length = infoArray.Length;

            if (info == "") throw new MissingPersonException();

            if (DateTime.TryParseExact(infoArray[length - 1], dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out _dateOfBirth)) {

            } else {
                throw new MissingBDayException();
            }

            if (length < 3) throw new MissingLastNameException();

            _lastName = infoArray[length - 2];

            for (int i = 0; i < length - 2; i++)
            {
                _givenNames += infoArray[i];
                _givenNames += ' ';
            }

            _givenNames = _givenNames.TrimEnd();
            Gender = new SetGender(_givenNames);

        }

        public string GetName()
        {
            return _givenNames + " " + _lastName + " " + Gender.GetGender();
        }

        public string GetGivenName()
        {
            return _givenNames;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public DateTime GetDate()
        {
            return _dateOfBirth;
        }
    }
}