using Lec2WebApi.Models;
using Lec2WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lec2WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        //props:
        public IMongoCollection<Person> people { get; set; }

        //ctor
        public PeopleController(MongoService s)
        {
            people = s.GetCollection<Person>("People");
        }

        [HttpPost]
        public IActionResult PostPerson([FromBody] Person person)
        {
            people.InsertOne(person);
            return Ok(person);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(people.Find(_ => true).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var person = people.Find(p => p.Id == id).FirstOrDefault();
            if (person is null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var result = people.DeleteOne(p => p.Id == id);

            if (result.DeletedCount == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, Person p)
        {
            var result = people.ReplaceOne(person => person.Id == id, p);

            if (result.ModifiedCount == 0)
            {
                return NotFound();
            }
            return Ok(p);
        }

    }
}
