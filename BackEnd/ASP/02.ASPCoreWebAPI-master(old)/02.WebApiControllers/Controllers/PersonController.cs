using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.DataTransferObjects;
using WebApiDemo.Domain;
using WebApiDemo.Http;

namespace WebApiDemo.Controllers
{
    [Route("/people")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public IEnumerable<Person> People()
        {
            return PersonTestData.GetPersonList();
        }

        [Route("{id:int}")]
        public IActionResult Person(int id)
        {
            var existingPerson = PersonTestData.GetPersonList().Where(p => p.Id == id).FirstOrDefault();
            if (existingPerson is object)
            {
                return StatusCode(StatusCodes.Status200OK, existingPerson);
            }

            return StatusCode(StatusCodes.Status404NotFound, new HttpResponseError() { Message = $"Cannot find person {id}", StatusCode = StatusCodes.Status404NotFound });
        }

        [HttpPost]
        public IActionResult NewPerson([FromBody] PersonDTO personDTO)
        {
            var person = new Person
            {
                Id = PersonTestData.GetPersonList().Count() + 1,
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName,
                Email = personDTO.Email,
                Age = personDTO.Age,
                Password = personDTO.NewPassword
            };

            PersonTestData.GetPersonList().Add(person);

            return StatusCode(StatusCodes.Status200OK, person);
        }
    }
}
