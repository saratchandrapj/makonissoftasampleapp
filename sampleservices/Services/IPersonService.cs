using samplemodels.Models;

namespace sampleservices.Services
{
    public interface IPersonService
    {
        Task<bool> InsertPerson(Person personDetails);
        Task<List<Person>> GetAllPersons();
    }
}
