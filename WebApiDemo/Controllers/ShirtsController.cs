using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Data;
using WebApiDemo.FIilters;
using WebApiDemo.FIilters.ActionFilters;
using WebApiDemo.FIilters.ExceptionFilters;
using WebApiDemo.Models;
using WebApiDemo.Models.Repositories;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShirtsController : ControllerBase
    {
        private readonly ShirtRepositories shirtRepositories = new();

        private readonly ApplicationDbContext _db;
        public ShirtsController(ApplicationDbContext db) 
        { 
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllShirts()
        {
            
            try
            {
                return Ok(_db.Shirts.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(ValidateShirtIDAttribute))]
        public IActionResult GetById(int id)
        {
            //if(id <= 0)
            //{
            //    return BadRequest();
            //}

            //var shirt = shirtRepositories.GetById(id);

            //if (shirt == null)
            //{
            //    return NotFound();
            //}

            return Ok(HttpContext.Items["shirt"]);
        }

        [HttpPost]
        [TypeFilter(typeof(ValidateAddNewShirtFilterAttribute))]
        public IActionResult AddShirt([FromBody] Shirt shirt)
        {
            //if(shirt == null) { return BadRequest(); }

            //var isShirtExist = shirtRepositories.GetShirtByProperty(shirt.Brand, shirt.Color, shirt.Size, shirt.Gender);

            //if (isShirtExist != null)
            //{
            //    return BadRequest();
            //}

            //shirtRepositories.AddShirt(shirt);
            _db.Shirts.Add(shirt);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetById), new {id = shirt.ShirtId}, shirt);
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(ValidateShirtIDAttribute))]
        [ValidateUpdateShirtFilter]
        [TypeFilter(typeof(ShirtUpdateExceptionsFilterAttribute))]
        public IActionResult update(int id, Shirt shirt)
        {
            var shirtToUpdate = HttpContext.Items["shirt"] as Shirt;
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Gender = shirt.Gender;

            //_db.Entry(shirtToUpdate);
            _db.SaveChanges(true);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(ValidateShirtIDAttribute))]
        public IActionResult delete(int id)
        {
            var shirtToDelete = HttpContext.Items["shirt"] as Shirt;

            _db.Shirts.Remove(shirtToDelete);
            _db.SaveChanges();


            return Ok(shirtToDelete);
        }


    }
}
