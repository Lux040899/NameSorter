using System.Threading.Tasks;
using Genderize;


namespace NameSorter
{
    class SetGender : ISetGender
    {
        private string _gender;
 
        public async Task SetFinalGender(string name)
        {
            var client = new GenderizeClient();   
            var result = await client.GetNameGender(name);

            if (result.Gender.HasValue) _gender = result.Gender.Value.ToString();
            else _gender = "";
        }

        public string GetGender()
        {
            return _gender;
        }
    }
}
