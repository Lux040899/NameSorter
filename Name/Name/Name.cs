namespace Name
{
    class Name : IName
    { 
        public string _firstName;
        public string _lastName;

        public Name(NameParser parserObj)
        {
            _firstName = parserObj.nameArray[0];
            _lastName = parserObj.nameArray[1];
        }

        public Name(string firstName, string lastName)
        {
            _firstName = firstName.Trim();
            _lastName = lastName.Trim();
        }

    }
}
