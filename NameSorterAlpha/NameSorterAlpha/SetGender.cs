using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genderize;


namespace NameSorter
{
    class SetGender
    {
        private string _gender;
        public SetGender(string name)
        {
            var someTask = SetFinalGender(name);
            someTask.Wait();
        }

        async Task SetFinalGender(string name)
        {
            var client = new GenderizeClient();
            var result = await client.GetNameGender(name);
            if (result.Gender.HasValue)
            {
               _gender = result.Gender.Value.ToString();
            }
            else
            {
                _gender = "";
            }
        }

        public string GetGender()
        {
            return _gender;
        }
    }
}
