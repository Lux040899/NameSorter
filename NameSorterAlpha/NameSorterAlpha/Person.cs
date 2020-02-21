using System;
using System.Globalization;
using System.Threading.Tasks;
using Genderize;

namespace NameSorter 
{
    public class Person
    {        
        private  string _givenNames;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _gender;

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

            SetGender(_givenNames);
        }

        async Task SetGender(string name)
        {
            var client = new GenderizeClient();
            var result = await client.GetNameGender(name);
            if (result.Gender.HasValue) {
                _gender = result.Gender.Value.ToString();
            }
            else {
                _gender = "";
            }

        }


        public string GetName()
        {
            return _givenNames + " " + _lastName + " " + _gender;
        }

        public string GetGivenName()
        {
            return _givenNames;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public string GetGender()
        {
            return _gender;
        }

        public DateTime GetDate()
        {
            return _dateOfBirth;
        }
    }
}