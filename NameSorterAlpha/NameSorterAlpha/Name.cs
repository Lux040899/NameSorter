using System;

namespace NameSorter
{
    class Name : IComparable<Name>
    {
        private string name;
        private string Lastname;
        private int index_tracker;
        public Name(string name)
        {
            this.name = name;
            // Finding the first index of Last Name.
            index_tracker = name.LastIndexOf(' ') + 1;
            this.Lastname = name.Substring(index_tracker);
        }

        // Overwriting the method in IComparable interface to specify behaviour for Name class object.
        public int CompareTo(Name other)
        {
            if (this.Lastname.CompareTo(other.Lastname) == 0)
            {
                return this.ComparePreviousNames(other);
            }

            else return this.Lastname.CompareTo(other.Lastname);
        }

        // Method to compare two names in cas of a collision i.e. same last name.
        public int ComparePreviousNames(Name other)
        {
            int result = 0;

            while (this.index_tracker > 0 && other.index_tracker > 0)
            {
                result = this.getPreviousName().CompareTo(other.getPreviousName());
                if (result != 0)
                {
                    this.ResetLastNameIndex(other);
                    return result;
                }
            }


            if (this.index_tracker == 0 && other.index_tracker > 0)
            {
                this.ResetLastNameIndex(other);
                return -1;
            }
            else if (this.index_tracker > 0 && other.index_tracker == 0)
            {
                this.ResetLastNameIndex(other);
                return 1;
            }

            this.ResetLastNameIndex(other);
            return result;
        }

        // Method to return the previous component of a given name.
        public string getPreviousName()
        {
            string PreviousName;
            int index = this.index_tracker - 2;

            while (index > 0 && this.name[index - 1] != ' ') index--;

            
            PreviousName = this.name.Substring(index, this.index_tracker - index - 1);
            this.index_tracker = index + 1;

            return PreviousName;
        }

        // Method to reset the index_ to the Last Name
        public void ResetLastNameIndex(Name other)
        {
            this.index_tracker = this.name.LastIndexOf(' ') + 1;
            other.index_tracker = other.name.LastIndexOf(' ') + 1;

        }

        public string getName()
        {
            return this.name;
        }

    }

}
