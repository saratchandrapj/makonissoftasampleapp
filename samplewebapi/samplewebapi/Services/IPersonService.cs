using samplewebapi.Models;

namespace samplewebapi.Services
{
    public interface IPersonService
    {
        Task<bool> InsertPerson(Person personDetails);
        Task<List<Person>> GetAllPersons();
    }
}
