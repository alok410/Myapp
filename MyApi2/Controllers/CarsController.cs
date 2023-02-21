using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi.Data;
using System.Data.Entity;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private static List<Cars> car = new List<Cars>
        {

                new Cars
                {
                    Id= 1,
                    Name="Mustang Gt",
                    ModelName="FastBack5.0",
                    Place="Michigan"
                },
                 new Cars
                {
                    Id= 2,
                    Name="Supra",
                    ModelName="s500",
                    Place="india"
                }


    };
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {

            _context = context;
        }





        /*get all cars*/

        [HttpGet]
        public async Task<ActionResult<List<Cars>>> Get()
        {
            return Ok(await _context.Car.ToListAsync());
        }


        /* get single car*/
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Cars>>> Get(int id)
        {
            var C = await _context.Car.FindAsync(id);
            if (C == null)
                return BadRequest("Car not found");

            return Ok(car);
        }


        /*add car*/
        [HttpPost]
        public async Task<ActionResult<List<Cars>>> AddCars(Cars C)
        {
           _context.Car.Add(C);
            await _context.SaveChangesAsync();
            return Ok(await _context.Car.ToListAsync());
        }

        /*update car*/
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Cars>>> UpdateCars(Cars request)
        {
            var Dbc = await _context.Car.FindAsync(request.Id);
            if (Dbc == null)
                return BadRequest("Car not found");


            Dbc.Name= request.Name;
            Dbc.ModelName= request.ModelName;
            Dbc.Place= request.Place;

            await _context.SaveChangesAsync();
            return Ok(await _context.Car.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Cars>>> DeleteCars(int id)
        {
            var Dbc = await _context.Car.FindAsync(id);
            if (Dbc == null)
                return BadRequest("Car not found");  

            _context.Car.Remove(Dbc);
            await _context.SaveChangesAsync();
            return Ok(await _context.Car.ToListAsync());
        }
    }
}
