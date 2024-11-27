using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRentalServiceAssignment.Models;
using CarRentalServiceAssignment.Services;
using Microsoft.AspNetCore.Authorization;

namespace CarRentalServiceAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarRentalService _carService;

        public CarsController(CarRentalService carService) => _carService = carService;


        [HttpGet]
        public async Task<IActionResult> GetAvailableCars()
        {
            return Ok(await _carService.GetAvailableCars());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCar(Car car)
        {

            await _carService.AddCar(car);
            return CreatedAtAction(nameof(AddCar), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCar(int id, Car car)
        {
            try
            {
                await _carService.UpdateCar(id, car); 
                return NoContent(); 
            }
            catch (KeyNotFoundException) 
            {
                return NotFound(); 
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            
            try
            {
                await _carService.DeleteCar(id); 
                return NoContent(); 
            }
            catch (KeyNotFoundException) 
            {
                return NotFound(); 
            }
        }
    }
}
