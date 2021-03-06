﻿using System;
using System.Globalization;
using System.Threading.Tasks;


namespace NameSorter 
{
    public class Person : IPerson
    {        
        private  string _givenNames;
        private string _lastName;
        private DateTime _dateOfBirth;
        private ISetGender Gender;
        private int _lineCount;

        private readonly string[] dateFormat = { "dd-MM-yy", "dd/MM/yy" };

        public void Initialise(string info, int lineCount)
        {
            _lineCount = lineCount;
            info = info.TrimEnd();
            string[] infoArray = info.Split(' ');
            int length = infoArray.Length;

            if (info == "") throw new MissingDataException($"The person in {lineCount} is missing all information.");

            if (DateTime.TryParseExact(infoArray[length - 1], dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out _dateOfBirth)) {
            }
            else throw new MissingDataException($"The person in line {lineCount}  with info {info} is missing his/her Birthday.");
            

            if (length < 3) throw new MissingDataException($"The person in line {lineCount} " +
                $" with info {info} is missing his/her Last Name.");

            _lastName = infoArray[length - 2];

            for (int i = 0; i < length - 2; i++)
            {
                _givenNames += infoArray[i];
                _givenNames += ' ';
            }

            _givenNames = _givenNames.TrimEnd();            
        }

        public async Task InitialiseGender()
        {
            Gender = Factory.CreateGender();

            await Gender.SetFinalGender(_givenNames);
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