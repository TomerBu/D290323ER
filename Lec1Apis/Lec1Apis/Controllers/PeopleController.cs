using Lec1Apis.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lec1Apis.Controllers
{

    //https://localhost:5000/api/people
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        static List<Person> people =
        [
            new Person("John", 30),
            new Person("Jane", 25),
            new Person("Joe", 40)
        ];

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return people;
        }

        //Get by id: https://localhost:5000/api/people/1

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            //return (from p in people where p.Id == id select p).FirstOrDefault();
            //return people.FirstOrDefault(p => p.Id == id);
            var person = people.Find(p => p.Id == id);

            if (person is null)
            {
                return NotFound(id);
            }

            return Ok(person);
            //return people.Where(p => p.Id == id).FirstOrDefault();
            //return people.Where(p => p.Id == id).FirstOrDefault();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {//200 Success, 201 Created, 204 No Content, 400 Bad Request, 404 Not Found 500 Internal Server Error
            //var index = people.FindIndex(p => p.Id == id);
            var person = people.Find(p => p.Id == id);

            if (person != null)
            {
                people.Remove(person);
                return Ok(person); //200 here is the person we removed...
            }
            else
            {
                return NotFound(id);
            }
        }

        /*[HttpGet("byName/{name}")]
        public IEnumerable<Person> Get(string name)
        {
            return people.Where(p => p.Name.Contains(name));
        }*/

        [HttpPost]
        public IActionResult Post(Person p)
        {
            people.Add(p);
            p.Id = Guid.NewGuid();
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] Guid id, Person p)
        {
            //the reference to the person in the list
            var person = people.Find(p => p.Id == id);

            if (person != null)
            {
                person.Name = p.Name;
                person.Age = p.Age;
                return Ok(person);
            }
            else
            {
                return NotFound(id);
            }
        }
    }
}


//create a Model class Product:
//each product has: id int, name string, price double
//scaffold a controller with actions => right click on controller => add => Controller
//in the controller - static var myList = new List<Product>()
//the list must be static in our scenario. 
//CRUD operations