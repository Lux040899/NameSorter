namespace Name
{
    class Name : IName
    { 
        public string _firstName;
        public string _lastName;

        public Name(NameParser parserObj)
        {
            int length = parserObj.nameArray.Length;
            for (int i = 0; i < length - 2; i++)
            {
                _firstName += parserObj.nameArray[i];
                _firstName += ' ';
            }
            _firstName = _firstName.TrimEnd();
            _lastName = parserObj.nameArray[length - 1];
        }

        public Name(string firstName, string lastName)
        {
            _firstName = firstName.Trim();
            _lastName = lastName.Trim();
        }

    }
}
