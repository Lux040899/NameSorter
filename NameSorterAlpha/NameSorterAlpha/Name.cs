using System;

namespace NameSorterAlpha
{
    class Name : IComparable<Name>
    {
        private string name;
        private string Lastname;
        private int index_of_last_name;
        public Name(string name)
        {
            this.name = name;
            // Finding the first index of Last Name
            index_of_last_name = name.LastIndexOf(' ') + 1;
            this.Lastname = name.Substring(index_of_last_name);
        }

        public int CompareTo(Name other)
        {
            if (this.Lastname.CompareTo(other.Lastname) == 0)
            {
                return this.ComparePreviousNames(other);
            }

            else return this.Lastname.CompareTo(other.Lastname);
        }

        public int ComparePreviousNames(Name other)
        {
            int result = 0;

            while (this.index_of_last_name > 0 && other.index_of_last_name > 0)
            {
                result = this.getPreviousName().CompareTo(other.getPreviousName());
                if (result != 0)
                {
                    this.ResetLastNameIndex(other);
                    return result;
                }
            }


            if (this.index_of_last_name == 0 && other.index_of_last_name > 0)
            {
                this.ResetLastNameIndex(other);
                return -1;
            }
            else if (this.index_of_last_name > 0 && other.index_of_last_name == 0)
            {
                this.ResetLastNameIndex(other);
                return 1;
            }

            this.ResetLastNameIndex(other);

            return result;
        }

        public string getPreviousName()
        {
            string PreviousName;
            int index_tracker = index_of_last_name - 2;

            while (index_tracker > 0 && this.name[index_tracker] != ' ') index_tracker--;

            if (index_tracker != 0)
            {
                PreviousName = this.name.Substring(index_tracker + 1, index_of_last_name - index_tracker - 2);
                this.index_of_last_name = index_tracker + 1;
            }

            else
            {
                PreviousName = this.name.Substring(index_tracker, index_of_last_name - 1);
                this.index_of_last_name = index_tracker;
            }

            return PreviousName;
        }

        public void ResetLastNameIndex(Name other)
        {
            this.index_of_last_name = this.name.LastIndexOf(' ') + 1;
            other.index_of_last_name = other.name.LastIndexOf(' ') + 1;

        }

        public string getName()
        {
            return this.name;
        }

    }

}
