namespace NameSorter
{
    class Factory
    {
        public static IRead CreateReader()
        {
            return new ReadFromFile();
        }

        public static IWrite CreateWriter()
        {
            return new WriteToFile();
        }

        public static ISorter CreateSorter(int i)
        {
            if (i == 1) return new SorterAscending();
            else return new SorterDescending();
        }

        public static ISetGender CreateGender()
        {
            return new SetGender();
        }

        public static IPerson CreatePerson()
        {
            return new Person();
        }

    }
}
