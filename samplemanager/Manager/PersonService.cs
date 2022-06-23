using samplemodels.Models;
using sampleservices.Services;

namespace samplemanager.Manager
{
    public class PersonService : IPersonService
    {
        private AbstractFileHandler _fileHandler;
        public PersonService(AbstractFileHandler fileHandler)
        {
            _fileHandler = fileHandler;
        }

        /// <summary>
        /// Get all Person Details from the Json file
        /// </summary>
        /// <returns>List of Person Details</returns>
        public async Task<List<Person>> GetAllPersons()
        {
            List<Person> people = new List<Person>();
            try
            {
                string fileData = await _fileHandler.ReadFile();
                people = fileData.DeserializeObject();
            }
            catch (Exception e)
            {

            }
            return people;
        }

        /// <summary>
        /// Insert the person details into json file
        /// </summary>
        /// <param name="personDetails">person details to be added</param>
        /// <returns>true if success : false if fails</returns>
        public async Task<bool> InsertPerson(Person personDetails)
        {
            List<Person> allPersonDetails = new List<Person>();
            bool isSuccess = false;
            try
            {
                allPersonDetails = await GetAllPersons();
                allPersonDetails.Add(personDetails);
                isSuccess = await _fileHandler.UpdateFile(allPersonDetails.SerializeObject());
                return isSuccess;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
