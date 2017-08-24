using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using PersonApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;



namespace PersonApi.Controllers
{
    
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly PersonContext _context;

        public PersonController(PersonContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();

            if (_context.Person.Count() == 0)
            {
                
                _context.Person.Add(new Person { FirstName = "Dax", LastName="Mateo" });
                _context.Person.Add(new Person { FirstName = "Tim", LastName="Green" });
                _context.SaveChanges();
                

            }
        }

        // GET api/person
        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            return _context.Person.ToList();
        }       
        

        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult GetById(long key)
        {
            var item = _context.Person.FirstOrDefault(t => t.Key == key);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        
        //Post api/person
        [HttpPost]
        public IActionResult Create([FromBody] Person item)
        {
         if (item == null)
          {
           return BadRequest();
          }

         _context.Person.Add(item);
         _context.SaveChanges();
         return CreatedAtRoute("GetPerson", new { id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Person item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var Person = _context.Person.Find(id);
            if (Person == null)
            {
                return NotFound();
            }

            Person.FirstName = item.FirstName;
            Person.LastName = item.LastName;

            _context.Person.Update(Person);
            _context.SaveChanges();
            return new NoContentResult();
        }
    
   }
}