using Newtonsoft.Json;

namespace samplewebapi.Models
{
    public static class PersonExtentionMethods
    {
        public static List<Person> DeserializeObject(this string allPersonDetails)
        {
            return JsonConvert.DeserializeObject<List<Person>>(allPersonDetails) ?? new List<Person>();
        }

        public static string SerializeObject(this List<Person> allPersonDetails)
        {
            return JsonConvert.SerializeObject(allPersonDetails);
        }
    }
}
