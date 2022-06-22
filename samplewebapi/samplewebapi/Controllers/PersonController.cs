using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using samplewebapi.Models;
using samplewebapi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace samplewebapi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("corsapp")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        // GET: api/<PersonController>
        [HttpGet]
        public async Task<List<Person>> Get()
        {
            return await _personService.GetAllPersons();
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Person personDetails)
        {
            if (ModelState.IsValid)
            {
                return await _personService.InsertPerson(personDetails);
            }
            else
            {
                return false;
            }
        }
    }
}
